const serviceWorkerFileName = '/ServiceWorker.js';
const swInstalledEvent = 'installed';
const staticCachePrefix = 'blazor-cache-v2';
const updateAlertMessage = 'Uppdatering existerar. Ladda om sidan.';
window.updateAvailable = new Promise(function (resolve, reject) {
    var { hostname } = window.location;
    if (typeof ignoreHosts !== 'undefined') {
        if (ignoreHosts.includes(hostname)) {
            return;
        }
    }
    if ('serviceWorker' in navigator) {
        navigator.serviceWorker.register(serviceWorkerFileName)
            .then(function (registration) {
                console.log('Registering lyckad, omfattning:', registration.scope);
                registration.onupdatefound = () => {
                    const installingWorker = registration.installing;
                    installingWorker.onstatechange = () => {
                        switch (installingWorker.state) {
                            case swInstalledEvent:
                                if (navigator.serviceWorker.controller) {
                                    resolve(true);
                                } else {
                                    resolve(false);
                                }
                                break;
                            default:
                        }
                    };
                };
            })
            .catch(error =>
                console.log('Kan inte installera serviceworker, felmeddelande:', error));
    }
});
window['updateAvailable']
    .then(isAvailable => {
        if (isAvailable) {
            alert(updateAlertMessage);
        }
    });
function showAddToHomeScreen() {
    var pwaInstallPrompt = document.createElement('div');
    var pwaInstallButton = document.createElement('button');
    var pwaCancelButton = document.createElement('button');
;

    pwaInstallPrompt.id = 'pwa-install-prompt';
    pwaInstallPrompt.style.position = 'absolute';
    pwaInstallPrompt.style.bottom = '0.1rem';
    pwaInstallPrompt.style.left = '0.1rem';
    pwaInstallPrompt.style.right = '0.1rem';
    pwaInstallPrompt.style.padding = '0.5rem';
    pwaInstallPrompt.style.display = 'flex';
    pwaInstallPrompt.style.backgroundColor = '#f4f4f4';
    pwaInstallPrompt.style.color = 'black';
    pwaInstallPrompt.style.fontFamily = 'sans-serif';
    pwaInstallPrompt.style.fontSize = '1.3rem';
    pwaInstallPrompt.style.borderRadius = '4px';

    pwaInstallButton.style.marginLeft = 'auto';
    pwaInstallButton.style.width = '4em';


    pwaCancelButton.style.marginLeft = '0.3rem';
    pwaCancelButton.style.width = '4em';


    pwaCancelButton.classList.add('btn');
    pwaInstallButton.classList.add('btn')
    pwaCancelButton.classList.add('btn-danger');
    pwaInstallButton.classList.add('btn-primary')

    pwaInstallPrompt.innerText = 'Vill du installera applikationen?';
    pwaInstallButton.innerText = 'Ja';
    pwaCancelButton.innerText = 'Nej';

    pwaInstallPrompt.appendChild(pwaInstallButton);
    pwaInstallPrompt.appendChild(pwaCancelButton);
    document.body.appendChild(pwaInstallPrompt);

    pwaInstallButton.addEventListener('click', addToHomeScreen);
    pwaCancelButton.addEventListener('click', hideAddToHomeScreen);
    setTimeout(hideAddToHomeScreen, 10000);
}

function hideAddToHomeScreen() {
    var pwa = document.getElementById('pwa-install-prompt');
    if (pwa) document.body.removeChild(pwa);
}

function addToHomeScreen(s, e) {
    hideAddToHomeScreen();
    if (window.PWADeferredPrompt) {
        window.PWADeferredPrompt.prompt();
        window.PWADeferredPrompt.userChoice
            .then(function (choiceResult) {
                window.PWADeferredPrompt = null;
            });
    }
}
window.addEventListener('beforeinstallprompt', function (e) {
    // Prevent Chrome 67 and earlier from automatically showing the prompt
    e.preventDefault();
    // Stash the event so it can be triggered later.
    window.PWADeferredPrompt = e;

    showAddToHomeScreen();

});
