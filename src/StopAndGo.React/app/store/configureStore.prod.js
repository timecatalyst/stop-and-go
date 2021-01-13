import thunk from 'redux-thunk';
import promiseMiddlware from 'redux-promise-middleware';
import rootReducer from '../rootReducer';
import {applyMiddleware, createStore} from 'redux';

export default function() {
  const middleware = [thunk, promiseMiddlware()];

  return createStore(rootReducer, applyMiddleware(...middleware));
}
