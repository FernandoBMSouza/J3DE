using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Prova02.Utilities;
using Microsoft.Xna.Framework.Graphics;

namespace Prova02.GameObjects.Models
{
    public abstract class Model3D : GameObject
    {
        protected Model model;

        public Model3D(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {

        }

        public override void Draw(Camera camera)
        {
            if (model != null)
            {
                foreach (ModelMesh mesh in model.Meshes)
                {
                    foreach (BasicEffect be in mesh.Effects)
                    {
                        be.EnableDefaultLighting();
                        be.World = GetWorld();
                        be.View = camera.View;
                        be.Projection = camera.Projection;
                    }
                    mesh.Draw();
                }
            }
            base.Draw(camera);
        }
    }
}
