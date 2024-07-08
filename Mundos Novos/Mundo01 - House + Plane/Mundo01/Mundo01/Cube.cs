using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo01
{
    public class Cube : GameObject
    {
        public Cube(Game game, GraphicsDevice device)
            : base(game, device, true)
        {
            Size = new Vector3(2, 2, 2);
            Vertices = new VertexPositionColor[]
            {
                // RIGHT
                new VertexPositionColor(new Vector3(1, 1, 1), Color.Green),
                new VertexPositionColor(new Vector3(1, 1,-1), Color.Blue),
                new VertexPositionColor(new Vector3(1,-1, 1), Color.Yellow),

                new VertexPositionColor(new Vector3(1,-1, 1), Color.Yellow),
                new VertexPositionColor(new Vector3(1, 1,-1), Color.Blue),
                new VertexPositionColor(new Vector3(1,-1,-1), Color.Red),

                // LEFT
                new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red),
                new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),

                new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                new VertexPositionColor(new Vector3(-1,-1,-1), Color.Green),
                new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),
                
                // BACK
                new VertexPositionColor(new Vector3(-1,-1,-1), Color.Green),
                new VertexPositionColor(new Vector3( 1,-1,-1), Color.Red),
                new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),

                new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),
                new VertexPositionColor(new Vector3( 1,-1,-1), Color.Red),
                new VertexPositionColor(new Vector3( 1, 1,-1), Color.Blue),
                
                // FRONT
                new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red),
                new VertexPositionColor(new Vector3( 1, 1, 1), Color.Green),

                new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                new VertexPositionColor(new Vector3( 1, 1, 1), Color.Green),
                new VertexPositionColor(new Vector3( 1,-1, 1), Color.Yellow),
                
                // BASE
                new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                new VertexPositionColor(new Vector3( 1,-1,-1), Color.Red),
                new VertexPositionColor(new Vector3(-1,-1,-1), Color.Green),

                new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                new VertexPositionColor(new Vector3( 1,-1, 1), Color.Yellow),
                new VertexPositionColor(new Vector3( 1,-1,-1), Color.Red),
                
                // TOP
                new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red),
                new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),
                new VertexPositionColor(new Vector3( 1, 1,-1), Color.Blue),

                new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red),
                new VertexPositionColor(new Vector3( 1, 1,-1), Color.Blue),
                new VertexPositionColor(new Vector3( 1, 1, 1), Color.Green),
            };
            LBox.SetScale(Size);
            LBox.SetAngleX(Angle.X);
            LBox.SetAngleY(Angle.Y);
            LBox.SetAngleZ(Angle.Z);
            LBox.SetPosition(Position);
            UpdateBoundingBox();
        }
    }
}