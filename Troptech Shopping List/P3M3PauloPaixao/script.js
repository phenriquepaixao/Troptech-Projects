document.getElementById("formProdutos")
    .addEventListener("submit",
        function (event) {
            event.preventDefault()

            let nome = document.getElementById("nome").value;
            let quantidade = document.getElementById("quantidade").value;
            let unidade = document.getElementById("unidade").value;
            let preco = document.getElementById("preco").value;

            let span = document.getElementById("resultado");
            span.classList.add("text-danger");

            if (nome.length <= 0) {

                span.innerText = "*Ops, o nome do produto é obrigatório.";

            } else if (nome.length > 15) {

                span.innerText = "*Ops, o nome do produto é muito longo.";

            } else if (quantidade <= 0) {

                span.innerText = "*Ops, a quantidade mínima é 1.";

            } else if (preco.length <= 0) {

                span.innerText = "*Ops, o preço do produto é obrigatório";

            } else {

                adicionarProduto(nome, quantidade, unidade, preco);

                document.getElementById("valorTotal").innerHTML = `R$ ${valorTotalLista()}`;

                this.reset();

                span.classList.remove("text-danger");;
                span.classList.add("text-success");
                span.innerText = "*Produto adicionado com sucesso";
            }
        }
    );

var arrayProducts = [];

function adicionarProduto(nome, quantidade, unidade, preco) {

    let product = { nome, quantidade, unidade, preco };

    product.nome = nome;
    product.quantidade = quantidade;
    product.unidade = unidade;
    product.preco = Number(preco).toFixed(2);

    arrayProducts.push(product);

    atualizarLista();
}


function removerProduto(indexProduct) {

    arrayProducts.splice(indexProduct, 1);

    atualizarLista();

    document.getElementById("valorTotal").innerHTML = `R$ ${valorTotalLista()}`;

}

function atualizarLista() {

    let divNovoProduto = document.querySelector("#novoProduto");
    divNovoProduto.innerHTML = '';

    for (let i = 0; i < arrayProducts.length; i++) {
        divNovoProduto.innerHTML += `<div class="row bg-light rounded-4 pt-2 pb-2 ms-1 me-1 mb-3 shadow-sm">
                                        <div class="col-2 m-auto">
                                            <input class="form-check-input" type="checkbox" value=""
                                                aria-label="Checkbox for following text input">
                                        </div>
                                        <div class="col-8 text-start m-auto">
                                            <span class="fw-semibold">${arrayProducts[i].nome} | ${arrayProducts[i].quantidade} ${arrayProducts[i].unidade}<br></span>
                                            <span class="fs-small">R$ ${arrayProducts[i].preco}</span>

                                        </div>
                                        <div class="col-2 m-auto">
                                            <a class="btn btn-outline-ligth btn-sm border-0 rounded-circle bg-danger bg-opacity-10" onclick="removerProduto(${i})">
                                                <i class="bi bi-trash text-danger text-opacity-75"></i>
                                            </a>
                                        </div>
                                    </div>`;
    }

}



document.getElementById("formSearch")
    .addEventListener("submit",
        function (event) {
            event.preventDefault()

            let valorBuscado = document.getElementById("valorBuscado").value;

            if (valorBuscado == "") {
                atualizarLista();
            }

            let produtoEncontrado = arrayProducts.find(({ nome }) => nome === valorBuscado);

            if (produtoEncontrado != undefined) {
                let divNovoProduto = document.querySelector("#novoProduto");
                divNovoProduto.innerHTML = '';

                divNovoProduto.innerHTML += `<div class="row bg-light rounded-4 pt-2 pb-2 ms-1 me-1 mb-3 shadow-sm">
                                                <div class="col-2 m-auto">
                                                    <input class="form-check-input" type="checkbox" value=""
                                                        aria-label="Checkbox for following text input">
                                                </div>
                                                <div class="col-8 text-start m-auto">
                                                    <span class="fw-semibold">${produtoEncontrado.nome} | ${produtoEncontrado.quantidade} ${produtoEncontrado.unidade}<br></span>
                                                    <span class="fs-small">R$ ${produtoEncontrado.preco}</span>
        
                                                </div>
                                                <div class="col-2 m-auto">
                                                    <a class="btn btn-outline-ligth btn-sm border-0 rounded-circle bg-danger bg-opacity-10" onclick="removerProduto(indexOf(produtoEncontrado))">
                                                        <i class="bi bi-trash text-danger text-opacity-75"></i>
                                                    </a>
                                                </div>
                                            </div>`;
            }

        }
    );


function valorTotalLista() {
    let total = 0.00;
    for (const item of arrayProducts) {
        total += Number(item.preco);
    }

    return total.toFixed(2);
}