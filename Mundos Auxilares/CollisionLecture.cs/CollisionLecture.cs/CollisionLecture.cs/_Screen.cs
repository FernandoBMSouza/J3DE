using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollisionLecture.cs
{
    class _Screen
    {
        static _Screen instance;
        public int Width { get; set; }
        public int Height { get; set; }

        public static _Screen GetInstance()
        {
            if (instance == null) instance = new _Screen();
            return instance;
        }
    }
}
