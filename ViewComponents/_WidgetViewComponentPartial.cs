using LibraryDapperProject.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDapperProject.ViewComponents
{
    public class _WidgetViewComponentPartial : ViewComponent
    {
        private readonly IDashboardService _dashboardService;

        public _WidgetViewComponentPartial(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IViewComponentResult> InvokeAsync() // Async yaptık
        {
            var stats = await _dashboardService.GetDashboardStatisticsAsync();
            return View(stats); // Veriyi Default.cshtml'e gönderdik
        }
    }
}
