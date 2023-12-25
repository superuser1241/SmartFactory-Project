using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WeatherScheduler.Models
{
    public class Weather
    {
        [Key]
        [Range(1, 15, ErrorMessage = "도시명을 1글자 이상 15 글자 미만으로 작성해주세요!")]
        [DisplayName("도시명")]
        public string Name { get; set; }

        [DisplayName("기온")]
        public double Temperature { get; set; }

        [DisplayName("날씨")]
        public string WeatherState { get; set; }

        [DisplayName("날짜")]
        public DateTime DateTime { get; set; }
    }
}
