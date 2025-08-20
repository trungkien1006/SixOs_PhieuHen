using Microsoft.AspNetCore.Mvc;

namespace SixOs_Test_2.Controllers.C0402
{
    [Route("xuat_pdf")]
    public class C0402XuatPDFController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View("~/Views/V0402/V0402PhieuHen/V0402PhieuHen.cshtml");
        }
    }
}
