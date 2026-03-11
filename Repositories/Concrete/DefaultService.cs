using Dapper;
using LibraryDapperProject.Context;
using LibraryDapperProject.Dtos;
using LibraryDapperProject.Repositories.Abstract;

namespace LibraryDapperProject.Repositories.Concrete
{
    public class DefaultService : IDefaultService
    {
        private readonly DapperContext _context;

        public DefaultService(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<ResultBookDto>> GetPagedBooksAsync(int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;

            string query = @"SELECT ISBN, Book_Title, Book_Author, Year_Of_Publication, Publisher, Image_Url_S 
                         FROM Books WITH (NOLOCK)
                         ORDER BY ISBN -- Sıralama olmadan OFFSET çalışmaz
                         OFFSET @Skip ROWS FETCH NEXT @PageSize ROWS ONLY";

            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultBookDto>(query, new { Skip = skip, PageSize = pageSize });
            return values.ToList();
        }
    }
}
