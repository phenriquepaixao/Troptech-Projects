var contas: Conta[] = [];

contas.push(new Conta(12341, "0420", "12345678901", TipoConta.Corrente));
contas.push(new Conta(12342, "0430", "12345678902", TipoConta.Pupanca));
contas.push(new Conta(12343, "0440", "12345678903", TipoConta.Corrente));
contas.push(new Conta(12344, "0450", "12345678904", TipoConta.Pupanca));

const listarContas = () => {

    let tbody: HTMLTableSectionElement = document.getElementById("listaContas") as HTMLTableSectionElement;

    for (let i = 0; i < contas.length; i++) {
        let tr: HTMLTableRowElement = tbody.insertRow() as HTMLTableRowElement;

        let td_NumeroConta: HTMLTableCellElement = tr.insertCell();
        let td_AgenciaConta: HTMLTableCellElement = tr.insertCell();
        let td_TipoConta: HTMLTableCellElement = tr.insertCell();
        let td_CpfConta: HTMLTableCellElement = tr.insertCell();
        let td_SaldoConta: HTMLTableCellElement = tr.insertCell();

        td_NumeroConta.textContent = `${contas[i].getNumero()}`;
        td_AgenciaConta.textContent = `${contas[i].getAgencia()}`;
        td_TipoConta.textContent = `${contas[i].getTipo()}`;
        td_CpfConta.textContent = `${contas[i].getCpf()}`;
        td_SaldoConta.textContent = `R$ ${contas[i].getSaldo()}`;
    }

}

listarContas();


var formulario: HTMLFormElement = document.getElementById("formContas") as HTMLFormElement;


const enviaForm = (event: Event) => {

    event.preventDefault();

    let operacao: HTMLSelectElement = document.getElementById("tipo") as HTMLSelectElement;
    let numeroConta: HTMLInputElement = document.getElementById("numero") as HTMLInputElement;
    let valor: HTMLInputElement = document.getElementById("valor") as HTMLInputElement;

    let message = document.getElementById("message");

    switch (operacao.value) {
        case "1":
            message.textContent = validaSaque(Number(numeroConta.value), Number(valor.value))
            break;
        case "2":
            message.textContent = validaDeposito(Number(numeroConta.value), Number(valor.value))
            break;

        default:
            message.classList.remove("success");
            message.classList.add("error");
            message.textContent = "Não encontramos esta operação"
            break;
    }

}

formulario.addEventListener("submit", enviaForm)


const validaSaque = (numeroConta: number, valor: number): string => {

    let contaEncontrada = contas.filter(conta => conta.getNumero() == numeroConta)
    let message = document.getElementById("message");

    if (contaEncontrada.length > 0) {

        if (contaEncontrada[0].getSaldo() >= valor.toFixed(2)) {
            contaEncontrada[0].sacar(valor);

            document.getElementById("listaContas").innerHTML = '';

            listarContas();

            message.classList.remove("error");
            message.classList.add("success");

            return "Saque realizado com sucesso."

        } else {

            message.classList.remove("success");
            message.classList.add("error");

            return "Ops, o saldo é insuficiente."

        }

    } else {

        message.classList.remove("success");
        message.classList.add("error");

        return "Ops, a conta não foi encontrada."

    }
}


const validaDeposito = (numeroConta: number, valor: number): string => {

    let contaEncontrada = contas.filter(conta => conta.getNumero() == numeroConta)
    let message = document.getElementById("message");

    if (contaEncontrada.length > 0) {

        if (valor > 0) {

            contaEncontrada[0].depositar(valor);

            document.getElementById("listaContas").innerHTML = '';

            listarContas();

            message.classList.remove("error");
            message.classList.add("success");

            return "Depósito realizado realizado com sucesso."

        } else {

            message.classList.remove("success");
            message.classList.add("error");

            return "Ops, o valor para depósito é insuficiente."
        }

    } else {
        message.classList.remove("success");
        message.classList.add("error");

        return "Ops, a conta não foi encontrada."

    }
}


