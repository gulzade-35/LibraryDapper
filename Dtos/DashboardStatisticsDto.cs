namespace LibraryDapperProject.Dtos
{
    public class DashboardStatisticsDto
    {
        public int TotalBookCount { get; set; }
        public int TotalAuthorCount { get; set; }
        public int TotalPublisherCount { get; set; }
        public double AverageRating { get; set; }
    }
}
