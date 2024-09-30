export default ({ model, sdkConfiguration, fieldConfiguration }) => {
    const value = model.value;
    if (!value || typeof value !== 'string') {
        return false;
    }

    return true;
};
