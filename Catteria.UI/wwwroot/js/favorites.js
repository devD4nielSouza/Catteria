const FAVORITES_API = "http://localhost:5273/api/Favorites";


// ======================================================
// ADICIONAR / REMOVER FAVORITO
// ======================================================

async function toggleFavorite(productId) {

    try {

        const response = await fetch(
            `${FAVORITES_API}/${productId}`,
            {
                method: "POST",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json"
                }
            }
        );

        if (!response.ok) {
            throw new Error(`Erro HTTP: ${response.status}`);
        }

        const data = await response.json();

        console.log("Favorito:", data.isFavorite);


        const icon = document.getElementById("favoriteIcon");
        const text = document.getElementById("favoriteText");
        const button = document.getElementById("favoriteButton");


        // Só atualiza o botão se ele existir
        if (icon && text && button) {

            if (data.isFavorite) {

                icon.className = "bi bi-heart-fill me-2";

                text.textContent =
                    "Remover dos favoritos";

                button.classList.remove(
                    "btn-outline-danger"
                );

                button.classList.add(
                    "btn-danger"
                );

            } else {

                icon.className = "bi bi-heart me-2";

                text.textContent =
                    "Adicionar aos favoritos";

                button.classList.remove(
                    "btn-danger"
                );

                button.classList.add(
                    "btn-outline-danger"
                );
            }
        }

        return data.isFavorite;

    }
    catch (error) {

        console.error(
            "Erro ao alterar favorito:",
            error
        );

        alert(
            "Não foi possível alterar o favorito."
        );

        return null;
    }
}


// ======================================================
// CARREGAR FAVORITOS
// ======================================================

async function carregarFavoritos() {

    console.log("Carregando favoritos...");

    const loading =
        document.getElementById("loading");

    const container =
        document.getElementById("favorites");

    const empty =
        document.getElementById("empty");


    // IMPORTANTE:
    // Se não estamos na página de favoritos,
    // não fazemos absolutamente nada.
    if (!container) {
        return;
    }


    try {

        if (loading) {
            loading.style.display = "block";
        }


        const response = await fetch(
            FAVORITES_API,
            {
                method: "GET",
                credentials: "include"
            }
        );


        if (!response.ok) {
            throw new Error(
                `Erro HTTP: ${response.status}`
            );
        }


        const produtos =
            await response.json();


        console.log(
            "Favoritos:",
            produtos
        );


        if (loading) {
            loading.style.display = "none";
        }


        // Nenhum favorito
        if (!produtos || produtos.length === 0) {

            if (empty) {
                empty.style.display = "block";
            }

            container.style.display = "none";

            return;
        }


        if (empty) {
            empty.style.display = "none";
        }


        container.style.display = "flex";
        container.innerHTML = "";


        produtos.forEach(produto => {

            const id = produto.id;
            const nome = produto.name ?? "Produto";
            const descricao = produto.description ?? "";
            const preco = produto.price ?? 0;
            const imagem = produto.coverImageUrl;


            const card =
                document.createElement("div");

            card.className =
                "col-md-6 col-lg-4";


            card.innerHTML = `

                <div class="card h-100 shadow-sm">

                    ${
                        imagem
                        ?
                        `
                        <img
                            src="${imagem}"
                            class="card-img-top"
                            style="
                                height:220px;
                                object-fit:cover;
                            "
                            alt="${nome}">
                        `
                        :
                        `
                        <div
                            class="
                                d-flex
                                align-items-center
                                justify-content-center
                            "
                            style="
                                height:220px;
                                background:#f5f5f5;
                            ">

                            <i class="
                                bi
                                bi-image
                                fs-1
                                text-muted
                            "></i>

                        </div>
                        `
                    }


                    <div class="card-body d-flex flex-column">

                        <h4 class="fw-bold">
                            ${nome}
                        </h4>


                        <p class="text-muted">
                            ${descricao}
                        </p>


                        <h5 class="fw-bold mt-auto">

                            R$
                            ${Number(preco).toLocaleString(
                                "pt-BR",
                                {
                                    minimumFractionDigits: 2,
                                    maximumFractionDigits: 2
                                }
                            )}

                        </h5>


                        <div class="d-flex gap-2 mt-3">

                            <a
                                href="/Products/Details/${id}"
                                class="
                                    btn
                                    btn-success
                                    rounded-pill
                                    flex-grow-1
                                ">

                                Ver produto

                            </a>


                            <button
                                type="button"
                                class="
                                    btn
                                    btn-outline-danger
                                    rounded-pill
                                "
                                onclick="
                                    removerFavorito(${id})
                                "
                                title="Remover dos favoritos">

                                <i class="
                                    bi
                                    bi-heart-fill
                                "></i>

                            </button>

                        </div>

                    </div>

                </div>

            `;


            container.appendChild(card);

        });


    }
    catch (error) {

        console.error(
            "Erro ao carregar favoritos:",
            error
        );


        if (loading) {

            loading.style.display = "none";

        }


        const errorElement =
            document.getElementById("error");


        if (errorElement) {

            errorElement.style.display =
                "block";

            errorElement.textContent =
                "Não foi possível carregar os favoritos.";

        }

    }
}


// ======================================================
// REMOVER FAVORITO
// ======================================================

async function removerFavorito(productId) {

    try {

        const response = await fetch(
            `${FAVORITES_API}/${productId}`,
            {
                method: "POST",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json"
                }
            }
        );


        if (!response.ok) {

            throw new Error(
                `Erro HTTP: ${response.status}`
            );

        }


        const data =
            await response.json();


        console.log(
            "Favorito removido:",
            data
        );


        // Atualiza a página de favoritos
        await carregarFavoritos();

    }
    catch (error) {

        console.error(
            "Erro ao remover favorito:",
            error
        );

        alert(
            "Não foi possível remover o favorito."
        );

    }
}


// ======================================================
// INICIALIZAÇÃO
// ======================================================

document.addEventListener(
    "DOMContentLoaded",
    function () {

        // Só carrega a lista se estivermos
        // realmente na página de favoritos.

        const favoritesContainer =
            document.getElementById("favorites");


        if (favoritesContainer) {

            carregarFavoritos();

        }

    }
);