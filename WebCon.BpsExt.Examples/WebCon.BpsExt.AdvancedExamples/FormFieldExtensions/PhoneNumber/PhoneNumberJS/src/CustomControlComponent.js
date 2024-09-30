import React, { useCallback } from 'react';
import PropTypes from 'prop-types';
import PhoneNumber from './components/PhoneNumber';

const CustomControlComponent = ({ fieldConfiguration, model, onChange, sdkConfiguration }) => {

    const onChangeValue = useCallback(
        (newValue) => {
            onChange({ value: newValue });
        }
    );

    const value = model.value;

    if (fieldConfiguration.editMode === 'ReadOnlyHtml' && !fieldConfiguration.isAdmin) {
        return <span className="form-control-readonly">{value}</span>;
    } else {
        return (
            <PhoneNumber
                data={value}
                onChange={onChangeValue}
                fieldConfiguration={fieldConfiguration}
            />
        );
    }
};

CustomControlComponent.propTypes = {
    fieldConfiguration: PropTypes.shape({
        displayName: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired,
        isRequired: PropTypes.bool.isRequired,
        editMode: PropTypes.oneOf(['Edit', 'ReadOnly', 'ReadOnlyHtml'])
            .isRequired,
        isNew: PropTypes.bool.isRequired,
        isAdmin: PropTypes.bool.isRequired,
        isDisabled: PropTypes.bool.isRequired,
    }).isRequired,
    model: PropTypes.any,
    onChange: PropTypes.func.isRequired,
    sdkConfiguration: PropTypes.object,
};

export default CustomControlComponent;
