using BrickPi3.Model.Types;
using System;
using System.Threading.Tasks;

namespace BrickPi3
{
    public partial class BrickPi3
    {
        public async Task Detect()
        {
            string manufacturer, board, vfw;
            manufacturer = await GetManufacturerAsync();
            board = await GetManufacturerAsync();
            vfw = await GetManufacturerAsync();

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
        public async Task<string> GetManufacturerAsync()
        {
            int[] message = new int[] { SpiAddress, (int)BpspiMessageType.GET_MANUFACTURER, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            return SpiTransfer(message);
        }
        #endregion

    }
}
