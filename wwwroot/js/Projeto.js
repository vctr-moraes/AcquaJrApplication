$(".orcamento").on("keyup", function () {
    var ponto = /\./g;
    var virgula = /\,/g;

    let CustoMaoDeObra = $("#custo-mao-obra").val() == "" ? 0 : parseFloat($("#custo-mao-obra").val().replace(ponto, "").replace(virgula, "."));
    let CustoProjeto = $("#custo-projeto").val() == "" ? 0 : parseFloat($("#custo-projeto").val().replace(ponto, "").replace(virgula, "."));
    let CustoInsumos = $("#custo-insumos").val() == "" ? 0 : parseFloat($("#custo-insumos").val().replace(ponto, "").replace(virgula, "."));
    let resultado = 0;

    resultado = CustoMaoDeObra + CustoProjeto + CustoInsumos;
    $("#orcamento").val(resultado.toLocaleString("pt-BR", { style: "currency", currency: "BRL" }).replace("R$", "").trim());
});

$('.cep').mask('00000-000');

$('.selectpicker').selectpicker();

$('.formata-valor').mask('#.##0,00', { reverse: true });
