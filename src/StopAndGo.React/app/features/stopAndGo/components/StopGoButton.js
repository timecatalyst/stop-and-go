import autoBind from 'class-autobind';
import React, {Component} from 'react';
import {connect} from 'react-redux';
import PropTypes from 'prop-types';
import {Button} from 'semantic-ui-react';
import {playerGo, playerStop} from '../actions';
import {
  gameRunningSelector,
  inGameSelector,
  movingSelector,
} from '../selectors';

class StopGoButton extends Component {
  constructor(props, context) {
    super(props, context);

    autoBind(this);
  }

  handleGo() {
    const {connection, playerGo} = this.props;
    playerGo(connection);
  }

  handleStop() {
    const {connection, playerStop} = this.props;
    playerStop(connection);
  }

  render() {
    const {gameRunning, inGame, moving} = this.props;

    return (
      <div className="stop-go-button">
        {inGame && gameRunning && (
          <Button onClick={moving ? this.handleStop : this.handleGo}>
            {moving ? 'STOP' : 'GO'}
          </Button>
        )}
      </div>
    );
  }
}

StopGoButton.propTypes = {
  connection: PropTypes.object.isRequired,
  inGame: PropTypes.bool,
  gameRunning: PropTypes.bool,
  moving: PropTypes.bool,
  playerGo: PropTypes.func,
  playerStop: PropTypes.func,
};

function mapStateToProps(state) {
  return {
    inGame: inGameSelector(state),
    gameRunning: gameRunningSelector(state),
    moving: movingSelector(state),
  };
}

export default connect(
  mapStateToProps,
  {playerGo, playerStop},
)(StopGoButton);
