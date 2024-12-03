module.exports = {
  content: [
  "./*.html",
  "./Views/**/*.cshtml",
  "./public/**/*.html",
  "./src/**/*.{html,js,jsx,ts,tsx}"
],
  safelist: [
     {
    pattern: /text-(blue|red|green|yellow|orange|purple|pink|gray)-\d{3}/, // Renk sınıfları
  },
  {
    pattern: /bg-(blue|red|green|yellow|orange|purple|pink|gray)-\d{3}/, // Arkaplan renk sınıfları
  },
  {
    pattern: /p-\d/, // Padding sınıfları
  },
  {
    pattern: /m-\d/, // Margin sınıfları
  },
  ],
  theme: {
    extend: {},
  },
  plugins: [
    require('@tailwindcss/typography'),
    require('@tailwindcss/forms'),
    require('@tailwindcss/line-clamp'),
    require('@tailwindcss/aspect-ratio'),
  ],
};