﻿$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

$(".input-numerico").keypress(function (e) {
    let tecla = (window.event) ? event.keyCode : e.which;

    if ((tecla > 47 && tecla < 58)) return true;
    else {
        if (tecla == 8 || tecla == 0 || tecla == 44) return true;
        else return false;
    }
});
