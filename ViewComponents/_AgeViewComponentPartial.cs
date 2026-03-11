using LibraryDapperProject.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDapperProject.ViewComponents
{
    public class _AgeViewComponentPartial : ViewComponent
    {
        private readonly IDashboardService _dashboardService;
        public _AgeViewComponentPartial(IDashboardService dashboardService) => _dashboardService = dashboardService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Servisten listeyi çekiyoruz
            var values = await _dashboardService.GraphicAnalysisAsync();
            // Listeyi direkt View'a model olarak gönderiyoruz
            return View(values);
        }
    }
}
