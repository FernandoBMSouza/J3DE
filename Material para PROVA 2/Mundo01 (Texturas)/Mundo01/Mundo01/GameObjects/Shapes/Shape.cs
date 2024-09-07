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
        protected VertexPositionTexture[] vertices;
        Texture2D texture;

        public Shape(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Texture2D texture, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            this.texture = texture;
            if (vertices != null)
            {
                buffer = new VertexBuffer(GetGame1().GraphicsDevice,
                                          typeof(VertexPositionTexture),
                                          vertices.Length,
                                          BufferUsage.None);

                buffer.SetData<VertexPositionTexture>(vertices);
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
                effect.Texture = texture;

                effect.TextureEnabled = true;
                foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    GetGame1().GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
                                                                                        vertices,
                                                                                        0,
                                                                                        vertices.Length / 3);
                }
                effect.TextureEnabled = false;
            }
            base.Draw(camera, effect);
        }
    }
}
