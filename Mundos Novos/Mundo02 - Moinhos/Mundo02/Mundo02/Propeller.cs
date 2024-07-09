using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo02
{
    public class Propeller : GameObject
    {
        public Propeller(Game game, GraphicsDevice device)
            : base(game, device, true)
        {
            //Tem uma gambiarra nesse size, o Y certo seria 4, mas pra fazer o linebox ficar certo preciso deixar 8, 
            //no jogo não vai mudar nada, isso acontece porque o pivot da forma esta na parte inferior e não centralizado
            //o problema e que se eu desenhar a figura do jeito certo estraga o efeito de rotacao das helices, teria que achar outra solucao
            //mas como nao muda nada no jogo e tenho outras coisas para fazer agora deixo esse problema pro Fernando do futuro

            Size = new Vector3(2, 8, 0);
            LBox = new LineBox(game, Size, Color.Green);
            UpdateBoundingBox();
            
            Vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3( 0,0,0), Color.Blue),
                new VertexPositionColor(new Vector3(-1,1,0), Color.Red),
                new VertexPositionColor(new Vector3( 1,1,0), Color.Green),

                new VertexPositionColor(new Vector3(-1,1,0), Color.Red),
                new VertexPositionColor(new Vector3(-1,4,0), Color.Blue),
                new VertexPositionColor(new Vector3( 1,1,0), Color.Green),

                new VertexPositionColor(new Vector3(-1,4,0), Color.Blue),
                new VertexPositionColor(new Vector3( 1,4,0), Color.Red),
                new VertexPositionColor(new Vector3( 1,1,0), Color.Green),
            };
        }
    }
}
