import React, { useCallback } from "react";
import PropTypes from "prop-types";
import "./PhoneNumber.css";

const numberPattern = /^([\d]*|(([\d]+[ -]{1}[\d]*)*))$/;

function Number ({ data, setNumber, onBlur, className, isReadonly }) {
  const numberOnChange = useCallback((e) => {
    const value = e.target.value;

    if (numberPattern.test(value)) {
      setNumber(value);
    }
  }, [numberPattern, setNumber]);

  return (
    <input
      type="text"
      className={className}
      value={data}
      onChange={numberOnChange}
      onBlur={onBlur}
      disabled={isReadonly}
    />
  );
}

Number.propTypes = {
  data: PropTypes.string.isRequired,
  setNumber: PropTypes.func.isRequired,
  className: PropTypes.string,
  onBlur: PropTypes.func,
  isReadonly: PropTypes.bool,
};

export default React.memo(Number);
