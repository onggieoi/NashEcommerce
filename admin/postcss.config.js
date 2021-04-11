/* eslint-disable @typescript-eslint/no-var-requires */
module.exports =  {
    syntax: 'postcss-scss',
    plugins: [
      require("postcss-import"),
      require("tailwindcss"),
      require("postcss-nested"),
      require("autoprefixer"),
    ],
};