import './styles/styles.scss';
import './babelHelpers';
import configureStore from './store/configureStore';
import React from 'react';
import {render} from 'react-dom';
import toastr from 'toastr';
import history from './util/history';
import {configureHttp} from './util';
import Root from './Root';

toastr.options.positionClass = 'toast-bottom-full-width';
toastr.options.timeOut = 5000;

configureHttp();

const store = configureStore();

const appElement = document.getElementById('react-app-container');

function launchApplication() {
  render(<Root store={store} history={history} />, appElement);
}

launchApplication();
