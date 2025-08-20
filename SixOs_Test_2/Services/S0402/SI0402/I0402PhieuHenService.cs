using SixOs_Test_2.Models.M0402.DTO0402;

namespace SixOs_Test_2.Services.S0402.SI0402
{
    public interface I0402PhieuHenService
    {
        public Task<byte[]> GetDataForPDFExport(DTO0402XuatPDFPhieuHenRequest dto);
    }
}
