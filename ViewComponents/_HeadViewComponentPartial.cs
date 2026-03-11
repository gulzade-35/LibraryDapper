using Microsoft.AspNetCore.Mvc;

namespace LibraryDapperProject.ViewComponents
{
    public class _HeadViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
