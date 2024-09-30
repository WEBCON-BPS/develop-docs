import React, { useCallback } from "react";
import PropTypes from "prop-types";
import "./PhoneNumber.css";

const prefixPattern = /^[+]?[0-9]{0,3}$/;

function Prefix({ data, setPrefix, onBlur, className, isReadonly }) {
  const prefixOnChange = useCallback((e) => {
    const value = e.target.value;

    if (prefixPattern.test(value)) {
      setPrefix(value);
    }
  }, [prefixPattern, setPrefix]);

  return (
    <input
      type="text"
      className={className}
      value={data}
      onChange={prefixOnChange}
      onBlur={onBlur}
      disabled={isReadonly}
    ></input>
  );
}

Prefix.propTypes = {
  data: PropTypes.string.isRequired,
  setPrefix: PropTypes.func.isRequired,
  className: PropTypes.string,
  onBlur: PropTypes.func,
  isReadonly: PropTypes.bool,
};

export default React.memo(Prefix);
