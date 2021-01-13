export const SERVER_GAME_STARTING = 'SERVER_GAME_STARTING';

export function serverGameStarting(seconds) {
  return {
    type: SERVER_GAME_STARTING,
    payload: seconds,
  };
}
