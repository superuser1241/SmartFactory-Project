using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WeatherScheduler.Models
{
    public class City
    {
        [Key]
        [ForeignKey("Wheather")]
        [Range(1, 15, ErrorMessage = "도시명을 1글자 이상 15 글자 미만으로 작성해주세요!")]
        [DisplayName("도시명")]
        public string Name { get; set; }

        [DisplayName("위도")]
        public double Latitude { get; set; }

        [DisplayName("경도")]
        public double longitude { get; set; }
    }
}
