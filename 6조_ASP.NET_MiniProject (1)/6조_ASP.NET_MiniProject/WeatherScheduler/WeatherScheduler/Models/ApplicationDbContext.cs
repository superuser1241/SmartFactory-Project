using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace WeatherScheduler.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Member> Members { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Weather> Weathers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        [Key]
        public int No { get; set; }
        public string ID { get; set; }  
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(
                new Member { ID = 1, Pwd = 123456789, NickName = "Admin" }
                );

            modelBuilder.Entity<City>().HasData(
                new City { Name = "Tokyo", Latitude = 35.6895, longitude = 139.6917 },
                new City { Name = "Osaka", Latitude = 34.6937, longitude = 135.5022 },
                new City { Name = "Sapporo", Latitude = 43.0667, longitude = 141.35 },
                new City { Name = "LosAngeles", Latitude = 34.0522, longitude = -118.2437 },
                new City { Name = "NewYork", Latitude = 56.25, longitude = -5.2833 },
                new City { Name = "SanFrancisco", Latitude = 37.7749, longitude = 122.4194 },
                new City { Name = "DaNang", Latitude = 16.0678, longitude = 108.2208 },
                new City { Name = "DaLat", Latitude = 11.9465, longitude = 108.4419 },
                new City { Name = "Hanoi", Latitude = 21.0245, longitude = 105.8412 },
                new City { Name = "ChiangMai", Latitude = 18.7904, longitude = 98.9847 },
                new City { Name = "Phuket", Latitude = 7.8906, longitude = 98.3981 },
                new City { Name = "Boracay", Latitude = 11.9801, longitude = 121.9193 },
                new City { Name = "Cebu", Latitude = 10.3333, longitude = 123.75 },
                new City { Name = "PulauUbin", Latitude = 1.4119, longitude = 103.9639 },
                new City { Name = "Woodlands", Latitude = 1.438, longitude = 103.7888 },
                new City { Name = "Tampines", Latitude = 1.3581, longitude = 103.9403 },
                new City { Name = "Guam", Latitude = 13.4786, longitude = 144.8183 },
                new City { Name = "Ulaanbaatar", Latitude = 47.9077, longitude = 106.8832 },
                new City { Name = "Darkhan", Latitude = 49.4867, longitude = 105.9228 },
                new City { Name = "Kharkhorin", Latitude = 47.1925, longitude = 102.8135 },
                new City { Name = "Berlin", Latitude = 52.5244, longitude = 13.4105 },
                new City { Name = "Munich", Latitude = 48.1374, longitude = 11.5755 },
                new City { Name = "Frankfurt ", Latitude = 49.6833, longitude = 10.5333 },
                new City { Name = "Istanbul", Latitude = 41.0138, longitude = 28.9497 },
                new City { Name = "Antalya ", Latitude = 36.9081, longitude = 30.6956 },
                new City { Name = "Bodrum ", Latitude = 37.0383, longitude = 27.4292 },
                new City { Name = "Paris", Latitude = 48.8566, longitude = 2.3522 },
                new City { Name = "London", Latitude = 51.5074, longitude = -0.1278 },
                new City { Name = "Rome", Latitude = 41.9028, longitude = 12.4964 },
                new City { Name = "Madrid", Latitude = 40.4168, longitude = -3.7038 },
                new City { Name = "Sydney", Latitude = -33.8651, longitude = 151.2093 },
                new City { Name = "Rio de Janeiro", Latitude = -22.9068, longitude = -43.1729 },
                new City { Name = "Cairo", Latitude = 30.0444, longitude = 31.2357 },
                new City { Name = "Bangkok", Latitude = 13.7563, longitude = 100.5018 },
                new City { Name = "Seoul", Latitude = 37.5665, longitude = 126.9780 },
                new City { Name = "Beijing", Latitude = 39.9042, longitude = 116.4074 },
                new City { Name = "Shanghai", Latitude = 31.2304, longitude = 121.4737 },
                new City { Name = "Moscow", Latitude = 55.7558, longitude = 37.6176 },
                new City { Name = "Athens", Latitude = 37.9838, longitude = 23.7275 },
                new City { Name = "Cape Town", Latitude = -33.9249, longitude = 18.4241 },
                new City { Name = "Toronto", Latitude = 43.651070, longitude = -79.347015 },
                new City { Name = "Vancouver", Latitude = 49.2827, longitude = -123.1207 },
                new City { Name = "Chicago", Latitude = 41.8781, longitude = -87.6298 },
                new City { Name = "San Diego", Latitude = 32.7157, longitude = -117.1611 },
                new City { Name = "Dallas", Latitude = 32.7767, longitude = -96.7970 },
                new City { Name = "Miami", Latitude = 25.7617, longitude = -80.1918 },
                new City { Name = "Orlando", Latitude = 28.5383, longitude = -81.3792 },
                new City { Name = "New Orleans", Latitude = 29.9511, longitude = -90.0715 },
                new City { Name = "Las Vegas", Latitude = 36.1699, longitude = -115.1398 },
                new City { Name = "San Antonio", Latitude = 29.4241, longitude = -98.4936 },
                new City { Name = "Austin", Latitude = 30.2672, longitude = -97.7431 },
                new City { Name = "Denver", Latitude = 39.7392, longitude = -104.9903 },
                new City { Name = "Phoenix", Latitude = 33.4484, longitude = -112.0740 },
                new City { Name = "Portland", Latitude = 45.5051, longitude = -122.6750 },
                new City { Name = "Seattle", Latitude = 47.6062, longitude = -122.3321 },
                new City { Name = "Honolulu", Latitude = 21.3069, longitude = -157.8583 },
                new City { Name = "Anchorage", Latitude = 61.2181, longitude = -149.9003 },
                new City { Name = "Montreal", Latitude = 45.5017, longitude = -73.5673 },
                new City { Name = "Quebec City", Latitude = 46.8139, longitude = -71.2080 },
                new City { Name = "Halifax", Latitude = 44.6488, longitude = -63.5752 },
                new City { Name = "Ottawa", Latitude = 45.4215, longitude = -75.6906 },
                new City { Name = "Winnipeg", Latitude = 49.8951, longitude = -97.1384 },
                new City { Name = "Regina", Latitude = 50.4452, longitude = -104.6189 },
                new City { Name = "Saskatoon", Latitude = 52.1332, longitude = -106.6700 },
                new City { Name = "Calgary", Latitude = 51.0447, longitude = -114.0719 },
                new City { Name = "Edmonton", Latitude = 53.5444, longitude = -113.4909 },
                new City { Name = "Mexico City", Latitude = 19.4326, longitude = -99.1332 },
                new City { Name = "Santiago", Latitude = -33.4489, longitude = -70.6693 },
                new City { Name = "Lima", Latitude = -12.0464, longitude = -77.0428 },
                new City { Name = "Bogota", Latitude = 4.7109, longitude = -74.0721 },
                new City { Name = "Caracas", Latitude = 10.4880, longitude = -66.8792 },
                new City { Name = "Sao Paulo", Latitude = -23.5505, longitude = -46.6333 },
                new City { Name = "Buenos Aires", Latitude = -34.6118, longitude = -58.4173 },
                new City { Name = "Brasilia", Latitude = -15.7801, longitude = -47.9292 },
                new City { Name = "Belo Horizonte", Latitude = -19.9167, longitude = -43.9345 },
                new City { Name = "Monterrey", Latitude = 25.6866, longitude = -100.3161 },
                new City { Name = "Guadalajara", Latitude = 20.6597, longitude = -103.3496 },
                new City { Name = "Montevideo", Latitude = -34.9011, longitude = -56.1910 },
                new City { Name = "Asuncion", Latitude = -25.2637, longitude = -57.5759 },
                new City { Name = "Mumbai", Latitude = 19.0760, longitude = 72.8777 },
                new City { Name = "Delhi", Latitude = 28.6139, longitude = 77.2090 },
                new City { Name = "Kolkata", Latitude = 22.5726, longitude = 88.3639 },
                new City { Name = "Bangalore", Latitude = 12.9716, longitude = 77.5946 },
                new City { Name = "Chennai", Latitude = 13.0827, longitude = 80.2707 },
                new City { Name = "Hyderabad", Latitude = 17.3850, longitude = 78.4867 },
                new City { Name = "Pune", Latitude = 18.5204, longitude = 73.8567 },
                new City { Name = "Ahmedabad", Latitude = 23.0225, longitude = 72.5714 },
                new City { Name = "Kuala Lumpur", Latitude = 3.1390, longitude = 101.6869 },
                new City { Name = "Singapore", Latitude = 1.3521, longitude = 103.8198 },
                new City { Name = "Jakarta", Latitude = -6.2088, longitude = 106.8456 },
                new City { Name = "Manila", Latitude = 14.5995, longitude = 120.9842 },
                new City { Name = "Ho Chi Minh City", Latitude = 10.7769, longitude = 106.700 },
                new City { Name = "Granada", Latitude = 37.1773, longitude = -3.5986 },
                new City { Name = "Malaga", Latitude = 36.7196, longitude = -4.4200 },
                new City { Name = "Palma de Mallorca", Latitude = 39.5696, longitude = 2.6502 },
                new City { Name = "Ibiza", Latitude = 38.9085, longitude = 1.4270 }


                );

            modelBuilder.Entity<Schedule>().HasData(
                new Schedule { No = 1, ID = "강동우", Title = "오사카 여행", Content = "3박 4일 오사카 여행", DateTime = new DateTime(2023, 9, 4), EndDateTime = new DateTime(2023, 9, 6) },
                new Schedule { No = 2, ID = "안병길", Title = "괌 여행", Content = "5박6일 괌 여행", DateTime = new DateTime(2023, 9, 12), EndDateTime = new DateTime(2023, 9, 17) },
                new Schedule { No = 3, ID = "주영준", Title = "치앙마이 여행", Content = "4박5일 치앙마이 여행", DateTime = new DateTime(2023, 9, 19), EndDateTime = new DateTime(2023, 9, 23) },
                new Schedule { No = 4, ID = "홍승현", Title = "뉴욕 여행", Content = "6박7일 뉴욕 여행", DateTime = new DateTime(2023, 10, 2), EndDateTime = new DateTime(2023, 10, 8) }

                );
        }
    }
}
