using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo01
{
    public class Cube : GameObject
    {
        public Cube(Game game, GraphicsDevice device)
            : base(game, device, true)
        {
            Size = new Vector3(1, 1, 1);
            Vertices = new VertexPositionColor[]
            {
                // RIGHT
                new VertexPositionColor(new Vector3(.5f, .5f, .5f), Color.Green),
                new VertexPositionColor(new Vector3(.5f, .5f,-.5f), Color.Blue),
                new VertexPositionColor(new Vector3(.5f,-.5f, .5f), Color.Yellow),

                new VertexPositionColor(new Vector3(.5f,-.5f, .5f), Color.Yellow),
                new VertexPositionColor(new Vector3(.5f, .5f,-.5f), Color.Blue),
                new VertexPositionColor(new Vector3(.5f,-.5f,-.5f), Color.Red),

                // LEFT
                new VertexPositionColor(new Vector3(-.5f, .5f, .5f), Color.Red),
                new VertexPositionColor(new Vector3(-.5f,-.5f, .5f), Color.Blue),
                new VertexPositionColor(new Vector3(-.5f, .5f,-.5f), Color.Yellow),

                new VertexPositionColor(new Vector3(-.5f,-.5f, .5f), Color.Blue),
                new VertexPositionColor(new Vector3(-.5f,-.5f,-.5f), Color.Green),
                new VertexPositionColor(new Vector3(-.5f, .5f,-.5f), Color.Yellow),
                
                // BACK
                new VertexPositionColor(new Vector3(-.5f,-.5f,-.5f), Color.Green),
                new VertexPositionColor(new Vector3( .5f,-.5f,-.5f), Color.Red),
                new VertexPositionColor(new Vector3(-.5f, .5f,-.5f), Color.Yellow),

                new VertexPositionColor(new Vector3(-.5f, .5f,-.5f), Color.Yellow),
                new VertexPositionColor(new Vector3( .5f,-.5f,-.5f), Color.Red),
                new VertexPositionColor(new Vector3( .5f, .5f,-.5f), Color.Blue),
                
                // FRONT
                new VertexPositionColor(new Vector3(-.5f,-.5f, .5f), Color.Blue),
                new VertexPositionColor(new Vector3(-.5f, .5f, .5f), Color.Red),
                new VertexPositionColor(new Vector3( .5f, .5f, .5f), Color.Green),

                new VertexPositionColor(new Vector3(-.5f,-.5f, .5f), Color.Blue),
                new VertexPositionColor(new Vector3( .5f, .5f, .5f), Color.Green),
                new VertexPositionColor(new Vector3( .5f,-.5f, .5f), Color.Yellow),
                
                // BASE
                new VertexPositionColor(new Vector3(-.5f,-.5f, .5f), Color.Blue),
                new VertexPositionColor(new Vector3( .5f,-.5f,-.5f), Color.Red),
                new VertexPositionColor(new Vector3(-.5f,-.5f,-.5f), Color.Green),

                new VertexPositionColor(new Vector3(-.5f,-.5f, .5f), Color.Blue),
                new VertexPositionColor(new Vector3( .5f,-.5f, .5f), Color.Yellow),
                new VertexPositionColor(new Vector3( .5f,-.5f,-.5f), Color.Red),
                
                // TOP
                new VertexPositionColor(new Vector3(-.5f, .5f, .5f), Color.Red),
                new VertexPositionColor(new Vector3(-.5f, .5f,-.5f), Color.Yellow),
                new VertexPositionColor(new Vector3( .5f, .5f,-.5f), Color.Blue),

                new VertexPositionColor(new Vector3(-.5f, .5f, .5f), Color.Red),
                new VertexPositionColor(new Vector3( .5f, .5f,-.5f), Color.Blue),
                new VertexPositionColor(new Vector3( .5f, .5f, .5f), Color.Green),
            };
            UpdateLineBox();
            UpdateBoundingBox();
        }
    }
}