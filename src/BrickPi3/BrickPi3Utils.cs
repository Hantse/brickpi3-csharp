using System;
using System.Text;
using Unosquare.RaspberryIO;

namespace BrickPi3
{
    public partial class BrickPi3
    {
        private string SpiTransfer(int[] inputMessage)
        {
            byte[] result = new byte[inputMessage.Length * sizeof(int)];
            Buffer.BlockCopy(inputMessage, 0, result, 0, result.Length);

            var response = Pi.Spi.Channel0.SendReceive(result);
            return Encoding.ASCII.GetString(response);
        }
    }
}
