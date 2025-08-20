using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SixOs_Test_2.Models.M0402.E0402
{
    [Table("QL_NoiDungHen")] 
    public class M0402NoiDungHen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }  

        [StringLength(500)]
        public string? TenMau { get; set; }   

        public string? HuongDan { get; set; } 

        [StringLength(50)]
        public string? MaLoaiCLS { get; set; } 

        public bool Active { get; set; } 
    }
}
