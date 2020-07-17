$("#TipoPessoa").change(function () {
    if ($("#TipoPessoa option:selected").val() == "1") {
        $(".cpf").prop("disabled", false);
        $(".cnpj").prop("disabled", true);
        $(".cnpj").val("");
    } else {
        $(".cpf").prop("disabled", true);
        $(".cnpj").prop("disabled", false);
        $(".cpf").val("");
    }
});
