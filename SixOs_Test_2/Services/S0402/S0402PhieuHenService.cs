using Microsoft.EntityFrameworkCore;
using SixOs_Test_2.Context;
using SixOs_Test_2.Models.M0402.DTO0402;
using SixOs_Test_2.PDFDocuments.P0402;
using SixOs_Test_2.Services.S0402.SI0402;
using QuestPDF.Fluent;

namespace SixOs_Test_2.Services.S0402
{
    public class S0402PhieuHenService : I0402PhieuHenService
    {
        private readonly AppDbContext _context; 

        public S0402PhieuHenService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<byte[]> GetDataForPDFExport(DTO0402XuatPDFPhieuHenRequest dto)
        {
            var result = _context.DataPhieuHen
                .FromSqlRaw(
                    "EXEC S0402_PhieuhenCLS @IdChiNhanh={0}, @IdVaoVien={1}, @MaLoaiCLS={2}, @IdNoiDungHen={3}",
                    dto.IDChiNhanh, 
                    dto.IDVaoVien, 
                    dto.MaLoaiCLS,
                    dto.IDNoiDungHen
                )
                .AsEnumerable()   
                .FirstOrDefault();

            var huongDanImage = await P0402HTMLToImage.RenderHtmlAsync(result.HuongDan);

            var pages = P0402HTMLToImage.SplitImageToA5Pages(huongDanImage);

            var questPdfDoc = new P0402PhieuHenPDF(result, pages);
            var questPdfBytes = questPdfDoc.GeneratePdf();

            return questPdfBytes;
        }
    }
}
