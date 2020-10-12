namespace BrickPi3.Model.States
{
    public enum SensorState
    {
        VALID_DATA = 0,
        NOT_CONFIGURED = 1,
        CONFIGURING = 2,
        NO_DATA = 3,
        I2C_ERROR = 4
    }
}
