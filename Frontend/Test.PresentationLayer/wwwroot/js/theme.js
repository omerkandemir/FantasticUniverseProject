// Tema modalini aç/kapat
function toggleThemeModal() {
    const modal = document.getElementById("themeModal");
    modal.style.display = (modal.style.display === "block") ? "none" : "block";
}

// Arka planı değiştir ve veriyi gizli alana aktar
function changeBackground() {
    const selectedTheme = document.getElementById('background-select').value.toLowerCase();
    applyTheme(document.body, selectedTheme);  // Seçili temayı uygula
    document.getElementById("themeBackground").value = selectedTheme;
}


// Kart Temaları Uygulama
document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.universe-card').forEach(card => {
        const themeName = card.dataset.background ? card.dataset.background.toLowerCase() : 'default';
        applyTheme(card, themeName); 

        const fontFamily = card.dataset.font || 'Arial'; 
        const color = card.dataset.color || 'rgb(0, 0, 0)'; 
        card.style.fontFamily = fontFamily;
        card.style.color = color;

    });
});

// Modüler Tema Fonksiyonları
const ThemeEffects = {

    stars: (container) => {
        container.classList.add("background-stars");
        let starsContainer = container.querySelector('.stars-container');
        if (!starsContainer) {
            starsContainer = document.createElement('div');
            starsContainer.className = 'stars-container';
            container.appendChild(starsContainer);
        }

        starsContainer.innerHTML = ''; 
        for (let i = 0; i < 50; i++) {  
            const star = document.createElement('div');
            star.className = 'star';
            star.style.width = `${Math.random() * 3 + 1}px`; 
            star.style.height = star.style.width;
            star.style.top = `${Math.random() * 100}%`;
            star.style.left = `${Math.random() * 100}%`;
            starsContainer.appendChild(star);
        }
    },

    galaxy: (container) => container.classList.add('background-galaxy'),
    night: (container) => container.classList.add('background-night'),
    mist: (container) => container.classList.add('background-mist'),

    clear: (container) => {
        container.classList.remove('background-stars', 'background-galaxy', 'background-night', 'background-mist');
        const starsContainer = container.querySelector('.stars-container');
        if (starsContainer) starsContainer.remove();
    }
};

// Her temaya göre animasyon ekle
function applyTheme(container, themeName) {
    ThemeEffects.clear(container); 
    if (ThemeEffects[themeName]) {
        ThemeEffects[themeName](container); 
    }
}
function changeFontStyle() {
    const selectedFont = document.getElementById("font-select").value;
    document.getElementById("themeFontFamily").value = selectedFont;
    document.querySelectorAll('.mystic-content, .mystic-text').forEach(el => el.style.fontFamily = selectedFont);
}

function changeFontColor() {
    const color = document.getElementById("font-color-picker").value;
    const [r, g, b] = hexToRgb(color);
    document.getElementById("themeFontColorR").value = r;
    document.getElementById("themeFontColorG").value = g;
    document.getElementById("themeFontColorB").value = b;
    document.querySelectorAll('.mystic-content, .mystic-text').forEach(el => el.style.color = color);
}

// HEX renk kodunu RGB'ye dönüştür
function hexToRgb(hex) {
    let r = parseInt(hex.slice(1, 3), 16);
    let g = parseInt(hex.slice(3, 5), 16);
    let b = parseInt(hex.slice(5, 7), 16);
    return [r, g, b];
}
