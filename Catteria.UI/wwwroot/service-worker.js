const CACHE_NAME = "meu-app-v1";

const STATIC_FILES = [
    "/offline.html",
    "/css/site.css",
    "/js/site.js"
];

self.addEventListener("install", event => {
    event.waitUntil(
        caches.open(CACHE_NAME).then(cache =>
            cache.addAll(STATIC_FILES)
        )
    );

    self.skipWaiting();
});

self.addEventListener("activate", event => {
    event.waitUntil(
        caches.keys().then(keys =>
            Promise.all(
                keys
                    .filter(key => key !== CACHE_NAME)
                    .map(key => caches.delete(key))
            )
        )
    );

    self.clients.claim();
});

self.addEventListener("fetch", event => {
    const request = event.request;

    if (request.method !== "GET") return;

    const url = new URL(request.url);

    if (url.origin !== self.location.origin) return;

    if (request.mode === "navigate") {
        event.respondWith(
            fetch(request).catch(async () => {
                const offlinePage = await caches.match("/offline.html");

                if (offlinePage) return offlinePage;

                return new Response(
                    "Você está sem conexão com a internet.",
                    {
                        status: 503,
                        headers: {
                            "Content-Type": "text/plain; charset=utf-8"
                        }
                    }
                );
            })
        );

        return;
    }

    event.respondWith(
        caches.match(request).then(cached => {
            return cached || fetch(request);
        })
    );
});