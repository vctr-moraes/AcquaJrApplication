$(".orcamento").on("keyup", function () {
    if ($(this).attr("name") === "Orcamento") {
        return false;
    }

    let CustoMaoDeObra = $("#custo-mao-obra").val() == "" ? 0 : parseFloat($("#custo-mao-obra").val());
    let CustoProjeto = $("#custo-projeto").val() == "" ? 0 : parseFloat($("#custo-projeto").val());
    let CustoInsumos = $("#custo-insumos").val() == "" ? 0 : parseFloat($("#custo-insumos").val());
    let resultado = parseFloat(CustoMaoDeObra) + parseFloat(CustoProjeto) + parseFloat(CustoInsumos);
    resultado = resultado.toFixed(2);
    $("#orcamento").val(resultado);
});

$('.cep').mask('00000-000');

$('.selectpicker').selectpicker();

$('.formata-valor').mask('#.##0,00', { reverse: true });