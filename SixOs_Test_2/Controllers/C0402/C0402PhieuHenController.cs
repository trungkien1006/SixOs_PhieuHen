using Microsoft.AspNetCore.Mvc;
using SixOs_Test_2.Models.M0402.DTO0402;
using SixOs_Test_2.Services.S0402.SI0402;

namespace SixOs_Test_2.Controllers.C0402
{
    [ApiController]
    [Route("api/phieu_hen")]
    public class C0402PhieuHenController : Controller
    {
        //private string _maChucNang = "/phieu_hen";
        //private IMemoryCachingServices _memoryCache;

        private readonly I0402PhieuHenService _service;

        public C0402PhieuHenController(I0402PhieuHenService service    /*, IMemoryCachingServices memoryCache*/   )
        {
            _service = service;

            //_memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<IActionResult> ExportPDF([FromBody] DTO0402XuatPDFPhieuHenRequest dto)
        {
            var finalPDF = await _service.GetDataForPDFExport(dto);

            if (finalPDF == null)
            {
                return NotFound();
            }

            return File(finalPDF, "application/pdf", "PhieuHen.pdf");
        }
    }
}
