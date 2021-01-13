import toastr from 'toastr';
import {GO} from '../constants/GameCommands';

export const PLAYER_GO = 'PLAYER_GO';

export function playerGo(connection) {
  return function(dispatch) {
    connection
      .invoke(GO)
      .then(() => dispatch({type: PLAYER_GO}))
      .catch(error => toastr.error(error.toString(), 'Error'));
  };
}
