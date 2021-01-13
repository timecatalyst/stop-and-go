import * as signalR from '@aspnet/signalr';
import {
  GAME_STARTING,
  GO,
  STOP,
  UPDATE,
  GAME_ENDED,
  GAME_OVER,
} from '../constants/GameCommands';

export default function({
  serverGameStarting,
  serverGameUpdate,
  serverGameEnded,
  serverGameOver,
  serverGo,
  serverStop,
}) {
  const connection = new signalR.HubConnectionBuilder()
    .withUrl(`${process.env.API_BASE_URL}game-hub`)
    .build();

  connection.start().catch(err => {
    console.log(err.toString()); // eslint-disable-line no-console
  });

  connection.on(GAME_STARTING, seconds => serverGameStarting(seconds));
  connection.on(UPDATE, players => serverGameUpdate(players));
  connection.on(GAME_ENDED, () => serverGameEnded());
  connection.on(GAME_OVER, players => serverGameOver(players));
  connection.on(GO, () => serverGo());
  connection.on(STOP, () => serverStop());

  return connection;
}
