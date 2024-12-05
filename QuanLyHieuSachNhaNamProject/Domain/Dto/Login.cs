using System.ComponentModel.DataAnnotations;

namespace Domain.Dto
{
    public class Login
    {
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống")]
        public string SMaNv { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string SMatkhau { get; set; }
    }
}
