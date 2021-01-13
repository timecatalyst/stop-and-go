import isNil from 'lodash/isNil';
import {List, Map} from 'immutable';
import React, {PureComponent} from 'react';
import PropTypes from 'prop-types';
import {Form} from 'semantic-ui-react';

export default class Input extends PureComponent {
  render() {
    const {id, formValidationErrors, value, ...rest} = this.props;

    const validationErrors =
      (formValidationErrors && formValidationErrors.get(id)) || List();

    return (
      <Form.Field
        control="input"
        id={id}
        name={id}
        value={isNil(value) ? '' : value}
        error={Boolean(validationErrors.size)}
        {...rest}
      />
    );
  }
}

Input.propTypes = {
  formValidationErrors: PropTypes.instanceOf(Map),
  id: PropTypes.string.isRequired,
  value: PropTypes.oneOfType([PropTypes.string, PropTypes.number]),
};
