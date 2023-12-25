using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WeatherScheduler.Models
{
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("식별번호")]
        public int No { get; set; }

        [Required]
        [ForeignKey("Member")]
        [DisplayName("작성자")]
        public string ID { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "20자 미만으로 입력해주세요!")]
        [DisplayName("스케줄 제목")]
        public string Title { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "300자 미만으로 입력해주세요!")]
        [DisplayName("스케줄 내용")]
        public string Content { get; set; }

        [DisplayName("시작 날짜")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTime { get; set; }
        [DisplayName("종료 날짜")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDateTime { get; set; }
    }
}
