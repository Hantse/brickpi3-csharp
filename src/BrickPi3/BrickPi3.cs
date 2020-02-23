using BrickPi3.Model;
using BrickPi3.Model.Types;
using System;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;

namespace BrickPi3
{
    public class BrickPi3
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

        public BrickPi3(short address = 1)
        {
            if (address < 1 || address > 255)
            {
                throw new IOException("Error: SPI address must be in the range of 1 to 255");
            }

            SpiAddress = address;

            Pi.Spi.Channel0Frequency = SpiChannel.MinFrequency;
            var request = System.Text.Encoding.ASCII.GetBytes("HELLO!");
            var response = Pi.Spi.Channel0.SendReceive(request);
        }

        public async Task Detect()
        {
            string manufacturer, board, vfw;
            manufacturer = await GetManufacturerAsync();
            board = await GetManufacturerAsync();
            vfw = await GetManufacturerAsync();

            if (manufacturer != "Dexter Industries" || board != "BrickPi3")
            {
                //reject('No SPI response');
            }
            else if (vfw.Split('.')[0] != FIRMWARE_VERSION_REQUIRED.Split('.')[0] 
                    || vfw.Split('.')[1] != FIRMWARE_VERSION_REQUIRED.Split('.')[0])
            {
                //reject('BrickPi3 firmware needs to be version ' + FIRMWARE_VERSION_REQUIRED + ' but is currently version ' + vfw);
            }
        }

        #region Board Informations
        public async Task<string> GetManufacturerAsync()
        {
            int[] message = new int[] { SpiAddress, (int)BpspiMessageType.GET_MANUFACTURER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            return SpiTransfer(message);
        }
        #endregion


        private string SpiTransfer(int[] inputMessage)
        {
            byte[] result = new byte[inputMessage.Length * sizeof(int)];
            Buffer.BlockCopy(inputMessage, 0, result, 0, result.Length);

            var response = Pi.Spi.Channel0.SendReceive(result);
            return System.Text.Encoding.ASCII.GetString(response);
        }
    }
}
