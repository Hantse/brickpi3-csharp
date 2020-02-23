namespace BrickPi3.Model.Types
{
    public enum BpspiMessageType
    {
        NONE = 0,

        GET_MANUFACTURER = 1,
        GET_NAME = 2,
        GET_HARDWARE_VERSION = 3,
        GET_FIRMWARE_VERSION = 4,
        GET_ID = 5,
        SET_LED = 6,
        GET_VOLTAGE_3V3 = 7,
        GET_VOLTAGE_5V = 8,
        GET_VOLTAGE_9V = 9,
        GET_VOLTAGE_VCC = 10,
        SET_ADDRESS = 11,

        SET_SENSOR_TYPE = 12,

        GET_SENSOR_1 = 13,
        GET_SENSOR_2 = 14,
        GET_SENSOR_3 = 15,
        GET_SENSOR_4 = 16,

        I2C_TRANSACT_1 = 17,
        I2C_TRANSACT_2 = 18,
        I2C_TRANSACT_3 = 19,
        I2C_TRANSACT_4 = 20,

        SET_MOTOR_POWER = 21,

        SET_MOTOR_POSITION = 22,

        SET_MOTOR_POSITION_KP = 23,

        SET_MOTOR_POSITION_KD = 24,

        SET_MOTOR_DPS = 25,

        SET_MOTOR_DPS_KP = 26,

        SET_MOTOR_DPS_KD = 27,

        SET_MOTOR_LIMITS = 28,

        OFFSET_MOTOR_ENCODER = 29,

        GET_MOTOR_A_ENCODER = 30,
        GET_MOTOR_B_ENCODER = 31,
        GET_MOTOR_C_ENCODER = 32,
        GET_MOTOR_D_ENCODER = 33,

        GET_MOTOR_A_STATUS = 34,
        GET_MOTOR_B_STATUS = 35,
        GET_MOTOR_C_STATUS = 36,
        GET_MOTOR_D_STATUS = 37
    }
}
