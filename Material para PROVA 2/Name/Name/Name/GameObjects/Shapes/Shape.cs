using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Name.Utilities;

namespace Name.GameObjects.Shapes
{
    public abstract class Shape : GameObject
    {
        VertexBuffer buffer;
        protected VertexPositionColor[] vertices;

        public Shape(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            if (vertices != null)
            {
                buffer = new VertexBuffer(GetGame1().GraphicsDevice,
                                          typeof(VertexPositionColor),
                                          vertices.Length,
                                          BufferUsage.None);

                buffer.SetData<VertexPositionColor>(vertices);
            }
        }

        public override void Draw(Camera camera, BasicEffect effect)
        {
            if (vertices != null)
            {
                GetGame1().GraphicsDevice.SetVertexBuffer(buffer);
                effect.World = GetWorld();
                effect.View = camera.View;
                effect.Projection = camera.Projection;

                effect.VertexColorEnabled = true;
                foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    GetGame1().GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                                                                                vertices,
                                                                                0,
                                                                                vertices.Length / 3);
                }
                effect.VertexColorEnabled = false;
            }
            base.Draw(camera, effect);
        }
    }
}
