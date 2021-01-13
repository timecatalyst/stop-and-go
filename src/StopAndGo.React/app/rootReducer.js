import {combineReducers} from 'redux-immutable';
import stopAndGo from './features/stopAndGo/reducers';

const rootReducer = combineReducers({
  features: combineReducers({
    stopAndGo,
  }),
});

export default rootReducer;
