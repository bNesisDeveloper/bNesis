//baseAPIAddress = "http://localhost:80/bNesisApiServer/api/"; //DEBUG ONLY

//baseAddress = "http://server2.bnesis.com/";
//baseAPIAddress = "http://server2.bnesis.com/bNesisApi/Api/";
//baseAPIAddressNoHTTPS = "https://server2.bnesis.com/bNesisApi/Api/";


function RESTCallWithNoParameters(absoluteUrl) {

    var asyncData = null;
    $.ajax({
        url: absoluteUrl,
        headers:
	    {
	    'Accept': 'application/json',
	    'Content-Type': 'application/json'
	    },
        async: false,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (data) {
            asyncData = data;
        },

        error: function (data, status, err) {
            if (data && data.status === 200 && data.responseText) {
                asyncData = data.responseText;
            }
            else {
                asyncData = err;
            }
    });

    return asyncData;
}

function RESTCallWithParameters(absoluteUrl, parameterData) {

    var asyncData = null;
    $.ajax({
        url: absoluteUrl,
        data: parameterData,
        async: false,
        type: "POST",
        contentType: false,
        dataType: "json",
        processData: false,
        success: function (data) {
            asyncData = data;
            console.log("success: " + asyncData);
        },

        error: function (data, status, err) {
            asyncData = err;
        }

    });

    return asyncData;
}


function httpGetHTML(addr) {
    $.ajax({
        url: baseAddress + addr,

        async: false,
        type: "GET",
        success: function (data) {
            asyncData = data;
        }

    });

    return asyncData;

}


function generateBoundary() {
    var MULTIPART_CHARS = "-_1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".split('');
    var buffer = '';
    for (var i = 1; i < 17; i++) {
        var rand = (Math.random() * (MULTIPART_CHARS.length - 0) + 0) | 0;
        buffer += (MULTIPART_CHARS[rand]);
    }
    return buffer;
};

function base64_decode(data) {


    var b64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
    var o1, o2, o3, h1, h2, h3, h4, bits, i = 0, enc = '';

    do {
        h1 = b64.indexOf(data.charAt(i++));
        h2 = b64.indexOf(data.charAt(i++));
        h3 = b64.indexOf(data.charAt(i++));
        h4 = b64.indexOf(data.charAt(i++));

        bits = h1 << 18 | h2 << 12 | h3 << 6 | h4;

        o1 = bits >> 16 & 0xff;
        o2 = bits >> 8 & 0xff;
        o3 = bits & 0xff;

        if (h3 === 64) enc += String.fromCharCode(o1);
        else if (h4 === 64) enc += String.fromCharCode(o1, o2);
        else enc += String.fromCharCode(o1, o2, o3);
    } while (i < data.length);

    return enc;
}

function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1];
        }
    }
    return ""; //no undefined just empty string
}


