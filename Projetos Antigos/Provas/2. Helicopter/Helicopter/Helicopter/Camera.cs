using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Helicopter
{
    public class Camera
    {

        public Matrix View { get; private set; }
        public Matrix Projection { get; private set; }

        private Vector3 position;
        private Vector3 target;
        private Vector3 up;

        public Camera()
        {
            this.position = new Vector3(0, 5, 10);
            this.target = Vector3.Zero;
            this.up = Vector3.Up;
            this.SetupView(this.position, this.target, this.up);

            this.SetupProjection();
        }

        public void SetupView(Vector3 position, Vector3 target, Vector3 up)
        {
            View = Matrix.CreateLookAt(position, target, up);
        }

        public void SetupProjection()
        {
            Screen screen = Screen.GetInstance();

            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                                  screen.Width / (float)screen.Height,
                                                                  0.1f,
                                                                  100f);
        }
    }
}
