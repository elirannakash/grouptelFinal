function httpGetAsync(url, callback) {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState === 4 && xmlHttp.status === 200)
            callback(xmlHttp.responseText);
    }
    xmlHttp.open("GET", url, true); // true for asynchronous
    xmlHttp.send(null);
}

var url = "https://emailvalidation.abstractapi.com/v1/?api_key=672f08755f0843f5a31924d2b7156b2e&email=elirannakash7@gmail.com"

httpGetAsync(url)