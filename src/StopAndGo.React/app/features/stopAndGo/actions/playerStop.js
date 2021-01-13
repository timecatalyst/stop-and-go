import toastr from 'toastr';
import {STOP} from '../constants/GameCommands';

export const PLAYER_STOP = 'PLAYER_STOP';

export function playerStop(connection) {
  return function(dispatch) {
    connection
      .invoke(STOP)
      .then(() => dispatch({type: PLAYER_STOP}))
      .catch(error => toastr.error(error.toString(), 'Error'));
  };
}
