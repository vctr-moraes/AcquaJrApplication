function AbrirModalDataEvento(id, eventoId, data, horaInicio, horaEncerramento) {
    if (id == null && eventoId == null && data == null && horaInicio == null && horaEncerramento == null) {
        $('#modalDataEvento').modal();
        $('#data_Data').val("");
        $('#data_HoraInicio').val("");
        $('#data_HoraEncerramento').val("");
    } else {
        $('#modalDataEvento').modal();
        $('#data_Data').val(data);
        $('#data_HoraInicio').val(horaInicio);
        $('#data_HoraEncerramento').val(horaEncerramento);
    }
}

function IncluirDataEvento() {
    let requestVerificationToken = $("input[name='__RequestVerificationToken']").val();
    var evento = new Object();

    linha = document.getElementById('linhaData').value;
    var tabela = document.getElementById('lista-datas');

    if (linha > 0) {
        tabela.rows[linha].cells[1].children[0].value = $('#data_Id').val();
        tabela.rows[linha].cells[2].children[0].value = $('#data_EventoId').val();
        tabela.rows[linha].cells[3].children[0].value = $('#data_Data').val();
        tabela.rows[linha].cells[4].children[0].value = $('#data_HoraInicio').val();
        tabela.rows[linha].cells[5].children[0].value = $('#data_HoraEncerramento').val();
        $('#modalDataEvento').modal('hide');
    } else {
        evento.Id = 0;
        evento.EventoId = $('#data_EventoId').val();
        evento.Data = $('#data_Data').val();
        evento.HoraInicio = $('#data_HoraInicio').val();
        evento.HoraEncerramento = $('#data_HoraEncerramento').val();

        $.ajax({
            type: "POST",
            data: evento,
            url: '/Evento/IncluirDataEvento',
            headers: {
                "RequestVerificationToken": requestVerificationToken
            }
        }).done(function (data, statusText, xhdr) {
            $('#modalDataEvento').modal('hide');
            $('#datas-incluidas').append(data);
        }).fail(function (xhdr, statusText, errorText) {
            console.log("Failed: " + errorText);
        });
    }
}
