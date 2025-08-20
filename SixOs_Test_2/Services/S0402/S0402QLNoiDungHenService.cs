using Microsoft.EntityFrameworkCore;
using SixOs_Test_2.Context;
using SixOs_Test_2.Models.M0402.E0402;
using SixOs_Test_2.Services.S0402.SI0402;

namespace SixOs_Test_2.Services.S0402
{
    public class S0402QLNoiDungHenService : I0402QLNoiDungHenService
    {
        private readonly AppDbContext _context;

        public S0402QLNoiDungHenService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<M0402NoiDungHen>> GetAll(string maLoaiCLS)
        {
            if (string.IsNullOrEmpty(maLoaiCLS))
            {
                return [];
            }

            var result = await _context.DSNoiDungHen.Where(p => p.MaLoaiCLS == maLoaiCLS && p.Active).ToListAsync();

            return result;
        }
    }
}
