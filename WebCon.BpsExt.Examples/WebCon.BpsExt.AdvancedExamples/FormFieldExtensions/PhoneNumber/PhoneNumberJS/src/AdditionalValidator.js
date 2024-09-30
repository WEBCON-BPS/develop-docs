const phoneNumberPattern = /^([(][+]?[0-9]{1,3}[)]) ([\d]+|(([\d]+[ -]{1}[\d]*)+))$/

const AdditionalValidator = ({ model, sdkConfiguration, fieldConfiguration }) => {

    const value = model.value;

    if (!value || (typeof value === 'string' && value === '')) {
        return {
            isValid: true,
        };
    } 
    
    if (typeof value !== 'string') {
        return {
            isValid: false,
            errorMessage: 'Invalid model',
        };
    }

    const result = phoneNumberPattern.exec(value)
    var errorMessage = '';

    if (!result) {
        errorMessage = "Invalid number. Prefix and number must contain at least one digit (with optional '+' at the prefix beginning)."
    } else {
        var prefix = result[1];
        var number = result[2];

        if (number.endsWith("-")) {
            errorMessage = "Number part cannot end with '-'.";
        } else if (prefix.match(/^\([+]*0+\)$/)) {
            errorMessage = "Prefix part cannot contain only zeros."
        }
    }
    
    return {
        isValid: errorMessage === '',
        errorMessage: errorMessage
    };
};

export default AdditionalValidator;