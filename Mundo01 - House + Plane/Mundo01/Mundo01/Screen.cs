﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mundo01
{
    class Screen
    {
        static Screen instance;
        public int Width { get; set; }
        public int Height { get; set; }

        public static Screen GetInstance()
        {
            if (instance == null)
                instance = new Screen();

            return instance;
        }
    }
}
