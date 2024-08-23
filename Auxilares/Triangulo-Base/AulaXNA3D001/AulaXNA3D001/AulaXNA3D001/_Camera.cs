using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace AulaXNA3D001
{
    public class _Camera
    {
        private Matrix view;
        private Matrix projection;

        private Vector3 position;
        private Vector3 target;
        private Vector3 up;

        public _Camera()
        {
            this.position = Vector3.Backward * 5;
            this.target = Vector3.Zero;
            this.up = Vector3.Up;
            this.SetupView(this.position, this.target, this.up);

            this.SetupProjection();
        }

        public void SetupView(Vector3 position, Vector3 target, Vector3 up)
        {
            this.view = Matrix.CreateLookAt(position, target, up);
        }

        public void SetupProjection()
        {
            _Screen screen = _Screen.GetInstance();

            this.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                                  screen.GetWidth()/(float)screen.GetHeight(),
                                                                  0.0000001f,
                                                                  1000);
        }

        public Matrix GetView()
        {
            return this.view;
        }

        public Matrix GetProjection()
        {
            return this.projection;
        }
    }
}
