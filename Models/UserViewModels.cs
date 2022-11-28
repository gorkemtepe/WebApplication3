using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string Username { get; set; }
        public bool Locked { get; set; } = false;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string? ProfileImageFileName { get; set; } = "no-image.jpg";
        public string Role { get; set; } = "user";
    }

    public class CreateUserModel
    {
        [Required(ErrorMessage = "Kullanıcı adı girin")]
        [StringLength(30, ErrorMessage = "kullanıcı adı 30 karekter olabilir en fazla")]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        public bool Locked { get; set; }

        [Required(ErrorMessage = "Parola girin")]
        [MinLength(6, ErrorMessage = "En az 6 karekter olmalıdır")]
        [MaxLength(16, ErrorMessage = "En fazla 16 karekter olabilir")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Parola zorunludur")]
        [MinLength(6, ErrorMessage = "En az 6 karekter olmalıdır")]
        [MaxLength(16, ErrorMessage = "En fazla 16 karekter olabilir")]
        [Compare(nameof(Password), ErrorMessage = "Parolalar aynı değil.")]
        public string RePassword { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";

        public string? Done { get; set; }
    }

    public class EditUserModel
    {
        [Required(ErrorMessage = "Kullanıcı adı girin")]
        [StringLength(30, ErrorMessage = "kullanıcı adı 30 karekter olabilir en fazla")]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        public bool Locked { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";
    }
}
