
const listaProdutos = document.getElementById("listaProdutos");
const subtotalElement = document.getElementById("subtotal");
const freteElement = document.getElementById("frete");
const totalElement = document.getElementById("total");
const observacoes = getObservacaoPedido();

console.log("Observações:", observacoes);
const FRETE = 10;

const formasPagamento = document.querySelectorAll(
    'input[name="formaPagamento"]'
);

const pagamentoPix = document.getElementById("pagamentoPix");
const pagamentoCartao = document.getElementById("pagamentoCartao");
const pagamentoRetirada = document.getElementById("pagamentoRetirada");


formasPagamento.forEach(opcao => {

    opcao.addEventListener("change", function () {

        pagamentoPix.style.display = "none";
        pagamentoCartao.style.display = "none";
        pagamentoRetirada.style.display = "none";

        if (this.value === "pix") {
            pagamentoPix.style.display = "block";
        }

        if (this.value === "cartao") {
            pagamentoCartao.style.display = "block";
        }

        if (this.value === "retirada") {
            pagamentoRetirada.style.display = "block";
            
        }

        carregarResumo();
    });

});
function getObservacaoPedido() {
    const campo = document.getElementById("observacoesPedido");

    if (!campo)
        return "";

    return campo.value.trim();
}

function getCart() {
    return JSON.parse(localStorage.getItem(CART_KEY)) || [];
}

function formatarPreco(valor) {
    return Number(valor).toLocaleString("pt-BR", {
        style: "currency",
        currency: "BRL"
    });
}

function carregarResumo() {

    const cart = getCart();

    console.log("Carrinho encontrado:", cart);

    listaProdutos.innerHTML = "";

    if (cart.length === 0) {

        listaProdutos.innerHTML = `
            <div class="text-center">
                <p class="text-muted">
                    Seu carrinho está vazio.
                </p>
            </div>
        `;

        subtotalElement.textContent = formatarPreco(0);
        freteElement.textContent = formatarPreco(0);
        totalElement.textContent = formatarPreco(0);

        return;
    }

    let subtotal = 0;

    cart.forEach(item => {

        const preco = Number(item.price);
        const quantidade = Number(item.quantity);

        const valorProduto = preco * quantidade;

        subtotal += valorProduto;

        listaProdutos.innerHTML += `
            <div class="d-flex align-items-center mb-3">

                <img src="${item.image}"
                     width="60"
                     height="60"
                     class="rounded object-fit-cover me-3">

                <div class="flex-grow-1">

                    <strong>
                        ${item.name}
                    </strong>

                    <div class="text-muted small">
                        ${quantidade}x ${formatarPreco(preco)}
                    </div>

                </div>

                <strong>
                    ${formatarPreco(valorProduto)}
                </strong>

            </div>
        `;
    });

    const formaPagamento = document.querySelector(
        'input[name="formaPagamento"]:checked'
    )?.value;

    const frete = formaPagamento === "retirada" ? 0 : FRETE;

    const total = subtotal + frete;

    subtotalElement.textContent = formatarPreco(subtotal);
    freteElement.textContent = formatarPreco(frete);
    totalElement.textContent = formatarPreco(total);
}

async function finalizarPedido() {

    const cart = getCart();

    if (cart.length === 0) {
        alert("Seu carrinho está vazio.");
        return;
    }

    const observacoes =
        document.getElementById("observacoesPedido")?.value.trim() || "";

    const formaPagamento =
        document.querySelector(
            'input[name="formaPagamento"]:checked'
        )?.value;

    if (!formaPagamento) {
        alert("Selecione uma forma de pagamento.");
        return;
    }

    const pedido = {


        observations: observacoes,

        paymentMethod: formaPagamento,

        items: cart.map(item => ({
            idProduct: Number(item.id),
            quantity: Number(item.quantity),
            unitPrice: Number(item.price)
        }))
    };

    try {

        const response = await fetch("/Cart/Criar", {
            method: "POST",

            headers: {
                "Content-Type": "application/json"
            },

            body: JSON.stringify(pedido)
        });

        if (!response.ok) {

            const erro = await response.text();

            console.error(erro);

            alert("Não foi possível finalizar o pedido.");

            return;
        }

        const resultado = await response.json();

        console.log("Pedido criado:", resultado);

        localStorage.removeItem("cart");

        localStorage.removeItem("observacoesPedido");

        alert("Pedido realizado com sucesso!");

        window.location.href = `/Order/Success?id=${resultado.orderId}`;

    }
    catch (error) {

        console.error(error);

        alert("Ocorreu um erro ao finalizar o pedido.");
    }
}


document.addEventListener("DOMContentLoaded", function () {

    carregarResumo();

});