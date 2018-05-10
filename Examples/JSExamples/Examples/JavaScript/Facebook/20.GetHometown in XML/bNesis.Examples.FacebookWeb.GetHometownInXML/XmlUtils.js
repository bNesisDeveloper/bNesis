json2Xml = function (obj, xmldoc, node) {
    var root = false;
    if (!node || !xmldoc) {
        var markup = '<?xml version="1.0" ?>' + '<root></root>';
        xmldoc = new DOMParser().parseFromString(markup, "text/xml");
        node = xmldoc.documentElement;
        node.setAttribute('type', 'object');
        root = true;
    }

    if (Array.isArray(obj)) {
        node.setAttribute('type', 'array');
        for (var i = 0; i < obj.length; i++) {
            node.appendChild(json2Xml(obj[i], xmldoc, xmldoc.createElement('item')));
        }
    }
    else {
        var typeObj = typeof obj;
        if (typeObj === 'string' || typeObj === 'number' || typeObj === 'boolean') {
            node.setAttribute('type', typeObj);
            var textNode = xmldoc.createTextNode(obj)
            node.appendChild(textNode);
        }
        else {
            node.setAttribute('type', 'object');
            for (var x in obj) {
                if (obj.hasOwnProperty(x)) {
                    node.appendChild(json2Xml(obj[x], xmldoc, xmldoc.createElement(x)));
                }
            }
        }
    }

    if (root == true) {
        return xmldoc;
    }
    else {
        return node;
    }
};

function formatXml(xml) {
    var formatted = '';
    var reg = /(>)(<)(\/*)/g;
    xml = xml.replace(reg, '$1\r\n$2$3');
    var pad = 0;
    jQuery.each(xml.split('\r\n'), function (index, node) {
        var indent = 0;
        if (node.match(/.+<\/\w[^>]*>$/)) {
            indent = 0;
        } else if (node.match(/^<\/\w/)) {
            if (pad != 0) {
                pad -= 1;
            }
        } else if (node.match(/^<\w[^>]*[^\/]>.*$/)) {
            indent = 1;
        } else {
            indent = 0;
        }

        var padding = '';
        for (var i = 0; i < pad; i++) {
            padding += '  ';
        }

        formatted += padding + node + '\r\n';
        pad += indent;
    });

    return formatted;
};