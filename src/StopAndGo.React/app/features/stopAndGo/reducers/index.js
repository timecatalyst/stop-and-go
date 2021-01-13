import {stateReducer} from 'truefit-react-utils';
import {Map, List} from 'immutable';
import modelsArrayToRecordList from '../../shared/services/modelsArrayToRecordList';
import PlayerModel from '../models/PlayerModel';
import {
  PLAYER_JOIN_GAME,
  PLAYER_LEAVE_GAME,
  PLAYER_GO,
  PLAYER_STOP,
  SERVER_GAME_ENDED,
  SERVER_GAME_OVER,
  SERVER_GAME_STARTING,
  SERVER_GAME_UPDATE,
  SERVER_GO,
  SERVER_STOP,
} from '../actions';
import {
  GAME_STARTING,
  STOP,
  GO,
  GAME_ENDED,
  GAME_OVER,
} from '../constants/GameCommands';

const initialState = new Map({
  players: new List(),
  serverCommand: null,
  startingCountdown: 0,
  inGame: false,
  moving: false,
  gameRunning: false,
});

export default stateReducer(initialState, {
  [PLAYER_JOIN_GAME]: state =>
    state.withMutations(map => map.set('inGame', true).set('moving', false)),

  [PLAYER_LEAVE_GAME]: state => state.set('inGame', false),

  [PLAYER_GO]: state => state.set('moving', true),

  [PLAYER_STOP]: state => state.set('moving', false),

  [SERVER_GAME_ENDED]: () => initialState.set('serverCommand', GAME_ENDED),

  [SERVER_GAME_OVER]: (state, payload) =>
    state.withMutations(map =>
      map
        .set('serverCommand', GAME_OVER)
        .set('inGame', false)
        .set('gameRunning', false)
        .set('players', modelsArrayToRecordList(payload, PlayerModel)),
    ),

  [SERVER_GAME_STARTING]: (state, payload) => {
    const {seconds, players} = payload;

    return state.withMutations(map =>
      map
        .set('serverCommand', GAME_STARTING)
        .set('startingCountdown', seconds)
        .set('players', modelsArrayToRecordList(players, PlayerModel)),
    );
  },

  [SERVER_GAME_UPDATE]: (state, payload) =>
    state.set('players', modelsArrayToRecordList(payload, PlayerModel)),

  [SERVER_GO]: state =>
    state.withMutations(map =>
      map.set('serverCommand', GO).set('gameRunning', true),
    ),

  [SERVER_STOP]: state => state.set('serverCommand', STOP),
});
