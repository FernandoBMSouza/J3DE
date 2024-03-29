using Microsoft.Xna.Framework;

namespace Mundo02
{
    class Camera
    {
        private Matrix view;
        private Matrix projection;

        private Vector3 position;
        private Vector3 target;
        private Vector3 up;

        public Camera()
        {
            this.position = new Vector3(0, 10, 30);
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
            Screen screen = Screen.GetInstance();

            this.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                                  screen.Width/(float)screen.Height,
                                                                  1,
                                                                  100);
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
