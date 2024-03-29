using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Mundo02
{
    class Propeller : GameObject
    {
        float speed;
        const int MATRICES_LENGTH = 3;
        Matrix[] matrices;

        public Propeller(GraphicsDevice device, float rotationAngleZ, Vector3 position, float speed, Matrix otherMatrix)
            : base(device)
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

        protected override VertexPositionColor[] GenerateVertices()
        {
            return new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3( 0, 0,0), Color.Brown),
                new VertexPositionColor(new Vector3( 1f,-2f,0), Color.Brown),
                new VertexPositionColor(new Vector3(-1f,-2f,0), Color.BurlyWood),
            };
        }

        public override void Draw(Camera camera)
        {
            base.Draw(camera, matrices);
        }
    }
}
