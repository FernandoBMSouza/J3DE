using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    abstract class GameObject
    {
        private GraphicsDevice device;
        private VertexBuffer buffer;
        private BasicEffect effect;
        private Texture2D texture;
        private VertexPositionTexture[] vertices;

        protected Matrix world;

        public GameObject(GraphicsDevice device, Texture2D texture)
        {
            this.device = device;
            this.texture = texture;

            world = Matrix.Identity;

            vertices = GenerateVertices();

            buffer = new VertexBuffer(device, typeof(VertexPositionTexture), vertices.Length, BufferUsage.None);
            buffer.SetData<VertexPositionTexture>(vertices);

            effect = new BasicEffect(device);
        }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(Camera camera)
        {
            Draw(camera, new Matrix[] { world });
        }

        public virtual void Draw(Camera camera, Matrix[] matrices)
        {
            device.SetVertexBuffer(buffer);
            //device.SamplerStates[0] = SamplerState.LinearClamp;

            Matrix result = Matrix.Identity;

            foreach (Matrix m in matrices)
                result *= m;

            effect.World = result;
            effect.View = camera.GetView();
            effect.Projection = camera.GetProjection();

            effect.TextureEnabled = true;
            effect.Texture = texture;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, vertices, 0, vertices.Length / 3);
            }
        }

        protected virtual VertexPositionTexture[] GenerateVertices() { return null; }
    }
}
