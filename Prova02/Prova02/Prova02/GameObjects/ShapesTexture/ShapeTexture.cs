using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Prova02.Utilities;

namespace Prova02.GameObjects.ShapesTexture
{
    public abstract class ShapeTexture : GameObject
    {
        VertexBuffer buffer;
        protected VertexPositionTexture[] vertices;
        protected Effect effect;
        Texture2D texture;

        public ShapeTexture(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            this.texture = texture;
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

        public override void Draw(Camera camera)
        {
            if (vertices != null)
            {
                GetGame1().GraphicsDevice.SetVertexBuffer(buffer);

                effect.CurrentTechnique = effect.Techniques["Technique1"];
                effect.Parameters["World"].SetValue(GetWorld());
                effect.Parameters["View"].SetValue(camera.View);
                effect.Parameters["Projection"].SetValue(camera.Projection);
                effect.Parameters["colorTexture"].SetValue(texture);

                foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    GetGame1().GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
                                                                                        vertices,
                                                                                        0,
                                                                                        vertices.Length / 3);
                }
            }
            base.Draw(camera);
        }

        public Effect GetEffect() { return effect; }
        public void SetEffect(Effect value) { this.effect = value; }
    }
}
