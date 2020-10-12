using System;
using System.Collections.Generic;
using System.Text;

namespace BrickPi3.Model
{
    public class IOException : Exception
    {
        public IOException()
        {

        }

        public IOException(string error) : base(error)
        {

        }
    }
}
