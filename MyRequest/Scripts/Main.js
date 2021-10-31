const { post } = require("jquery");



function SaveData() {

    fetch("InsertaDatos", {
        method: "POST"
    })
        .then(res => res.text())
        .then(res => {
            console.log(res);
            alert(res);
        })
}