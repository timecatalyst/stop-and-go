import toastr from 'toastr';
import {LEAVE_GAME} from '../constants/GameCommands';

export const PLAYER_LEAVE_GAME = 'PLAYER_LEAVE_GAME';

export function playerLeaveGame(connection) {
  return function(dispatch) {
    connection
      .invoke(LEAVE_GAME)
      .then(() => dispatch({type: PLAYER_LEAVE_GAME}))
      .catch(error => toastr.error(error.toString(), 'Error'));
  };
}
