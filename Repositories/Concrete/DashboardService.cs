
using Dapper;
using LibraryDapperProject.Context;
using LibraryDapperProject.Dtos;
using LibraryDapperProject.Repositories.Abstract;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryDapperProject.Repositories.Concrete
{
    public class DashboardService : IDashboardService
    {
        private readonly DapperContext _context;

        public DashboardService(DapperContext context)
        {
            _context = context;
        }

        // 📊 Dashboard Statistics


        public async Task<DashboardStatisticsDto> GetDashboardStatisticsAsync()
        {
            string query = @"
        SELECT 
            COUNT(*) AS TotalBookCount,
            COUNT(DISTINCT Book_Author) AS TotalAuthorCount,
            COUNT(DISTINCT Publisher) AS TotalPublisherCount,
            (
                SELECT ROUND(AVG(CAST(Book_Rating AS FLOAT)),2) 
                FROM Ratings
            ) AS AverageRating
        FROM Books;
    ";

            using var connection = _context.CreateConnection();
            var result = await connection.QueryFirstAsync<DashboardStatisticsDto>(query);

            return result;
        }

        public async Task<List<ResultChartDto>> GetMostActiveUsersAsync()
        {
            string query = @"SELECT TOP 5
                     User_ID AS Title,
                     COUNT(*) AS Count
                     FROM Ratings
                     GROUP BY User_ID
                     ORDER BY Count DESC";

            using var conn = _context.CreateConnection();
            var values = await conn.QueryAsync<ResultChartDto>(query);

            return values.ToList();
        }


        // ⭐ En yüksek puanlı kitaplar


        public async Task<List<ResultChartDto>> GetTopRatedBooksAsync()
        {
            string query = @"
        SELECT TOP 5
            b.Book_Title AS Title,
            t.Count
        FROM
        (
            SELECT ISBN, COUNT(*) AS Count
            FROM Ratings
            GROUP BY ISBN
        ) t
        INNER JOIN Books b ON t.ISBN = b.ISBN
        ORDER BY t.Count DESC
    ";

            using var conn = _context.CreateConnection();
            var values = await conn.QueryAsync<ResultChartDto>(query, commandTimeout: 120);

            return values.ToList();

        }






        // 📅 Yıllara göre kitap sayısı
        public async Task<List<BooksChartDto>> GetYearlyBookCountsAsync()
        {
            string query = @"
                SELECT TOP 10
                    Year_Of_Publication AS Year,
                    COUNT(*) AS Count
                FROM Books WITH (NOLOCK)
                WHERE Year_Of_Publication BETWEEN 2000 AND 2024
                GROUP BY Year_Of_Publication
                ORDER BY Year_Of_Publication ASC;
            ";

            using var conn = _context.CreateConnection();
            var values = await conn.QueryAsync<BooksChartDto>(query);

            return values.ToList();
        }

        public async Task<List<GraphicDto>> GraphicAnalysisAsync()
        {
            string query = @"SELECT 
        CASE  
            WHEN u.Age BETWEEN 10 AND 20 THEN '10-20'
            WHEN u.Age BETWEEN 21 AND 30 THEN '21-30'
            WHEN u.Age BETWEEN 31 AND 40 THEN '31-40'
            WHEN u.Age BETWEEN 41 AND 50 THEN '41-50'
            ELSE '50+'
        END AS AgeGroup,
        COUNT(*) AS RatingCount,
        ROUND(AVG(CAST(r.Book_Rating AS FLOAT)), 2) AS AvgRating -- Ortalamayı buraya ekledik
        FROM Users u WITH (NOLOCK)
        INNER JOIN Ratings r WITH (NOLOCK) ON u.User_ID = r.User_ID
        WHERE u.Age IS NOT NULL
        GROUP BY 
        CASE  
            WHEN u.Age BETWEEN 10 AND 20 THEN '10-20'
            WHEN u.Age BETWEEN 21 AND 30 THEN '21-30'
            WHEN u.Age BETWEEN 31 AND 40 THEN '31-40'
            WHEN u.Age BETWEEN 41 AND 50 THEN '41-50'
            ELSE '50+'
        END";

            using var conn = _context.CreateConnection();
            // 1 milyon veride JOIN ağır olabilir, timeout süresini uzun tutalım
            var values = await conn.QueryAsync<GraphicDto>(query, commandTimeout: 90);
            return values.ToList();
        }
    }
}

