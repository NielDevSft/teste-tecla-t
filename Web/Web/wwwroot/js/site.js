function getApisJson() {
    var apis = [];
    $.getJSON("../../endpoints.json", function () {
        //console.log("succes");
    }).done(function (data) {
        $.each(data, function (key, val) {
            apis.push({ key, val });
        })
    }).fail(function () {
        //console.error("deu ruim");
    }).always(function () {
        //console.log("complete")
    });
    return apis;

}

let services = ['../js/services/MateriaisService.js',
];
for (let i = 0; i < services.length; i++) {
    let ser = services[i];
    var imported = document.createElement('script');
    imported.src = ser;
    document.head.appendChild(imported);
}