// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// city_input 도시 이름 입력받는 부분에서의 문서의 요소를 선택
const cityInput = document.querySelector(".city-input");
// city_input 값 확인 버튼
const searchButton = document.querySelector(".search-btn");
// 현 위치 확인 버튼
const locationButton = document.querySelector(".location-btn");
// 날씨 정보 부분 div 전체 요소 부분
const currentWeatherDiv = document.querySelector(".current-weather");
// 카드들 요소
const weatherCardsDiv = document.querySelector(".weather-cards");

const API_KEY = "784506d5fd4069c8e18e519b3bb4b47f"; // OpenWeatherMap API 키

const createWeatherCard = (cityName, weatherItem, index) => {
    if (index === 0) { // 현재 날씨 정보
        return `<div class="details">
                    <h2>${cityName} (${weatherItem.dt_txt.split(" ")[0]})</h2>
                    <h6>Temperature: ${(weatherItem.main.temp - 273.15).toFixed(2)}°C</h6>
                    <h6>Wind: ${weatherItem.wind.speed} M/S</h6>
                    <h6>Humidity: ${weatherItem.main.humidity}%</h6>
                </div>`;
    } else { // 5일간 날씨 정보(카드)
        return `<li class="card">
                    <h3>(${weatherItem.dt_txt.split(" ")[0]})</h3>
                    <img src="https://openweathermap.org/img/wn/${weatherItem.weather[0].icon}@4x.png" alt="weather-icon">
                    <h6>Temp: ${(weatherItem.main.temp - 273.15).toFixed(2)}°C</h6>
                    <h6>Wind: ${weatherItem.wind.speed} M/S</h6>
                    <h6>Humidity: ${weatherItem.main.humidity}%</h6>
                </li>`;
    }
}

// 날씨 정보 가져오기
const getWeatherDetails = (cityName, latitude, longitude) => {
    const WEATHER_API_URL = `https://api.openweathermap.org/data/2.5/forecast?lat=${latitude}&lon=${longitude}&appid=${API_KEY}`;

    fetch(WEATHER_API_URL).then(response => response.json()).then(data => {
        const uniqueForecastDays = [];
        const fiveDaysForecast = data.list.filter(forecast => {
            const forecastDate = new Date(forecast.dt_txt).getDate();
            if (!uniqueForecastDays.includes(forecastDate)) {
                return uniqueForecastDays.push(forecastDate);
            }
        });

        // 이전 데이터 삭제
        cityInput.value = "";
        currentWeatherDiv.innerHTML = "";
        weatherCardsDiv.innerHTML = "";

        // 5일간 정보 바탕 날씨 카드 생성 (foreach)
        fiveDaysForecast.forEach((weatherItem, index) => {
            const html = createWeatherCard(cityName, weatherItem, index);
            if (index === 0) {
                currentWeatherDiv.insertAdjacentHTML("beforeend", html);
            } else {
                weatherCardsDiv.insertAdjacentHTML("beforeend", html);
            }
        });
    }).catch(() => {
        alert("날씨 정보를 가져오는 중 에러 발생!");
    });
}

// 좌표 가져오기
const getCityCoordinates = () => {
    const cityName = cityInput.value.trim();
    if (cityName === "") return;
    const API_URL = `https://api.openweathermap.org/geo/1.0/direct?q=${cityName}&limit=1&appid=${API_KEY}`;

    fetch(API_URL).then(response => response.json()).then(data => {
        if (!data.length) return alert(`${cityName}의 좌표를 찾을 수 없습니다.`);
        const { lat, lon, name } = data[0];
        getWeatherDetails(name, lat, lon);
    }).catch(() => {
        alert("좌표를 패치하는 과정에서 에러가 발생했습니다.");
    });
}

searchButton.addEventListener("click", getCityCoordinates);
cityInput.addEventListener("keyup", e => e.key === "Enter" && getCityCoordinates());