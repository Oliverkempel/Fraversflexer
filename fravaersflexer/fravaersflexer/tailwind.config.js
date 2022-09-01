/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["./Views/**/*.{html,cshtml,js}"],
  theme: {
      extend: {
          colors: {
              sejorange: '#E95B47',
              sejorange2: '#d64a37',
              sejorange3: '#d67337',
              flexdark: '111827',
              flexlightdark: '1c2539',
              flexprimary: '0ea5e9',
              flexlightgrey: 'B7B3B3'
          }
      },
  },
  plugins: [],
}
