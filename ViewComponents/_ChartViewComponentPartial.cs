using LibraryDapperProject.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDapperProject.ViewComponents
{
    public class _ChartViewComponentPartial : ViewComponent
    {
        private readonly IDashboardService _dashboardService;
        public _ChartViewComponentPartial(IDashboardService dashboardService) => _dashboardService = dashboardService;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _dashboardService.GetYearlyBookCountsAsync(); //

            // ViewComponent kendi ViewBag'lerini doldurmalı
            ViewBag.ChartLabels = values.Select(x => x.Year).ToList();
            ViewBag.ChartValues = values.Select(x => x.Count).ToList();

            return View();
        }
    }
}
