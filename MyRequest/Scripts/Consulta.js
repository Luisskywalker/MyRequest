window.onload = function () {
    ShowTableData();
    ShowdateLog();
}

function ShowTableData() {

    //fetch("Main/Lista")
    //.then(res => res.json())
    //.then(res => {
    //    alert(res)
    //    console.log(res);
    //})

    fetch("Lista")
        .then(res => res.json())
        .then(res => {
            alert(res)
            
            var contenido = "<table class='table table-striped shadow p-3 mb-5 bg-body rounded'>";
            contenido += "<tr>"
            contenido += "<th> ID </th>";
            contenido += "<th> Image </th>";
            contenido += "<th> Text </th>";
            contenido += "<th>  Date </th>";
            contenido += "</tr>";
            var fila;
            for (var i = 0; i < res.length; i++) {
                fila = res[i]
                var date = new Date(parseInt(fila.DateConverted.substr(6)));
                contenido += "<tr>";
                contenido += "<td>" + fila.Id + "</td>";
                contenido += "<td>" + fila.ImageName + "</td>";
                contenido += "<td>" + fila.ImageText + "</td>";
                //contenido += "<td>" + fila.DateConverted + "</td>";
                contenido += "<td>" + date+ "</td>";
                contenido += "</tr>";
            }
            contenido += "</table>"
            document.getElementById("Divtabla").innerHTML = contenido;

        })


}

function ShowdateLog() {
     fetch("Lista")
     .then(res => res.json())
        .then(res => {
            var fila;

            
            for (var i = 0; i < res.length; i++) {
                fila = res[i]
                var date = new Date(parseInt(fila.DateConverted.substr(6)));
                console.log(date);
            }
        })
}