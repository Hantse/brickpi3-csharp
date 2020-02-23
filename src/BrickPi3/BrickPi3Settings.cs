using BrickPi3.Model.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrickPi3
{
    public partial class BrickPi3
    {
        private const string FIRMWARE_VERSION_REQUIRED = "1.4.x";

        #region Port
        public int Port1 { get; set; } = 0x01;
        public int Port2 { get; set; } = 0x02;
        public int Port3 { get; set; } = 0x04;
        public int Port4 { get; set; } = 0x08;

        public int PortA { get; set; } = 0x01;
        public int PortB { get; set; } = 0x02;
        public int PortC { get; set; } = 0x04;
        public int PortD { get; set; } = 0x08;
        #endregion

        #region Motor Configuration
        public int MotorFloat { get; set; } = -128;
        #endregion

        #region Sensors
        public SensorType[] SensorType { get; set; } = new SensorType[4] { 0, 0, 0, 0 };
        public int[] I2CInBytes { get; set; } = new int[4] { 0, 0, 0, 0 };
        #endregion

        #region SPI
        public short SpiAddress { get; set; }
        #endregion
    }
}
