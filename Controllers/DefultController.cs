using LibraryDapperProject.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LibraryDapperProject.Controllers
{
    public class DefultController : Controller
    {
        private readonly IDefaultService _defaultService;

        public DefultController(IDefaultService defaultService)
        {
            _defaultService = defaultService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 20; // Sayfada 20 kitap gösterelim
            var values = await _defaultService.GetPagedBooksAsync(page, pageSize);
            ViewBag.CurrentPage = page;
            return View(values);
        }
    }
}
