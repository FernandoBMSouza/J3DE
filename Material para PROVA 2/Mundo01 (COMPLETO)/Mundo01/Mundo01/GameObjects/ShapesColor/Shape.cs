using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Mundo01.Utilities;

namespace Mundo01.GameObjects.Shapes
{
    public abstract class Shape : GameObject
    {
        VertexBuffer buffer;
        protected VertexPositionColor[] vertices;
        Effect effect;
        Color color;

        public Shape(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            this.effect = effect;
            this.color = color;
            if (vertices != null)
            {
                buffer = new VertexBuffer(GetGame1().GraphicsDevice,
                                          typeof(VertexPositionColor),
                                          vertices.Length,
                                          BufferUsage.None);

                buffer.SetData<VertexPositionColor>(vertices);
            }
        }

        public override void Draw(Camera camera)
        {
            if (vertices != null)
            {
                GetGame1().GraphicsDevice.SetVertexBuffer(buffer);
                effect.CurrentTechnique = effect.Techniques["Technique1"];
                effect.Parameters["World"].SetValue(GetWorld());
                effect.Parameters["View"].SetValue(camera.View);
                effect.Parameters["Projection"].SetValue(camera.Projection);
                effect.Parameters["objectColor"].SetValue(color.ToVector4());

                foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    GetGame1().GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                                                                                vertices,
                                                                                0,
                                                                                vertices.Length / 3);
                }
            }
            base.Draw(camera);
        }
    }
}
