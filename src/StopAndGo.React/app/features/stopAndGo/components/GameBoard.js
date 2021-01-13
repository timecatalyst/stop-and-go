import React from 'react';
import {connect} from 'react-redux';
import {playersArraySelector} from '../selectors';
import Player from './Player';

function GameBoard({players}) {
  if (players.length <= 0) return null;

  return (
    <div className="game-board">
      {players.map((p, i) => (
        <Player key={i} model={p} />
      ))}
    </div>
  );
}

function mapStateToProps(state) {
  return {
    players: playersArraySelector(state),
  };
}

export default connect(
  mapStateToProps,
  null,
)(GameBoard);
