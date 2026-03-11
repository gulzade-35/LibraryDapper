using Microsoft.AspNetCore.Mvc;

namespace LibraryDapperProject.ViewComponents
{
    public class _AvarageViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
