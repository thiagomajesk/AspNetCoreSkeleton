let mix = require('laravel-mix');

mix.setPublicPath('wwwroot');

mix.webpackConfig({
    devtool: 'source-map',
    module: {
        rules: [
            {
                test: /\.html$/,
                loaders: ['html-loader']
            }
        ]
    }
});

mix.ts('wwwroot/javascripts/application.ts', 'dist/application.js');
mix.sass('wwwroot/stylesheets/application.scss', 'dist/application.css');
mix.minify(['wwwroot/dist/application.js', 'wwwroot/dist/application.css']);

mix.autoload({
    'jquery': ['$', 'window.jQuery'],
    'popper.js': ['Popper', 'window.Popper']
});