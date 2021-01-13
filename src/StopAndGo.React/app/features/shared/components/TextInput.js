import Input from './Input';
import {Map} from 'immutable';
import React from 'react';
import PropTypes from 'prop-types';

export default function TextInput(props) {
  return <Input type="text" {...props} />;
}

TextInput.propTypes = {
  autoFocus: PropTypes.bool,
  disabled: PropTypes.bool,
  formValidationErrors: PropTypes.instanceOf(Map),
  id: PropTypes.string.isRequired,
  label: PropTypes.oneOfType([PropTypes.node, PropTypes.object]),
  maxLength: PropTypes.number,
  onChange: PropTypes.func,
  placeholder: PropTypes.string,
  readOnly: PropTypes.bool,
  required: PropTypes.bool,
  value: PropTypes.oneOfType([PropTypes.string, PropTypes.number]),
};
