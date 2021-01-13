export const SERVER_GAME_UPDATE = 'SERVER_GAME_UPDATE';

export function serverGameUpdate(players) {
  return {
    type: SERVER_GAME_UPDATE,
    payload: players,
  };
}
