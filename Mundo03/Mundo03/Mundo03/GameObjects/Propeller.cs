using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Mundo03
{
    class Propeller : GameObject
    {
        float speed;
        const int MATRICES_LENGTH = 3;
        Matrix[] matrices;

        public Propeller(Game1 game, GraphicsDevice device, float rotationAngleZ, Vector3 position, float speed, Matrix otherMatrix)
            : base(device, game.Content.Load<Texture2D>(@"Images\wood"))
        {
            this.speed = speed;

            matrices = new Matrix[MATRICES_LENGTH];
            matrices[0] = Matrix.CreateRotationZ(MathHelper.ToRadians(rotationAngleZ));
            matrices[1] = Matrix.CreateTranslation(position);
            matrices[2] = otherMatrix;
        }

        public override void Update(GameTime gameTime)
        {
            float rotationAngle = speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            matrices[0] *= Matrix.CreateRotationZ(rotationAngle);


            base.Update(gameTime);
        }

        protected override VertexPositionTexture[] GenerateVertices()
        {
            return new VertexPositionTexture[]
            {
                new VertexPositionTexture(new Vector3( 0, 0, 0 ), new Vector2(.5f, 0)),
                new VertexPositionTexture(new Vector3( 1f,-2f,0), new Vector2(  1, 1)),
                new VertexPositionTexture(new Vector3(-1f,-2f,0), new Vector2(  0, 1)),
            };
        }

        public override void Draw(Camera camera)
        {
            base.Draw(camera, matrices);
        }
    }
}
