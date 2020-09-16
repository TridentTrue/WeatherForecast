document.getElementById("reload").addEventListener('click', ReloadForecast);

function ReloadForecast() {
	fetch(Url_FiveDayForecast).then(function (response) {
		// fetch successful, return html string
		return response.text();
	}).then(function (html) {
		// set wrapper as html
		document.getElementById("forecast-wrapper").innerHTML = html;
	}).catch(function (err) {
		alert("error: reload unsuccessful", err);
	});
}