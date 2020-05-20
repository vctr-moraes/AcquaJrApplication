function ValidarInputNumerico(e) {
    var tecla = (window.event) ? event.keyCode : e.which;

    if ((tecla > 47 && tecla < 58)) return true;
    else {
        if (tecla == 8 || tecla == 0 || tecla == 44) return true;
        else return false;
    }
}

$('#date-picker').pickdate({
    cancel: 'Limpar',
    closeOnCancel: false,
    closeOnSelect: true,
    container: 'body',
    containerHidden: 'body',
    firstDay: 1,
    format: 'dd/mm/yyyy',
    formatSubmit: 'dd/mmm/yyyy',
    hiddenPrefix: 'prefix_',
    hiddenSuffix: '_suffix',
    labelMonthNext: 'Próximo mês',
    labelMonthPrev: 'Mês anterior',
    labelMonthSelect: 'Selecionar o mês',
    labelYearSelect: 'Selecionar o ano',
    ok: 'Fechar',
    onClose: function () {
        console.log('Datepicker closes')
    },
    onOpen: function () {
        console.log('Datepicker opens')
    },
    selectMonths: true,
    selectYears: 10,
    today: 'Hoje'
});