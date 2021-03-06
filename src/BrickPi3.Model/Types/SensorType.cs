﻿namespace BrickPi3.Model.Types
{
    public enum SensorType
    {
        NONE = 1,
        I2C = 2,
        CUSTOM = 3,

        TOUCH = 4,
        NXT_TOUCH = 5,
        EV3_TOUCH = 6,

        NXT_LIGHT_ON = 7,
        NXT_LIGHT_OFF = 8,

        NXT_COLOR_RED = 9,
        NXT_COLOR_GREEN = 10,
        NXT_COLOR_BLUE = 11,
        NXT_COLOR_FULL = 12,
        NXT_COLOR_OFF = 13,

        NXT_ULTRASONIC = 14,

        EV3_GYRO_ABS = 15,
        EV3_GYRO_DPS = 16,
        EV3_GYRO_ABS_DPS = 17,

        EV3_COLOR_REFLECTED = 18,
        EV3_COLOR_AMBIENT = 19,
        EV3_COLOR_COLOR = 20,
        EV3_COLOR_RAW_REFLECTED = 21,
        EV3_COLOR_COLOR_COMPONENTS = 22,

        EV3_ULTRASONIC_CM = 23,
        EV3_ULTRASONIC_INCHES = 24,
        EV3_ULTRASONIC_LISTEN = 25,

        EV3_INFRARED_PROXIMITY = 26,
        EV3_INFRARED_SEEK = 27,
        EV3_INFRARED_REMOTE = 28
    }
}
