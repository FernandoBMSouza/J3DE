using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaXNA3D001
{
    public class _Screen
    {
        private int WIDTH;
        private int HEIGHT;
        private static _Screen instance;

        private _Screen()
        {
        }

        public static _Screen GetInstance()
        {
            if (instance == null)
            {
                instance = new _Screen();
            }

            return instance;
        }

        public void SetWidth(int width)
        {
            WIDTH = width;
        }

        public int GetWidth()
        {
            return WIDTH;
        }

        public void SetHeight(int height)
        {
            HEIGHT = height;
        }

        public int GetHeight()
        {
            return HEIGHT;
        }
    }
}
