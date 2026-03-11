using LibraryDapperProject.Dtos;

namespace LibraryDapperProject.Repositories.Abstract
{
    public interface IDashboardService
    {
        Task<DashboardStatisticsDto> GetDashboardStatisticsAsync();
        Task<List<BooksChartDto>> GetYearlyBookCountsAsync();
        Task<List<ResultChartDto>> GetTopRatedBooksAsync();
        Task<List<GraphicDto>> GraphicAnalysisAsync();
        Task<List<ResultChartDto>> GetMostActiveUsersAsync();
    }
}
