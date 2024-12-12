// const params = new URLSearchParams(window.location.search);

// const newURL = `/wiki.html?wiki=${encodeURIComponent("games")}&article=${encodeURIComponent(
// 	"valorant"
// )}`;

// window.history.pushState(null, "", newURL);

// console.log(params);

fetch(`https://localhost:7177/WeatherForecast`, {
	method: "GET",
})
	.then((res) => res.json())
	.then((data) => {
		console.log(data);
	});
