using System.ComponentModel.DataAnnotations;

namespace Domain.Dto
{
    public class CUSachDto
    {
        [Required(ErrorMessage = "Mã sách không được bỏ trống")]
        public string SMasach { get; set; } = null!;
        [Required(ErrorMessage = "Tên sách không được bỏ trống")]
        public string STensach { get; set; } = null!;

        public string? STenTg { get; set; }
        [Required(ErrorMessage = "Đơn giá không được bỏ trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Đơn giá phải lớn hơn 0")]
        public double IDongia { get; set; }
        [Required(ErrorMessage = "Số lượng không được bỏ trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int ISoluong { get; set; }

        public string? SNxb { get; set; }

        public string? STheloai { get; set; }
    }
}
