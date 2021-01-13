import React from 'react';
import {Provider} from 'react-redux';
import {Router} from 'react-router-dom';
import App from './App';
import {hot} from 'react-hot-loader';

function Root({store, history}) {
  return (
    <Provider store={store}>
      <Router history={history}>
        <App />
      </Router>
    </Provider>
  );
}

export default hot(module)(Root);
