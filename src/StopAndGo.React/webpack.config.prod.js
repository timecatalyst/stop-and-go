import autoprefixer from 'autoprefixer';
import cssnano from 'cssnano';
import MiniCssExtractPlugin from 'mini-css-extract-plugin';
import HtmlWebpackPlugin from 'html-webpack-plugin';
import path from 'path';
import {EnvironmentPlugin} from 'webpack';

export default {
  mode: 'production',
  stats: 'none',
  entry: {
    semanticui: '../StopAndGo.SemanticUI/dist/semantic.css',
    main: ['@babel/polyfill', './app/index.js'],
  },
  output: {
    path: path.resolve(__dirname, '../StopAndGo.Api/wwwroot/react/'),
    publicPath: '/react/',
    filename: '[name].[chunkhash].js',
    chunkFilename: '[name].[chunkhash].js',
  },
  optimization: {
    splitChunks: {
      chunks: 'all',
    },
  },
  devtool: false,
  plugins: [
    new EnvironmentPlugin({API_BASE_URL: '/api/'}),
    new MiniCssExtractPlugin({
      filename: '[name].[chunkhash].css',
      chunkFilename: '[id].[chunkhash].css',
    }),
    new HtmlWebpackPlugin({
      template: 'app/index.ejs',
      inject: true,
    }),
  ],
  module: {
    rules: [
      {
        test: /\.js$/,
        exclude: /(node_modules|babelHelpers)/,
        use: {
          loader: 'babel-loader',
          options: {
            presets: [
              [
                '@babel/preset-env',
                {
                  modules: false,
                  forceAllTransforms: true,
                },
              ],
              '@babel/preset-react',
            ],
            plugins: [
              '@babel/plugin-syntax-dynamic-import',
              '@babel/plugin-proposal-object-rest-spread',
              '@babel/plugin-external-helpers',
              'babel-plugin-transform-react-remove-prop-types',
            ],
          },
        },
      },
      {
        test: /\.scss$/,
        use: [
          MiniCssExtractPlugin.loader,
          {
            loader: 'css-loader',
            options: {
              importLoaders: 2,
            },
          },
          {
            loader: 'postcss-loader',
            options: {
              plugins: [autoprefixer, cssnano],
            },
          },
          'sass-loader',
        ],
      },
      {
        test: /\.css$/,
        use: [
          MiniCssExtractPlugin.loader,
          {
            loader: 'css-loader',
            options: {
              importLoaders: 1,
            },
          },
          {
            loader: 'postcss-loader',
            options: {
              plugins: [cssnano],
            },
          },
        ],
      },
      {
        test: /\.eot(\?v=\d+.\d+.\d+)?$/,
        use: ['file-loader'],
      },
      {
        test: /\.woff(2)?(\?v=[0-9]\.[0-9]\.[0-9])?$/,
        use: ['file-loader'],
      },
      {
        test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/,
        use: ['file-loader'],
      },
      {
        test: /\.otf(\?v=\d+\.\d+\.\d+)?$/,
        use: ['file-loader'],
      },
      {
        test: /\.svg(\?v=\d+\.\d+\.\d+)?$/,
        use: ['file-loader'],
      },
      {
        test: /\.(jpe?g|png|gif)$/i,
        use: ['file-loader'],
      },
    ],
  },
};
