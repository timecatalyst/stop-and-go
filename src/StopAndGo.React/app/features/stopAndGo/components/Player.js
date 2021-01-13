import React from 'react';
import PropTypes from 'prop-types';
import PlayerModel from '../models/PlayerModel';
import KnightImage from '../../shared/images/knight.gif';

export default function Player({model}) {
  const progress = (model.position / 20) * 100;

  const progressStyle = {
    backgroundColor: model.color,
    width: `${progress}%`,
  };

  return (
    <div className="player">
      <div className="player__name">{model.name}</div>
      <div className="player__progress" style={progressStyle} />
      <div className="player__knight">
        <img src={KnightImage} />
      </div>
    </div>
  );
}

Player.propTypes = {
  model: PropTypes.instanceOf(PlayerModel).isRequired,
};
