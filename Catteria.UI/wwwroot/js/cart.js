const CART_KEY = "cart";

function getCart() {
    return JSON.parse(localStorage.getItem(CART_KEY)) || [];
}

function saveCart(cart) {
    localStorage.setItem(CART_KEY, JSON.stringify(cart));
}

function addToCart(id, name, price, image) {

    let cart = getCart();

    let item = cart.find(p => p.id == id);

    if (item) {

        item.quantity++;

    } else {

        cart.push({
            id: id,
            name: name,
            price: Number(price),
            image: image,
            quantity: 1
        });

    }

    saveCart(cart);

    updateCartCounter();

    alert("Produto adicionado ao carrinho!");
}

function updateCartCounter() {

    const cart = getCart();

    let total = 0;

    cart.forEach(item => {
        total += item.quantity;
    });

    const counter = document.getElementById("cart-count");

    if (counter) {
        counter.innerText = total;
    }
}

document.addEventListener("DOMContentLoaded", function () {

    updateCartCounter();

});

function loadCart() {

    const table = document.getElementById("cart-items");

    if (!table)
        return;

    const cart = getCart();

    table.innerHTML = "";

    let total = 0;

    if (cart.length === 0) {

        table.innerHTML = `
            <tr>
                <td colspan="5" class="text-center">
                    Seu carrinho está vazio.
                </td>
            </tr>
        `;

        document.getElementById("cart-total").innerHTML = "Total: R$ 0,00";
        return;
    }

    cart.forEach(item => {

        const subtotal = item.price * item.quantity;

        total += subtotal;

        table.innerHTML += `
            <tr>

                <td>
                    <div class="d-flex align-items-center gap-3">

                        <img src="${item.image}"
                             width="70"
                             height="70"
                             class="rounded object-fit-cover">

                        <div>
                            <strong>${item.name}</strong>
                        </div>

                    </div>
                </td>

                <td class="text-center">
                    R$ ${item.price.toFixed(2)}
                </td>

                <td class="text-center">

                    <button class="btn btn-sm btn-outline-secondary"
                        onclick="decreaseQuantity(${item.id})">-</button>

                    <span class="mx-2">${item.quantity}</span>

                    <button class="btn btn-sm btn-outline-secondary"
                        onclick="increaseQuantity(${item.id})">+</button>

                </td>

                <td class="text-center">
                    R$ ${subtotal.toFixed(2)}
                </td>

                <td class="text-center">

                    <button class="btn btn-danger btn-sm"
                        onclick="removeFromCart(${item.id})">

                        Remover

                    </button>

                </td>

            </tr>
        `;

    });

    document.getElementById("cart-total").innerHTML =
        `Total: R$ ${total.toFixed(2)}`;

}

function increaseQuantity(id) {

    let cart = getCart();

    const item = cart.find(x => x.id == id);

    if (item)
        item.quantity++;

    saveCart(cart);

    loadCart();

    updateCartCounter();
}

function decreaseQuantity(id) {

    let cart = getCart();

    const item = cart.find(x => x.id == id);

    if (!item)
        return;

    item.quantity--;

    if (item.quantity <= 0)
        cart = cart.filter(x => x.id != id);

    saveCart(cart);

    loadCart();

    updateCartCounter();
}

function removeFromCart(id) {

    let cart = getCart();

    cart = cart.filter(x => x.id != id);

    saveCart(cart);

    loadCart();

    updateCartCounter();
}

function clearCart() {

    localStorage.removeItem(CART_KEY);

    loadCart();

    updateCartCounter();
}