using LibraryDapperProject.Dtos;

namespace LibraryDapperProject.ViewModel
{
    public class DashboardViewModel
    {
        public List<ResultChartDto> ActiveUsers { get; set; }
        public List<ResultChartDto> TopRatedBooks { get; set; }
        public List<BooksChartDto> YearlyBooks { get; set; }
    }
}
