using SixOs_Test_2.Models.M0402.E0402;

namespace SixOs_Test_2.Services.S0402.SI0402
{
    public interface I0402QLNoiDungHenService
    {
        public Task<IEnumerable<M0402NoiDungHen>> GetAll(string maLoaiCLS);
    }
}
