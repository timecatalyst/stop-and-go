import autoBind from 'class-autobind';
import React, {Component} from 'react';
import {connect} from 'react-redux';
import classNames from 'classnames';
import {serverCommandSelector, startingCountdownSelector} from '../selectors';
import {
  GAME_STARTING,
  STOP,
  GO,
  GAME_ENDED,
  GAME_OVER,
} from '../constants/GameCommands';

class ServerMessage extends Component {
  constructor(props, context) {
    super(props, context);

    autoBind(this);
  }

  getServerMessage() {
    switch (this.props.serverCommand) {
      case GAME_STARTING:
        return `Game starting in ${this.props.startingCountdown} seconds`;
      case STOP:
        return 'STOP!';
      case GO:
        return 'GO!';
      case GAME_ENDED:
        return 'All players have left, game ended';
      case GAME_OVER:
        return 'Game Over';
      default:
        return '';
    }
  }

  render() {
    const {serverCommand} = this.props;

    const message = this.getServerMessage();

    const messageClass = classNames('server-message', {
      'server-message__game-starting': serverCommand === GAME_STARTING,
      'server-message__stop': serverCommand === STOP,
      'server-message__go': serverCommand === GO,
    });

    return <div className={messageClass}>{message}</div>;
  }
}

function mapStateToProps(state) {
  return {
    serverCommand: serverCommandSelector(state),
    startingCountdown: startingCountdownSelector(state),
  };
}

export default connect(
  mapStateToProps,
  null,
)(ServerMessage);
