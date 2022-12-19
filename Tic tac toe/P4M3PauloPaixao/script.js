var tabuleiro = document.getElementById("tabuleiro")
var celulas = document.querySelectorAll("#celula");
var botaoReiniciar = document.querySelector(".mensagem a")

var filaJogadas = new Array(9)

const fazerJogada = (event) => {

  let celulaFocada = event.target;

  let idCelulaFocada = celulaFocada.getAttribute("numero-celula");

  let tecla = event.key.toUpperCase();

  /* BUSCANDO IMAGEM FILHA DE CELULA (XIS OU BOLINHA) */
  const xis = celulaFocada.querySelector("#xis");
  const bolinha = celulaFocada.querySelector("#bolinha");

  switch (tecla) {
    case "X":
      if (xis == null && bolinha == null) {
        filaJogadas[idCelulaFocada] = "X";
        celulaFocada.appendChild(criaXis())
        celulaFocada.classList.add("mouse-bloq");
      }
      break;

    case "O":
      if (xis == null && bolinha == null) {
        filaJogadas[idCelulaFocada] = "O";
        celulaFocada.appendChild(criaBolinha())
        celulaFocada.classList.add("mouse-bloq");
      }
      break;
  }
  verificaResultado()
}



const criaXis = () => {
  let imgX = document.createElement("img")
  imgX.setAttribute("src", "imagens/x-solid.svg");
  imgX.setAttribute("class", "xis");
  imgX.setAttribute("id", "xis")

  return imgX
}


const criaBolinha = () => {
  let imgO = document.createElement("img")
  imgO.setAttribute("src", "imagens/circle-regular.svg");
  imgO.setAttribute("class", "bolinha");
  imgO.setAttribute("id", "bolinha")

  return imgO
}


const verificaEmpate = () => {
  let celulasPreenchidas = 0;

  for (var i = 0; i < filaJogadas.length; i++) {
    if (filaJogadas[i] != undefined)
      celulasPreenchidas++;
  }

  if (celulasPreenchidas == filaJogadas.length) {
    return "empate"
  }
}


const verificaSeLinhaGanhou = () => {

  for (var i = 0; i < 7; i += 3) {

    if (filaJogadas[i] == "X" &&
      filaJogadas[i + 1] == "X" &&
      filaJogadas[i + 2] == "X") {
      return "x"
    }

    if (filaJogadas[i] == "O" &&
      filaJogadas[i + 1] == "O" &&
      filaJogadas[i + 2] == "O") {
      // alert('O wins!!!')
      // resetar()
      return "o"
    }
  }
}


const verificaSeColunaGanhou = () => {
  for (var i = 0; i < 3; i++) {
    if (filaJogadas[i] == "X" &&
      filaJogadas[i + 3] == "X" &&
      filaJogadas[i + 6] == "X") {
      return "x"
    }
    if (filaJogadas[i] == "O" &&
      filaJogadas[i + 3] == "O" &&
      filaJogadas[i + 6] == "O") {
      return "o"
    }
  }
}


const verificaSeDiagonalGanhou = () => {
  if ((filaJogadas[0] == 'X' && filaJogadas[4] == 'X' && filaJogadas[8] == 'X') ||
    (filaJogadas[2] == 'X' && filaJogadas[4] == 'X' && filaJogadas[6] == 'X')) {
    return "x"
  } else if ((filaJogadas[0] == 'O' && filaJogadas[4] == 'O' && filaJogadas[8] == 'O') ||
    (filaJogadas[2] == 'O' && filaJogadas[4] == 'O' && filaJogadas[6] == 'O')) {
    return "o"
  }
}


const verificaResultado = () => {

  let mensagem = document.querySelector(".mensagem")
  let mensagemH3 = document.querySelector(".mensagem h3")

  if (verificaSeLinhaGanhou() === "x" ||
    verificaSeColunaGanhou() === "x" ||
    verificaSeDiagonalGanhou() === "x") {

    tabuleiro.style.display = "none"
    mensagem.style.display = "block"
    mensagemH3.textContent = "Jogador X ganhou"

  } else
    if (verificaSeLinhaGanhou() === "o" ||
      verificaSeColunaGanhou() === "o" ||
      verificaSeDiagonalGanhou() === "o") {

      tabuleiro.style.display = "none"
      mensagem.style.display = "block"
      mensagemH3.textContent = "Jogador O ganhou"

    } else
      if (verificaEmpate() === "empate") {
        tabuleiro.style.display = "none"
        mensagem.style.display = "block"
        mensagemH3.textContent = "Empatou"
      }
}


const reiniciaJogo = () => {
  window.location.reload();
}

tabuleiro.addEventListener("keydown", fazerJogada)

tabuleiro.addEventListener("keydown", verificaSeLinhaGanhou)

tabuleiro.addEventListener("keydown", verificaSeColunaGanhou)

tabuleiro.addEventListener("keydown", verificaSeDiagonalGanhou)

botaoReiniciar.addEventListener("click", reiniciaJogo)