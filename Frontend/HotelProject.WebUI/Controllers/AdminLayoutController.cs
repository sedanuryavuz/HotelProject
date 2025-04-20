using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        /* ismi değiştirdik ve sağ tıklayıp add view yaptık. razor view yaptık ve bir seçim(tik) yapmadık.*/
        public IActionResult _AdminLayout()
        {
            return View();
        }
        //partial ekledik ve headPartiala sağ tıkla add view de ve bir razor view ekledik. tiklerden sadece partial view'i seçtik.
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult PreloaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavheaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult SidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }        
        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
    }
}
