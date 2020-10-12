using System.IO;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;

namespace BrickPi3
{
    public partial class BrickPi3
    {
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
    }
}
