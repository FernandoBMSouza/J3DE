using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo02
{
    public class Building : GameObject
    {
        public Building(Game1 game, GraphicsDevice device, bool lineBoxVisible = false)
            : base(game, device, lineBoxVisible)
        {
            Size = new Vector3(2, 4, 6);
            LBox = new LineBox(game, Size, Color.Green);
            UpdateBoundingBox();
            
            Vertices = new VertexPositionColor[]
            {
                //Dimensões do Prédio:
                //Largura: 2
                //Altura: 4
                //Profundidade: 6

                //BASE
                new VertexPositionColor(new Vector3(-1,-2, 3), Color.Black),
                new VertexPositionColor(new Vector3( 1,-2, 3), Color.Black),
                new VertexPositionColor(new Vector3(-1,-2,-3), Color.Black),

                new VertexPositionColor(new Vector3(-1,-2,-3), Color.Black),
                new VertexPositionColor(new Vector3( 1,-2, 3), Color.Black),
                new VertexPositionColor(new Vector3( 1,-2,-3), Color.Black),

                //TOPO
                new VertexPositionColor(new Vector3(-1, 2, 3), Color.White),
                new VertexPositionColor(new Vector3(-1, 2, 1), Color.White),
                new VertexPositionColor(new Vector3( 1, 2, 1), Color.White),

                new VertexPositionColor(new Vector3(-1, 2, 3), Color.White),
                new VertexPositionColor(new Vector3( 1, 2, 1), Color.White),
                new VertexPositionColor(new Vector3( 1, 2, 3), Color.White),

                //LATERAL ESQUERDA 01
                new VertexPositionColor(new Vector3(-1, 2, 3), Color.White),
                new VertexPositionColor(new Vector3(-1,-2, 3), Color.Black),
                new VertexPositionColor(new Vector3(-1, 2, 1), Color.White),

                //LATERAL DIREITA 01
                new VertexPositionColor(new Vector3( 1, 2, 3), Color.White),
                new VertexPositionColor(new Vector3( 1, 2, 1), Color.White),
                new VertexPositionColor(new Vector3( 1,-2, 3), Color.Black),

                //LATERAL ESQUERDA 02
                new VertexPositionColor(new Vector3(-1,-2, 3), Color.Black),
                new VertexPositionColor(new Vector3(-1,-2,-3), Color.Black),
                new VertexPositionColor(new Vector3(-1, 2, 1), Color.White),

                 //LATERAL DIREITA 02
                new VertexPositionColor(new Vector3( 1,-2, 3), Color.Black),
                new VertexPositionColor(new Vector3( 1, 2, 1), Color.White),
                new VertexPositionColor(new Vector3( 1,-2,-3), Color.Black),

                //FRENTE
                new VertexPositionColor(new Vector3(-1,-2, 3), Color.Black),
                new VertexPositionColor(new Vector3(-1, 2, 3), Color.White),
                new VertexPositionColor(new Vector3( 1,-2, 3), Color.Black),

                new VertexPositionColor(new Vector3(-1, 2, 3), Color.White),
                new VertexPositionColor(new Vector3( 1, 2, 3), Color.White),
                new VertexPositionColor(new Vector3( 1,-2, 3), Color.Black),

                //TRASEIRA
                new VertexPositionColor(new Vector3(-1, 2, 1), Color.White),
                new VertexPositionColor(new Vector3(-1,-2,-3), Color.Black),
                new VertexPositionColor(new Vector3( 1, 2, 1), Color.White),

                new VertexPositionColor(new Vector3(-1,-2,-3), Color.Black),
                new VertexPositionColor(new Vector3( 1,-2,-3), Color.Black),
                new VertexPositionColor(new Vector3( 1, 2, 1), Color.White),
            };
        }
    }
}
