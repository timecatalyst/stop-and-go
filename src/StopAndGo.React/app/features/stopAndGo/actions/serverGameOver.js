export const SERVER_GAME_OVER = 'SERVER_GAME_OVER';

export function serverGameOver(players) {
  return {
    type: SERVER_GAME_OVER,
    payload: players,
  };
}
