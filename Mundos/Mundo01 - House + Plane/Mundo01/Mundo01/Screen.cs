using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mundo01
{
    class Screen
    {
        static Screen instance;
        public int width;
        public int height;

        public static Screen GetInstance()
        {
            if (instance == null)
                instance = new Screen();

            return instance;
        }
    }
}
