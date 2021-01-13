import toastr from 'toastr';
import {JOIN_GAME} from '../constants/GameCommands';

export const PLAYER_JOIN_GAME = 'PLAYER_JOIN_GAME';

export function playerJoinGame(connection, playerName) {
  return function(dispatch) {
    connection
      .invoke(JOIN_GAME, playerName)
      .then(() => dispatch({type: PLAYER_JOIN_GAME}))
      .catch(error => toastr.error(error.toString(), 'Error'));
  };
}
