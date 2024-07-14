#define USE_TEXTURE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo03
{
    public class Building : GameObject
    {
        public Building(Game1 game, GraphicsDevice device)
            : base(game, device)
        {
            Size = new Vector3(2, 4, 6);
#if USE_TEXTURE
            Texture = game.Content.Load<Texture2D>(@"Images\rocks");
            Vertices = new VertexPositionTexture[]
            {
                //Dimensões do Prédio:
                //Largura: 2
                //Alutra: 4
                //Profundidade: 6

                //BASE
                new VertexPositionTexture(new Vector3(-1,-2, 3), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1,-2, 3), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-1,-2,-3), new Vector2(0,1)),

                new VertexPositionTexture(new Vector3(-1,-2,-3), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( 1,-2, 3), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( 1,-2,-3), new Vector2(1,1)),

                //TOPO
                new VertexPositionTexture(new Vector3(-1, 2, 3), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-1, 2, 1), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1, 2, 1), new Vector2(1,0)),

                new VertexPositionTexture(new Vector3(-1, 2, 3), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( 1, 2, 1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( 1, 2, 3), new Vector2(1,1)),

                //LATERAL ESQUERDA 01
                new VertexPositionTexture(new Vector3(-1, 2, 3), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-1,-2, 3), new Vector2(1,1)),
                new VertexPositionTexture(new Vector3(-1, 2, 1), new Vector2(0,0)),

                //LATERAL DIREITA 01
                new VertexPositionTexture(new Vector3( 1, 2, 3), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1, 2, 1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( 1,-2, 3), new Vector2(0,1)),

                //LATERAL ESQUERDA 02
                new VertexPositionTexture(new Vector3(-1,-2, 3), new Vector2(1,1)),
                new VertexPositionTexture(new Vector3(-1,-2,-3), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-1, 2, 1), new Vector2(0.5f,0)),

                 //LATERAL DIREITA 02
                new VertexPositionTexture(new Vector3( 1,-2, 3), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( 1, 2, 1), new Vector2(0.5f,0)),
                new VertexPositionTexture(new Vector3( 1,-2,-3), new Vector2(1,1)),

                //FRENTE
                new VertexPositionTexture(new Vector3(-1,-2, 3), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-1, 2, 3), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1,-2, 3), new Vector2(1,1)),

                new VertexPositionTexture(new Vector3(-1, 2, 3), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1, 2, 3), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( 1,-2, 3), new Vector2(1,1)),

                //TRASEIRA
                new VertexPositionTexture(new Vector3(-1, 2, 1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-1,-2,-3), new Vector2(1,1)),
                new VertexPositionTexture(new Vector3( 1, 2, 1), new Vector2(0,0)),

                new VertexPositionTexture(new Vector3(-1,-2,-3), new Vector2(1,1)),
                new VertexPositionTexture(new Vector3( 1,-2,-3), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( 1, 2, 1), new Vector2(0,0)),
            };
            
#else
            Vertices = new VertexPositionColor[]
            {
                //Dimensões do Prédio:
                //Largura: 2
                //Alutra: 4
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
#endif
        }
    }
}
