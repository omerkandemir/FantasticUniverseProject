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


let currentStarContainer;
let galaxies = [];
let currentGalaxyIndex = null;

// Galaksi modalini aç/kapat ve güncelleme işlemi başlat
function toggleGalaxyModal(index = null) {
    currentGalaxyIndex = index;

    if (index !== null) {
        const galaxy = galaxies[index];
        document.getElementById("galaxyName").value = galaxy.name;
        document.getElementById("starContainer").innerHTML = "";
        galaxy.stars.forEach((star) => {
            addStar(star.name, star.planets);
        });
        document.querySelector("#saveGalaxyButton").innerText = "Galaksiyi Güncelle";
    } else {
        document.getElementById("galaxyName").value = "";
        document.getElementById("starContainer").innerHTML = "";
        document.querySelector("#saveGalaxyButton").innerText = "Galaksiyi Kaydet";
    }

    const modal = document.getElementById("galaxyModal");
    modal.style.display = (modal.style.display === "block") ? "none" : "block";
}

// Gezegen modalini aç/kapat
function togglePlanetModal(starContainer) {
    currentStarContainer = starContainer;
    const modal = document.getElementById("planetModal");
    modal.style.display = (modal.style.display === "block") ? "none" : "block";
}

// Yıldız ekle ve isteğe bağlı olarak gezegenleri ekle
function addStar(starName = "", planets = []) {
    const starDiv = document.createElement('div');
    starDiv.className = "star-item";
    starDiv.innerHTML = `
        <label for="starName">Yıldız Adı:</label>
        <input type="text" name="starName" value="${starName}" required />
        <button type="button" onclick="togglePlanetModal(this.nextElementSibling)" class="create-button">Gezegen Ekle</button>
        <div class="planetContainer"></div>
    `;
    document.getElementById('starContainer').appendChild(starDiv);

    planets.forEach((planet) => {
        addPlanet(starDiv.querySelector(".planetContainer"), planet);
    });
}

// Gezegen ekle
function addPlanetToStar() {
    const planetName = document.getElementById("planetName").value;
    const PlanetAge = document.getElementById("planetAge").value || null;
    const PlanetTemperature = document.getElementById("planetTemperature").value || null;
    const PlanetMass = document.getElementById("planetMass").value || null;

    if (!planetName) {
        alert("Gezegen adı zorunludur!");
        return;
    }

    const planetData = {
        name: planetName,
        PlanetAge: PlanetAge,
        PlanetTemperature: PlanetTemperature,
        PlanetMass: PlanetMass
    };
    addPlanet(currentStarContainer, planetData);

    togglePlanetModal();

    document.getElementById("planetName").value = "";
    document.getElementById("planetAge").value = "";
    document.getElementById("planetTemperature").value = "";
    document.getElementById("planetMass").value = "";
}

// Gezegen bilgilerini mevcut yıldıza ekle
function addPlanet(container, planetData) {
    const planetDiv = document.createElement('div');
    planetDiv.className = "planet-item";
    planetDiv.innerHTML = `
        <span class="planet-name">Gezegen Adı: ${planetData.name}</span><br />
        ${planetData.PlanetAge ? `<span class="planet-age">Yaşı: ${planetData.PlanetAge} milyon yıl</span><br />` : ""}
        ${planetData.PlanetTemperature ? `<span class="planet-temp">Sıcaklığı: ${planetData.PlanetTemperature} °C</span><br />` : ""}
        ${planetData.PlanetMass ? `<span class="planet-mass">Kütlesi: ${planetData.PlanetMass} * 10^24 kg</span><br />` : ""}
    `;
    container.appendChild(planetDiv);
}

// Galaksiyi kaydet veya güncelle
function saveGalaxy() {
    const galaxyName = document.getElementById("galaxyName").value;
    if (!galaxyName) {
        alert("Galaksi adı zorunludur!");
        return;
    }

    const stars = [];
    document.querySelectorAll('.star-item').forEach(starItem => {
        const starName = starItem.querySelector('input[name="starName"]').value;
        const planets = [];
        starItem.querySelectorAll('.planet-item').forEach(planetItem => {
            const planetData = {
                name: planetItem.querySelector('.planet-name').innerText.replace("Gezegen Adı: ", ""),
                PlanetAge: parseInt(planetItem.querySelector('.planet-age')?.innerText.replace("Yaşı: ", "").replace(" milyon yıl", "")) || null,
                PlanetTemperature: parseInt(planetItem.querySelector('.planet-temp')?.innerText.replace("Sıcaklığı: ", "").replace(" °C", "")) || null,
                PlanetMass: parseInt(planetItem.querySelector('.planet-mass')?.innerText.replace("Kütlesi: ", "").replace(" * 10^24 kg", "")) || null
            };
            planets.push(planetData);
        });
        stars.push({ name: starName, planets: planets });
    });

    const galaxyData = { name: galaxyName, stars: stars };

    if (currentGalaxyIndex !== null) {
        galaxies[currentGalaxyIndex] = galaxyData;
    } else {
        galaxies.push(galaxyData);
    }

    document.getElementById("galaxies").value = JSON.stringify(galaxies);

    renderGalaxyList();
    toggleGalaxyModal();
}

// Galaksi listesini gösterme
function renderGalaxyList() {
    const galaxyListContainer = document.getElementById("galaxyListContainer");
    galaxyListContainer.innerHTML = "";
    galaxies.forEach((galaxy, index) => {
        const galaxyCard = document.createElement("div");
        galaxyCard.className = "galaxy-card";
        galaxyCard.innerText = galaxy.name;
        galaxyCard.onclick = () => toggleGalaxyModal(index);
        galaxyListContainer.appendChild(galaxyCard);
    });
}


// Varsayılan Tema Ayarları
const defaultThemeSettings = {
    background: "default",           
    fontFamily: "Lato",              
    fontColorR: 0,                   
    fontColorG: 0,
    fontColorB: 0
};

// Tema ayarları kontrolü ve varsayılan değerlerin eklenmesi
function setDefaultThemeSettings() {
    if (!document.getElementById("themeBackground").value) {
        document.getElementById("themeBackground").value = defaultThemeSettings.background;
    }
    if (!document.getElementById("themeFontFamily").value) {
        document.getElementById("themeFontFamily").value = defaultThemeSettings.fontFamily;
    }
    if (!document.getElementById("themeFontColorR").value) {
        document.getElementById("themeFontColorR").value = defaultThemeSettings.fontColorR;
    }
    if (!document.getElementById("themeFontColorG").value) {
        document.getElementById("themeFontColorG").value = defaultThemeSettings.fontColorG;
    }
    if (!document.getElementById("themeFontColorB").value) {
        document.getElementById("themeFontColorB").value = defaultThemeSettings.fontColorB;
    }
}

// Form gönderilmeden önce varsayılan ayarların kontrolü
document.getElementById("universeForm").addEventListener("submit", function () {
    setDefaultThemeSettings();
});