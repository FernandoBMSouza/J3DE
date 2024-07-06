using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WorldName
{
    abstract class Letter : ITransform
    {
        protected Shape[] Shapes { get; set; }
        protected float rotationAngle;
        float speed;
        
        public Letter()
        {
            Shapes = null;
            rotationAngle = 0;
            speed = 100;
        }

        public virtual void Update(GameTime gameTime)
        {
            rotationAngle += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (Shape s in Shapes)
            {
                s.SetIdentity();
                s.Scale(new Vector3(1, 1, .5f));
            }
        }

        public void Draw(Camera camera)
        {
            foreach (Shape s in Shapes)
                s.Draw(camera);
        }

        public void SetIdentity()
        {
            foreach (Shape s in Shapes)
                s.SetIdentity();            
        }

        public void Translation(Vector3 position)
        {
            foreach (Shape s in Shapes)
                s.Translation(position);            
        }

        public void Scale(Vector3 scale)
        {
            foreach (Shape s in Shapes)
                s.Scale(scale);            
        }

        public void RotationX(float angle)
        {
            foreach (Shape s in Shapes)
                s.RotationX(angle);            
        }

        public void RotationY(float angle)
        {
            foreach (Shape s in Shapes)
                s.RotationY(angle);            
        }

        public void RotationZ(float angle)
        {
            foreach (Shape s in Shapes)
                s.RotationZ(angle);            
        }
    }
}
