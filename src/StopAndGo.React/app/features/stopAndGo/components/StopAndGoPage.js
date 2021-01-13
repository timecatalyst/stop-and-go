import autoBind from 'class-autobind';
import React, {Component} from 'react';
import {connect} from 'react-redux';
import {
  serverGo,
  serverStop,
  serverGameEnded,
  serverGameOver,
  serverGameStarting,
  serverGameUpdate,
} from '../actions';
import initializeGameHub from '../services/initializeGameHub';
import JoinLeaveGame from './JoinLeaveGame';
import ServerMessage from './ServerMessage';
import StopGoButton from './StopGoButton';
import GameBoard from './GameBoard';

class StopAndGoPage extends Component {
  constructor(props, context) {
    super(props, context);

    autoBind(this);
  }

  componentWillMount() {
    this.connection = initializeGameHub(this.props);
  }

  render() {
    return (
      <div className="game-hub-page">
        <div className="game-hub-page__header">
          <JoinLeaveGame connection={this.connection} />
          <h2>Stop &amp; Go</h2>
          <div>
            <i>Thanks, I hate it.</i>
            <br />
            <strong>- Mr. Headroom</strong>
          </div>
        </div>

        <ServerMessage />

        <StopGoButton connection={this.connection} />

        <GameBoard />
      </div>
    );
  }
}

export default connect(
  null,
  {
    serverGameEnded,
    serverGameOver,
    serverGameStarting,
    serverGameUpdate,
    serverGo,
    serverStop,
  },
)(StopAndGoPage);
