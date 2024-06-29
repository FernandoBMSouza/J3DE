using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    abstract class BaseModel : ITransform
    {
        Matrix world;

        protected Model Model { get; set; }

        public BaseModel()
        {
            Model = null;
            SetIdentity();
        }

        public void Update(GameTime gameTime) { }

        public void Draw(Camera camera)
        {
            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (BasicEffect be in mesh.Effects)
                {
                    be.EnableDefaultLighting();
                    be.World = world * mesh.ParentBone.Transform;
                    be.View = camera.View;
                    be.Projection = camera.Projection;
                }
                mesh.Draw();
            }
        }

        public void SetIdentity()
        {
            world = Matrix.Identity;
        }

        public void Translation(Vector3 position)
        {
            world *= Matrix.CreateTranslation(position);
        }

        public void Scale(Vector3 scale)
        {
            world *= Matrix.CreateScale(scale);
        }

        public void RotationX(float angle)
        {
            world *= Matrix.CreateRotationX(MathHelper.ToRadians(angle));
        }

        public void RotationY(float angle)
        {
            world *= Matrix.CreateRotationY(MathHelper.ToRadians(angle));
        }

        public void RotationZ(float angle)
        {
            world *= Matrix.CreateRotationZ(MathHelper.ToRadians(angle));
        }
    }
}
