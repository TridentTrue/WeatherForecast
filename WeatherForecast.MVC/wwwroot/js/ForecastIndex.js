import PullToRefresh from "../lib/pulltorefreshjs/dist/index.esm.js"

function ReloadForecast() {
	// display loader
	const loader = document.getElementById("loader");
	loader.style.visibility = "visible";

	// attempt to reload the ViewComponent
	fetch(Url_FiveDayForecast).then(function (response) {
		// fetch successful, return html string
		return response.text();
	}).then(function (html) {
		// set wrapper as html
		document.getElementById("forecast-wrapper").innerHTML = html;
	}).catch(function (err) {
		// display the error if there is one
		alert("error: reload unsuccessful", err);
	}).finally(function () {
		// remove the loader
		loader.style.visibility = "hidden";
	});
}

// button for desktop users
document.getElementById("reload").addEventListener("click", ReloadForecast);

// from https://github.com/BoxFactura/pulltorefresh.js
const ptr = PullToRefresh.init({
	mainElement: "body",
	onRefresh() {
		ReloadForecast();
	}
});