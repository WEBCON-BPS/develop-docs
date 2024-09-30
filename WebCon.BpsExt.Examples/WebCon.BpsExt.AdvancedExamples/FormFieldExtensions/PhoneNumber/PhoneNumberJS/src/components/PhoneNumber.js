import React, { useState, useCallback } from 'react';
import PropTypes from 'prop-types';
import Prefix from './Prefix';
import Number from './Number';

import './PhoneNumber.css';

const PhoneNumber = ({ data, onChange, fieldConfiguration }) => {
    const [phoneNumber, setPhoneNumber] = useState(() => {
        const result =
            /^([(][+]?[0-9]{1,3}[)]) ([\d]+|(([\d]+[ -]{1}[\d]*)+))$/gi.exec(
                data
            );

        if (result) {
            return {
                prefix: result[1].replace(/[^\d+]/g, ''),
                number: result[2],
                prevData: data,
            };
        } else {
            return { prefix: '', number: '', prevData: '' };
        }
    });
    const isReadOnly =
        fieldConfiguration.isDisabled && !fieldConfiguration.isAdmin;

    const setPrefix = useCallback(
        (value) => {
            setPhoneNumber((prevState) => ({ ...prevState, prefix: value }));
        },
        [setPhoneNumber]
    );

    const setNumber = useCallback(
        (value) => {
            setPhoneNumber((prevState) => ({ ...prevState, number: value }));
        },
        [setPhoneNumber]
    );

    const onBlur = useCallback(() => {
        const prefix =
            phoneNumber.prefix === '' ? '' : `(${phoneNumber.prefix})`;
        const valueToSet =
            prefix || phoneNumber.number
                ? `${prefix} ${phoneNumber.number}`
                : '';

        if (valueToSet != phoneNumber.prevData) {
            phoneNumber.prevData = valueToSet;
            onChange(valueToSet);
        }
    }, [
        phoneNumber.prefix,
        phoneNumber.number,
        phoneNumber.prevData,
        onChange,
    ]);

    const onResetButtonClick = useCallback(() => {
        setPhoneNumber({ prefix: '', number: '', prevData: '' });
        onChange('');
    }, [setPhoneNumber, onChange]);

    return (
        <div>
            <span className="phone-number--prefix-bracket left-bracket">(</span>
            <Prefix
                className="phone-number--prefix number-field"
                onBlur={onBlur}
                setPrefix={setPrefix}
                data={phoneNumber.prefix}
                isReadonly={isReadOnly}
            />
            <span className="phone-number--prefix-bracket right-bracket">
                )
            </span>
            <span className="phone-number--separator"></span>
            <Number
                className="phone-number--prefix phone-number--number number-field"
                onBlur={onBlur}
                setNumber={setNumber}
                data={phoneNumber.number}
                isReadonly={isReadOnly}
            />
            {!isReadOnly && (
                <button
                    className="phone-number--clear-btn"
                    type="button"
                    onClick={onResetButtonClick}
                >
                    <img className="clear-btn--image" src="assets/clear" />
                </button>
            )}
        </div>
    );
};

PhoneNumber.propTypes = {
    fieldConfiguration: PropTypes.object,
    data: PropTypes.string,
    onChange: PropTypes.func.isRequired,
};

export default PhoneNumber;
