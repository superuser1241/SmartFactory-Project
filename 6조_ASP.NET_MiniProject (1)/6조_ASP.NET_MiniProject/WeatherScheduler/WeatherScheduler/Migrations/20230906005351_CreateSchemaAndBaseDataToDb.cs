using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WeatherScheduler.Migrations
{
    /// <inheritdoc />
    public partial class CreateSchemaAndBaseDataToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pwd = table.Column<int>(type: "int", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.No);
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    WeatherState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Name", "Latitude", "longitude" },
                values: new object[,]
                {
                    { "Ahmedabad", 23.022500000000001, 72.571399999999997 },
                    { "Anchorage", 61.2181, -149.90029999999999 },
                    { "Antalya ", 36.908099999999997, 30.695599999999999 },
                    { "Asuncion", -25.2637, -57.575899999999997 },
                    { "Athens", 37.983800000000002, 23.727499999999999 },
                    { "Austin", 30.267199999999999, -97.743099999999998 },
                    { "Bangalore", 12.9716, 77.5946 },
                    { "Bangkok", 13.7563, 100.5018 },
                    { "Beijing", 39.904200000000003, 116.4074 },
                    { "Belo Horizonte", -19.916699999999999, -43.9345 },
                    { "Berlin", 52.5244, 13.410500000000001 },
                    { "Bodrum ", 37.0383, 27.429200000000002 },
                    { "Bogota", 4.7108999999999996, -74.072100000000006 },
                    { "Boracay", 11.9801, 121.91930000000001 },
                    { "Brasilia", -15.780099999999999, -47.929200000000002 },
                    { "Buenos Aires", -34.611800000000002, -58.417299999999997 },
                    { "Cairo", 30.0444, 31.235700000000001 },
                    { "Calgary", 51.044699999999999, -114.0719 },
                    { "Cape Town", -33.924900000000001, 18.424099999999999 },
                    { "Caracas", 10.488, -66.879199999999997 },
                    { "Cebu", 10.333299999999999, 123.75 },
                    { "Chennai", 13.082700000000001, 80.270700000000005 },
                    { "ChiangMai", 18.790400000000002, 98.984700000000004 },
                    { "Chicago", 41.878100000000003, -87.629800000000003 },
                    { "DaLat", 11.9465, 108.4419 },
                    { "Dallas", 32.776699999999998, -96.796999999999997 },
                    { "DaNang", 16.067799999999998, 108.2208 },
                    { "Darkhan", 49.486699999999999, 105.9228 },
                    { "Delhi", 28.613900000000001, 77.209000000000003 },
                    { "Denver", 39.739199999999997, -104.9903 },
                    { "Edmonton", 53.544400000000003, -113.4909 },
                    { "Frankfurt ", 49.683300000000003, 10.533300000000001 },
                    { "Granada", 37.177300000000002, -3.5985999999999998 },
                    { "Guadalajara", 20.659700000000001, -103.3496 },
                    { "Guam", 13.4786, 144.81829999999999 },
                    { "Halifax", 44.648800000000001, -63.575200000000002 },
                    { "Hanoi", 21.0245, 105.8412 },
                    { "Ho Chi Minh City", 10.776899999999999, 106.7 },
                    { "Honolulu", 21.306899999999999, -157.85830000000001 },
                    { "Hyderabad", 17.385000000000002, 78.486699999999999 },
                    { "Ibiza", 38.908499999999997, 1.427 },
                    { "Istanbul", 41.013800000000003, 28.9497 },
                    { "Jakarta", -6.2088000000000001, 106.8456 },
                    { "Kharkhorin", 47.192500000000003, 102.8135 },
                    { "Kolkata", 22.572600000000001, 88.363900000000001 },
                    { "Kuala Lumpur", 3.1389999999999998, 101.68689999999999 },
                    { "Las Vegas", 36.169899999999998, -115.13979999999999 },
                    { "Lima", -12.0464, -77.0428 },
                    { "London", 51.507399999999997, -0.1278 },
                    { "LosAngeles", 34.052199999999999, -118.2437 },
                    { "Madrid", 40.416800000000002, -3.7038000000000002 },
                    { "Malaga", 36.7196, -4.4199999999999999 },
                    { "Manila", 14.599500000000001, 120.9842 },
                    { "Mexico City", 19.432600000000001, -99.133200000000002 },
                    { "Miami", 25.761700000000001, -80.191800000000001 },
                    { "Monterrey", 25.686599999999999, -100.31610000000001 },
                    { "Montevideo", -34.9011, -56.191000000000003 },
                    { "Montreal", 45.5017, -73.567300000000003 },
                    { "Moscow", 55.755800000000001, 37.617600000000003 },
                    { "Mumbai", 19.076000000000001, 72.877700000000004 },
                    { "Munich", 48.1374, 11.5755 },
                    { "New Orleans", 29.9511, -90.0715 },
                    { "NewYork", 56.25, -5.2832999999999997 },
                    { "Orlando", 28.5383, -81.379199999999997 },
                    { "Osaka", 34.6937, 135.50219999999999 },
                    { "Ottawa", 45.421500000000002, -75.690600000000003 },
                    { "Palma de Mallorca", 39.569600000000001, 2.6501999999999999 },
                    { "Paris", 48.8566, 2.3521999999999998 },
                    { "Phoenix", 33.448399999999999, -112.074 },
                    { "Phuket", 7.8906000000000001, 98.398099999999999 },
                    { "Portland", 45.505099999999999, -122.675 },
                    { "PulauUbin", 1.4118999999999999, 103.9639 },
                    { "Pune", 18.520399999999999, 73.856700000000004 },
                    { "Quebec City", 46.813899999999997, -71.207999999999998 },
                    { "Regina", 50.4452, -104.6189 },
                    { "Rio de Janeiro", -22.9068, -43.172899999999998 },
                    { "Rome", 41.902799999999999, 12.4964 },
                    { "San Antonio", 29.424099999999999, -98.493600000000001 },
                    { "San Diego", 32.715699999999998, -117.1611 },
                    { "SanFrancisco", 37.774900000000002, 122.4194 },
                    { "Santiago", -33.448900000000002, -70.669300000000007 },
                    { "Sao Paulo", -23.5505, -46.633299999999998 },
                    { "Sapporo", 43.066699999999997, 141.34999999999999 },
                    { "Saskatoon", 52.133200000000002, -106.67 },
                    { "Seattle", 47.606200000000001, -122.3321 },
                    { "Seoul", 37.566499999999998, 126.97799999999999 },
                    { "Shanghai", 31.230399999999999, 121.47369999999999 },
                    { "Singapore", 1.3521000000000001, 103.8198 },
                    { "Sydney", -33.865099999999998, 151.20930000000001 },
                    { "Tampines", 1.3581000000000001, 103.94029999999999 },
                    { "Tokyo", 35.689500000000002, 139.6917 },
                    { "Toronto", 43.651069999999997, -79.347014999999999 },
                    { "Ulaanbaatar", 47.907699999999998, 106.8832 },
                    { "Vancouver", 49.282699999999998, -123.1207 },
                    { "Winnipeg", 49.895099999999999, -97.138400000000004 },
                    { "Woodlands", 1.4379999999999999, 103.78879999999999 }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "ID", "NickName", "Pwd" },
                values: new object[] { 1, "Admin", 123456789 });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "No", "Content", "DateTime", "EndDateTime", "ID", "Title" },
                values: new object[,]
                {
                    { 1, "3박 4일 오사카 여행", new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "강동우", "오사카 여행" },
                    { 2, "5박6일 괌 여행", new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "안병길", "괌 여행" },
                    { 3, "4박5일 치앙마이 여행", new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "주영준", "치앙마이 여행" },
                    { 4, "6박7일 뉴욕 여행", new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "홍승현", "뉴욕 여행" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
