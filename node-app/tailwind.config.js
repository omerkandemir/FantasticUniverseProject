module.exports = {
  mode: 'jit', 
  content: [
  './Views/**/*.cshtml',
  './src/**/*.{html,js,jsx,ts,tsx}',
  './wwwroot/**/*.html',
  ], 
  safelist: [
    { pattern: /.*/ }, 
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