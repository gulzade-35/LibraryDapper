using Microsoft.AspNetCore.Mvc;

namespace LibraryDapperProject.ViewComponents
{
    public class _ScriptViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
