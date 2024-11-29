window.addEventListener('resize', function() {
    const header = document.querySelector('header');
    const main = document.querySelector('main');
    main.style.paddingTop = `${header.offsetHeight}px`;
});

// İlk yüklemede de çağırmak için
window.dispatchEvent(new Event('resize'));