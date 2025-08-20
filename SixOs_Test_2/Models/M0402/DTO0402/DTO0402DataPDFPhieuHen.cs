using System.ComponentModel.DataAnnotations;

namespace SixOs_Test_2.Models.M0402.DTO0402
{
    public class DTO0402DataPDFPhieuHen
    {
        [Required]
        [StringLength(500)]
        public string TenMau { get; set; }

        [Required]
        [StringLength(500)]
        public string TenBN { get; set; }

        [Required]
        public int NamSinh { get; set; }

        [Required]
        public DateOnly NgayHen { get; set; }

        [Required]
        public TimeOnly GioHen { get; set; }

        [Required]
        public string HuongDan { get; set; }
    }
}
