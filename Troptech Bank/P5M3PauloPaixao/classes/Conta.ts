class Conta {

    private _numero: number;
    private _agencia: string;
    private _cpf: string;
    private _saldo: number;
    private _tipo: TipoConta;

    constructor(numero: number, agencia: string, cpf: string, tipo: TipoConta) {

        this._numero = numero;
        this._agencia = agencia;
        this._cpf = cpf;
        this._saldo = 0;
        this._tipo = tipo;
        this.setSaldoTotal();

    }

    private setSaldoTotal() {
        (this._tipo === 1) ? this._saldo += 200 : this._saldo += 0;
    }

    sacar(valor: number): number {
        return this._saldo -= valor;
    };

    depositar(valor: number): number {
        return this._saldo += valor;
    };

    getNumero() {
        return this._numero;
    }

    getAgencia() {
        return this._agencia;
    }

    getTipo() {
        return (this._tipo === 1) ? "Corrente" : "Poupança";
    }

    getCpf() {
        return this._cpf;
    }

    getSaldo() {
        return this._saldo.toFixed(2);
    }

}