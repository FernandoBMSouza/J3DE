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
        protected Effect effect;
        Texture2D texture, winterTexture;

        public Shape(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, Texture2D winterTexture, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            this.texture = texture;
            this.winterTexture = winterTexture;
            this.effect = effect;
            if (vertices != null)
            {
                buffer = new VertexBuffer(GetGame1().GraphicsDevice,
                                          typeof(VertexPositionTexture),
                                          vertices.Length,
                                          BufferUsage.None);

                buffer.SetData<VertexPositionTexture>(vertices);
            }
        }

        public override void Draw(Camera camera, GameTime gameTime)
        {
            if (vertices != null)
            {
                GetGame1().GraphicsDevice.SetVertexBuffer(buffer);

                effect.CurrentTechnique = effect.Techniques["Technique1"];
                effect.Parameters["World"].SetValue(GetWorld());
                effect.Parameters["View"].SetValue(camera.View);
                effect.Parameters["Projection"].SetValue(camera.Projection);
                //effect.Parameters["colorTexture"].SetValue(texture);
                effect.Parameters["normalTexture"].SetValue(texture);
                effect.Parameters["winterTexture"].SetValue(winterTexture);
                float gt = (float)(gameTime.TotalGameTime.TotalSeconds % 10) / 10;
                effect.Parameters["gameTime"].SetValue(gt);

                foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    GetGame1().GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
                                                                                        vertices,
                                                                                        0,
                                                                                        vertices.Length / 3);
                }
            }
            base.Draw(camera, gameTime);
        }
    }
}
