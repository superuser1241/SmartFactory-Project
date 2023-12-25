using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WeatherScheduler.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(1, 15, ErrorMessage = "아이디를 1글자 이상 15 글자 미만으로 작성해주세요!")]
        [DisplayName("아이디")]
        public int ID { get; set; }

        [Required]
        [Range(8, 20, ErrorMessage = "비밀번호를 8글자 이상 20 글자 미만으로 작성해주세요!")]
        [DisplayName("비밀번호")]
        public int Pwd { get; set; }

        [Required]
        [DisplayName("닉네임")]
        [MaxLength(10, ErrorMessage = "10글자 미만으로 작성해주세요")]
        public string NickName { get; set; }
    }
}
