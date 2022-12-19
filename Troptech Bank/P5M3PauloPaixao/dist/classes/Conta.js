var Conta = /** @class */ (function () {
    function Conta(numero, agencia, cpf, tipo) {
        this._numero = numero;
        this._agencia = agencia;
        this._cpf = cpf;
        this._saldo = 0;
        this._tipo = tipo;
        this.setSaldoTotal();
    }
    Conta.prototype.setSaldoTotal = function () {
        (this._tipo === 1) ? this._saldo += 200 : this._saldo += 0;
    };
    Conta.prototype.sacar = function (valor) {
        return this._saldo -= valor;
    };
    ;
    Conta.prototype.depositar = function (valor) {
        return this._saldo += valor;
    };
    ;
    Conta.prototype.getNumero = function () {
        return this._numero;
    };
    Conta.prototype.getAgencia = function () {
        return this._agencia;
    };
    Conta.prototype.getTipo = function () {
        return (this._tipo === 1) ? "Corrente" : "Poupança";
    };
    Conta.prototype.getCpf = function () {
        return this._cpf;
    };
    Conta.prototype.getSaldo = function () {
        return this._saldo.toFixed(2);
    };
    return Conta;
}());
