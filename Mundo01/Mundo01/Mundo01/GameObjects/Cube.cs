using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo01
{
    class Cube : GameObject
    {
        public Cube(GraphicsDevice device, Vector3 position)
            : base(device)
        {
            world *= Matrix.CreateTranslation(position);
        }

        protected override VertexPositionColor[] GenerateVertices()
        {
            return new VertexPositionColor[] 
            {
                #region RIGHT
                    new VertexPositionColor(new Vector3(1, 1, 1), Color.Green),
                    new VertexPositionColor(new Vector3(1, 1,-1), Color.Blue),
                    new VertexPositionColor(new Vector3(1,-1, 1), Color.Yellow),

                    new VertexPositionColor(new Vector3(1,-1, 1), Color.Yellow),
                    new VertexPositionColor(new Vector3(1, 1,-1), Color.Blue),
                    new VertexPositionColor(new Vector3(1,-1,-1), Color.Red),
                #endregion
                #region LEFT
                    new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red),
                    new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                    new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),

                    new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                    new VertexPositionColor(new Vector3(-1,-1,-1), Color.Green),
                    new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),
                #endregion
                #region BACK
                    new VertexPositionColor(new Vector3(-1,-1,-1), Color.Green),
                    new VertexPositionColor(new Vector3( 1,-1,-1), Color.Red),
                    new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),

                    new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),
                    new VertexPositionColor(new Vector3( 1,-1,-1), Color.Red),
                    new VertexPositionColor(new Vector3( 1, 1,-1), Color.Blue),
                #endregion
                #region FRONT
                    new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                    new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red),
                    new VertexPositionColor(new Vector3( 1, 1, 1), Color.Green),

                    new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                    new VertexPositionColor(new Vector3( 1, 1, 1), Color.Green),
                    new VertexPositionColor(new Vector3( 1,-1, 1), Color.Yellow),
                #endregion
                #region BASE
                    new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                    new VertexPositionColor(new Vector3( 1,-1,-1), Color.Red),
                    new VertexPositionColor(new Vector3(-1,-1,-1), Color.Green),

                    new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                    new VertexPositionColor(new Vector3( 1,-1, 1), Color.Yellow),
                    new VertexPositionColor(new Vector3( 1,-1,-1), Color.Red),
                #endregion
                #region TOP
                    new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red),
                    new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),
                    new VertexPositionColor(new Vector3( 1, 1,-1), Color.Blue),

                    new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red),
                    new VertexPositionColor(new Vector3( 1, 1,-1), Color.Blue),
                    new VertexPositionColor(new Vector3( 1, 1, 1), Color.Green),
                #endregion
            };
        }
    }
}
