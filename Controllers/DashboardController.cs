using LibraryDapperProject.Repositories.Abstract;
using LibraryDapperProject.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDapperProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {

            var activeUsersTask = _dashboardService.GetMostActiveUsersAsync();
            var topRatedBooksTask = _dashboardService.GetTopRatedBooksAsync();
            var yearlyBooksTask = _dashboardService.GetYearlyBookCountsAsync();

            await Task.WhenAll(activeUsersTask, topRatedBooksTask, yearlyBooksTask);

            var model = new DashboardViewModel
            {
                ActiveUsers = activeUsersTask.Result,
                TopRatedBooks = topRatedBooksTask.Result,
                YearlyBooks = yearlyBooksTask.Result
            };

            return View(model);
        }
    }
}
