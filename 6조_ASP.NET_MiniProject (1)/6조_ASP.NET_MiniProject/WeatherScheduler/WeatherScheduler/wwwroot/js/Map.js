var map;
var markers = []; // 마커 배열 선언

function initMap() {
    var seoul = { lat: 37.5642135, lng: 127.0016985 };
    map = new google.maps.Map(
        document.getElementById('map'), {
        zoom: 12,
        center: seoul
    });

    // 초기에 서울에 빨간색 마커 생성 및 추가
    var marker = new google.maps.Marker({
        position: seoul,
        map: map,
        label: "서울"
    });

    // 배열에 마커 추가
    markers.push(marker);
}

function showCity() {
    var cityName = document.getElementById('cityInput').value;
    var geocoder = new google.maps.Geocoder();

    geocoder.geocode({ 'address': cityName }, function (results, status) {
        if (status === 'OK') {
            var cityLocation = results[0].geometry.location;

            // 모든 기존 마커 제거
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(null);
            }

            // 새로운 마커 추가
            var marker = new google.maps.Marker({
                position: cityLocation,
                map: map,
                label: cityName
            });

            // 지도를 새로운 위치로 이동
            map.setCenter(cityLocation);

            // 새로운 마커 배열에 추가
            markers.push(marker);
        } else {
            alert('도시를 찾을 수 없습니다.');
        }
    });
}