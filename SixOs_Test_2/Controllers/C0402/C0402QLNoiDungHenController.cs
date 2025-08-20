using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixOs_Test_2.Context;
using SixOs_Test_2.Models.M0402.E0402;
using SixOs_Test_2.Services.S0402.SI0402;

namespace SixOs_Test_2.Controllers.C0402
{
    [ApiController]
    [Route("api/noi_dung_hen")]
    public class C0402QLNoiDungHenController : Controller
    {
        //private string _maChucNang = "/xuat_pdf";
        //private IMemoryCachingServices _memoryCache;

        private readonly I0402QLNoiDungHenService _service;

        public C0402QLNoiDungHenController(I0402QLNoiDungHenService service     /*, IMemoryCachingServices memoryCache*/    )
        {
            _service = service;

            //_memoryCache = memoryCache;
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<IEnumerable<M0402NoiDungHen>>> GetByID(string code)
        {
            var result = await _service.GetAll(code);

            return Ok(result);
        }
    }
}
