using Microsoft.AspNetCore.Mvc;

namespace LibraryDapperProject.ViewComponents
{
    public class _NavbarViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
