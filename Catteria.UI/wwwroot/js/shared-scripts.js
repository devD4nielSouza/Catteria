(function(){
    document.addEventListener('DOMContentLoaded', function(){
        try {
            // --- Mobile menu (public layout) ---
            (function(){
                const hamburgerBtn = document.getElementById('hamburgerBtn');
                const mobileMenu = document.getElementById('mobileMenu');

                if (hamburgerBtn && mobileMenu) {
                    hamburgerBtn.addEventListener('click', function() {
                        if (mobileMenu.style.display === 'none' || mobileMenu.style.display === '') {
                            mobileMenu.style.display = 'block';
                        } else {
                            mobileMenu.style.display = 'none';
                        }
                    });

                    // Fechar menu ao clicar em um link
                    const mobileLinks = mobileMenu.querySelectorAll('a');
                    mobileLinks.forEach(link => {
                        link.addEventListener('click', function() {
                            mobileMenu.style.display = 'none';
                        });
                    });
                }
            })();

            // --- Admin off-canvas sidebar ---
            (function(){
                const toggle = document.getElementById('adminMenuToggle');
                const sidebar = document.querySelector('.admin-sidebar');
                const overlay = document.getElementById('adminOverlay');

                if (toggle && sidebar && overlay) {
                    const openSidebar = () => {
                        sidebar.classList.add('open');
                        overlay.classList.add('show');
                        document.body.style.overflow = 'hidden';
                    };

                    const closeSidebar = () => {
                        sidebar.classList.remove('open');
                        overlay.classList.remove('show');
                        document.body.style.overflow = '';
                    };

                    toggle.addEventListener('click', function() {
                        if (sidebar.classList.contains('open')) closeSidebar();
                        else openSidebar();
                    });

                    overlay.addEventListener('click', closeSidebar);

                    // Fechar ao clicar em link do menu
                    const links = sidebar.querySelectorAll('.nav-link');
                    links.forEach(l => l.addEventListener('click', closeSidebar));
                }
            })();

            // --- Products page: paginação responsiva (desktop 8 / mobile 5) ---
            (function(){
                // identificar página de produtos pela presença do herói do cardápio ou da tabela de produtos
                if (!document.querySelector('.cat-menu-hero') && !document.querySelector('.cat-card')) return;

                try {
                    const url = new URL(window.location.href);
                    const current = parseInt(url.searchParams.get('pageSize')) || 5; // fallback 5
                    const desired = window.innerWidth >= 992 ? 8 : 5; // breakpoint desktop

                    if (current !== desired) {
                        url.searchParams.set('pageSize', desired);
                        url.searchParams.set('page', 1);
                        window.location.href = url.toString();
                    }
                }
                catch (e) {
                    console.error('Pagination autoswitch failed', e);
                }
            })();

        } catch (e) {
            console.error('shared-scripts error', e);
        }
    });
})();
