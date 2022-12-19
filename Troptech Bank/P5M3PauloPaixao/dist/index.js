var _this = this;
var contas = [];
contas.push(new Conta(12341, "0420", "12345678901", TipoConta.Corrente));
contas.push(new Conta(12342, "0430", "12345678902", TipoConta.Pupanca));
contas.push(new Conta(12343, "0440", "12345678903", TipoConta.Corrente));
contas.push(new Conta(12344, "0450", "12345678904", TipoConta.Pupanca));
var listarContas = function () {
    var tbody = document.getElementById("listaContas");
    for (var i = 0; i < contas.length; i++) {
        var tr = tbody.insertRow();
        var td_NumeroConta = tr.insertCell();
        var td_AgenciaConta = tr.insertCell();
        var td_TipoConta = tr.insertCell();
        var td_CpfConta = tr.insertCell();
        var td_SaldoConta = tr.insertCell();
        td_NumeroConta.textContent = "".concat(contas[i].getNumero());
        td_AgenciaConta.textContent = "".concat(contas[i].getAgencia());
        td_TipoConta.textContent = "".concat(contas[i].getTipo());
        td_CpfConta.textContent = "".concat(contas[i].getCpf());
        td_SaldoConta.textContent = "R$ ".concat(contas[i].getSaldo());
    }
};
listarContas();
var formulario = document.getElementById("formContas");
var enviaForm = function (event) {
    event.preventDefault();
    var operacao = document.getElementById("tipo");
    var numeroConta = document.getElementById("numero");
    var valor = document.getElementById("valor");
    var message = document.getElementById("message");
    switch (operacao.value) {
        case "1":
            message.textContent = validaSaque(Number(numeroConta.value), Number(valor.value));
            _this.reset();
            break;
        case "2":
            message.textContent = validaDeposito(Number(numeroConta.value), Number(valor.value));
            break;
        default:
            message.classList.remove("success");
            message.classList.add("error");
            message.textContent = "Não encontramos esta operação";
            break;
    }
};
formulario.addEventListener("submit", enviaForm);
var validaSaque = function (numeroConta, valor) {
    var contaEncontrada = contas.filter(function (conta) { return conta.getNumero() == numeroConta; });
    var message = document.getElementById("message");
    if (contaEncontrada.length > 0) {
        if (contaEncontrada[0].getSaldo() >= valor.toFixed(2)) {
            contaEncontrada[0].sacar(valor);
            document.getElementById("listaContas").innerHTML = '';
            listarContas();
            message.classList.remove("error");
            message.classList.add("success");
            return "Saque realizado com sucesso.";
        }
        else {
            message.classList.remove("success");
            message.classList.add("error");
            return "Ops, o saldo é insuficiente.";
        }
    }
    else {
        message.classList.remove("success");
        message.classList.add("error");
        return "Ops, a conta não foi encontrada.";
    }
};
var validaDeposito = function (numeroConta, valor) {
    var contaEncontrada = contas.filter(function (conta) { return conta.getNumero() == numeroConta; });
    var message = document.getElementById("message");
    if (contaEncontrada.length > 0) {
        if (valor > 0) {
            contaEncontrada[0].depositar(valor);
            document.getElementById("listaContas").innerHTML = '';
            listarContas();
            message.classList.remove("error");
            message.classList.add("success");
            return "Depósito realizado realizado com sucesso.";
        }
        else {
            message.classList.remove("success");
            message.classList.add("error");
            return "Ops, o valor para depósito é insuficiente.";
        }
    }
    else {
        message.classList.remove("success");
        message.classList.add("error");
        return "Ops, a conta não foi encontrada.";
    }
};
