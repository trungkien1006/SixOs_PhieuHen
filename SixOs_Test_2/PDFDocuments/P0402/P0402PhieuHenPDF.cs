using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SixOs_Test_2.Models.M0402.DTO0402;

namespace SixOs_Test_2.PDFDocuments.P0402
    {
        public class P0402PhieuHenPDF : IDocument
        {
            public string TenMau { get; }
            public string TenBN { get; }
            public int NamSinh { get; }
            public DateOnly NgayHen { get; }
            public TimeOnly GioHen { get; }
            public string HuongDan { get; }
            public List<byte[]> HuongDanImage { get; }

        public P0402PhieuHenPDF(DTO0402DataPDFPhieuHen data, List<byte[]> huongDanImage)
        {
                TenMau = data.TenMau;
                TenBN = data.TenBN;
                NamSinh = data.NamSinh;
                NgayHen = data.NgayHen;
                GioHen = data.GioHen;
                HuongDan = data.HuongDan;
                HuongDanImage = huongDanImage;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            DateTime now = DateTime.Now;

            int day = now.Day;    
            int month = now.Month;
            int year = now.Year;   

            container.Page(page =>
                {
                    page.MarginVertical(15);
                    page.MarginHorizontal(30);
                    page.Size(PageSizes.A5);
                    page.DefaultTextStyle(x => x.FontFamily(Fonts.TimesNewRoman));

                    page.Header().PaddingBottom(10).Row(row =>
                    {
                        row.ConstantItem(60).AlignMiddle().PaddingRight(10).Image("wwwroot/dist/img/logo.png");
                        // Cột 2: Tiêu đề căn giữa
                        row.RelativeItem().AlignLeft().Text(text =>
                        {
                            text.Span("BỆNH VIỆN UNG BƯỚU CƠ SỞ 2").FontSize(11);
                            text.Span("\n"); // Thêm ngắt dòng
                            text.Span("KHOA CHẨN ĐOÁN HÌNH ẢNH").FontSize(11).Bold();
                        });

                        row.ConstantItem(80).AlignRight().Text("BM.CĐHA.04.01").FontSize(9);
                    });

                    page.Content().Column(col =>
                    {
                        col.Item().PaddingBottom(10)
                            .AlignCenter()
                            .Text(this.TenMau.ToUpper())
                            .FontSize(15)
                            .Bold();

                        col.Item().PaddingBottom(8).Text($"Họ và tên: {this.TenBN}   Năm sinh: {this.NamSinh}").FontSize(14);
                        col.Item().PaddingBottom(8).Text($"Được hẹn chụp MRI ngày: {this.NgayHen}  Giờ: {this.GioHen}").FontSize(14);

                        col.Item().PaddingBottom(8).Text("Chuẩn bị:").Underline().FontSize(14);


                        if (this.HuongDanImage.Count > 0)
                        {
                            foreach (var imageBytes in this.HuongDanImage)
                            {
                                if(imageBytes.Length > 0)
                                {
                                    col.Item().Image(imageBytes).FitWidth();
                                }
                            }
                        } else
                        {
                            col.Item().Text("•.. Không có hướng dẫn chuẩn bị.").FontSize(14);
                        }

                        col.Item().PaddingTop(10).Text($"Ngày {day} tháng {month} năm {year}").FontSize(12).AlignRight();
                        col.Item().PaddingTop(10).PaddingRight(22).Text("Người lập phiếu").FontSize(12).Bold().AlignRight();
                        col.Item().PaddingTop(6).PaddingRight(20).Text("Ký, ghi rõ họ tên").FontSize(12).Italic().AlignRight();
                    });
                });
            }
        }
    }
