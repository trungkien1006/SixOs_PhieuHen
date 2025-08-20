using System.ComponentModel.DataAnnotations;

namespace SixOs_Test_2.Models.M0402.DTO0402
{
    public class DTO0402XuatPDFPhieuHenRequest
    {

        [Required]
        public int IDChiNhanh { get; set; }

        [Required]
        public int IDVaoVien  { get; set; }

        [Required]
        public string MaLoaiCLS { get; set; }

        [Required]
        public int IDNoiDungHen { get; set; }

    }
}
