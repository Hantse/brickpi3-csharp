using BrickPi3.Model;
using BrickPi3.Model.Types;
using System;

namespace BrickPi3
{
    public partial class BrickPi3
    {
        public void Detect()
        {
            string manufacturer, board, vfw;
            manufacturer = GetManufacturer();
            board = GetBoard();
            vfw = GetFirmwareVersion();

            if (manufacturer != "Dexter Industries" || board != "BrickPi3")
            {
                throw new Exception("No SPI response.");
            }
            else if (vfw.Split('.')[0] != FIRMWARE_VERSION_REQUIRED.Split('.')[0]
                    || vfw.Split('.')[1] != FIRMWARE_VERSION_REQUIRED.Split('.')[0])
            {
                throw new Exception($"BrickPi3 firmware needs to be version {FIRMWARE_VERSION_REQUIRED} but is currently version {vfw}");
            }
        }

        #region Board Informations
        public string GetManufacturer()
        {
            int[] message = new int[] { SpiAddress, (int)BpspiMessageType.GET_MANUFACTURER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            return SpiTransfer(message);
        }

        public string GetBoard()
        {
            int[] message = new int[] { SpiAddress, (int)BpspiMessageType.GET_NAME, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            return SpiTransfer(message);
        }

        public string GetHardwareVersion()
        {
            int[] message = new int[] { SpiAddress, (int)BpspiMessageType.GET_HARDWARE_VERSION, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            return SpiTransfer(message);
        }

        public string GetFirmwareVersion()
        {
            int[] message = new int[] { SpiAddress, (int)BpspiMessageType.GET_FIRMWARE_VERSION, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            return SpiTransfer(message);
        }
        public string GetId()
        {
            int[] message = new int[] { SpiAddress, (int)BpspiMessageType.GET_ID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            return SpiTransfer(message);
        }
        #endregion

        #region Motors
        public void SetMotorPower(int port, int power)
        {
            int[] message = new int[] { SpiAddress, (int)BpspiMessageType.SET_MOTOR_POWER, port, power };
            SpiTransfer(message);
        }

        public void SetMotorPosition(int port, int position)
        {
            int[] message = new int[] { SpiAddress, (int)BpspiMessageType.SET_MOTOR_POSITION, port, ((position >> 24) & 0xFF), ((position >> 16) & 0xFF), ((position >> 8) & 0xFF), (position & 0xFF) };
            SpiTransfer(message);
        }

        public void SetMotorDps(int port, int dps)
        {
            int[] message = new int[] { SpiAddress, (int)BpspiMessageType.SET_MOTOR_POSITION, port, ((dps >> 8) & 0xFF), (dps & 0xFF) };
            SpiTransfer(message);
        }

        public (int status, int speed, int encoder, int dps) GetMotorStatus(int port)
        {
            BpspiMessageType message_type;
            if (port == this.PortA)
            {
                message_type = BpspiMessageType.GET_MOTOR_A_STATUS;
            }
            else if (port == PortB)
            {
                message_type = BpspiMessageType.GET_MOTOR_B_STATUS;
            }
            else if (port == PortC)
            {
                message_type = BpspiMessageType.GET_MOTOR_C_STATUS;
            }
            else if (port == PortD)
            {
                message_type = BpspiMessageType.GET_MOTOR_D_STATUS;
            }
            else
            {
                throw new IOException("get_motor_status error. Must be one motor port at a time. PORT_A, PORT_B, PORT_C, or PORT_D.");
            }

            int[] message = new int[] { SpiAddress, (int)message_type, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var messageResponse = SpiTransfer(message);
            var responseAsCharArray = messageResponse.ToCharArray();

            if(responseAsCharArray[3] == 0xA5)
            {
                var speed = int.Parse($"{(responseAsCharArray[5])}");
                var encoder = int.Parse($"{((responseAsCharArray[6] << 24)| (responseAsCharArray[7] << 16) | (responseAsCharArray[8] << 8) | responseAsCharArray[9])}");
                var dps = int.Parse($"{((responseAsCharArray[10] << 8) | responseAsCharArray[11])}");

                return (int.Parse($"{(responseAsCharArray[4])}"), speed, encoder, dps);
            }

            throw new IOException("No SPI response");
        }
        #endregion
    }
}
