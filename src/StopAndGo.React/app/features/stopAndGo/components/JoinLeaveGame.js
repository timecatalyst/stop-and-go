import autoBind from 'class-autobind';
import React, {Component} from 'react';
import {connect} from 'react-redux';
import PropTypes from 'prop-types';
import {playerJoinGame, playerLeaveGame} from '../actions';
import {inGameSelector} from '../selectors';
import TextInput from '../../shared/components/TextInput';
import {Button} from 'semantic-ui-react';

class JoinGame extends Component {
  constructor(props, context) {
    super(props, context);

    autoBind(this);

    this.state = {playerName: ''};
  }

  handleFieldChange(event) {
    this.setState({playerName: event.target.value});
  }

  handleJoin() {
    const {playerJoinGame, connection} = this.props;
    playerJoinGame(connection, this.state.playerName);
  }

  handleLeave() {
    const {playerLeaveGame, connection} = this.props;
    playerLeaveGame(connection);
  }

  render() {
    const {inGame} = this.props;

    return (
      <div className="join-leave-game">
        {!inGame && (
          <TextInput
            id="playerName"
            value={this.state.playerName}
            onChange={this.handleFieldChange}
          />
        )}
        <Button onClick={inGame ? this.handleLeave : this.handleJoin}>
          {inGame ? 'Leave' : 'Join'} Game
        </Button>
      </div>
    );
  }
}

JoinGame.propTypes = {
  connection: PropTypes.object.isRequired,
  inGame: PropTypes.bool,
  playerJoinGame: PropTypes.func,
  playerLeaveGame: PropTypes.func,
};

function mapStateToProps(state) {
  return {
    inGame: inGameSelector(state),
  };
}

export default connect(
  mapStateToProps,
  {playerJoinGame, playerLeaveGame},
)(JoinGame);
