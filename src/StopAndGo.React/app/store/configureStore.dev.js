import {composeWithDevTools} from 'redux-devtools-extension';
import thunk from 'redux-thunk';
import promiseMiddlware from 'redux-promise-middleware';
import rootReducer from '../rootReducer';
import {applyMiddleware, createStore} from 'redux';

export default function() {
  const middleware = [thunk, promiseMiddlware()];

  const store = createStore(
    rootReducer,
    composeWithDevTools(applyMiddleware(...middleware)),
  );

  if (module.hot) {
    // Enable Webpack hot module replacement for reducers
    module.hot.accept('../rootReducer', () => {
      const nextReducer = require('../rootReducer').default;
      store.replaceReducer(nextReducer);
    });
  }

  return store;
}
