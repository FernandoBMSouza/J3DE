using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Collision
{
    public class _World01
    {
        Game game;
        //_Cube cube;
        //_Player player;
        //_NPC npc;
        //_Gnomo gnomo;

        const int MAX = 100;
        static Random r = new Random();
        List<_Collider> gameObjects;

        public _World01(Game game)
        {
            this.game = game;
            //this.cube = new _Cube(game, Vector3.Zero, Vector3.One * 2.1f, Color.Yellow, true);
            //this.player = new _Player(game, new Vector3(3, 0, -3), Vector3.One * 2.1f, Color.Purple, true);
            //this.npc = new _NPC(game, new Vector3(-3, 0, 3), Vector3.One * 2.1f, Color.White, false);
            //this.gnomo = new _Gnomo(game, new Vector3(-3, 0, -3), Vector3.One * 2.1f, Color.Orange, false);

            this.gameObjects = new List<_Collider>();

            this.gameObjects.Add(new _Cube(game, Vector3.Zero, Vector3.One * 2.1f, Color.Yellow, true));
            this.gameObjects.Add(new _Player(game, new Vector3(0, 0, -15), Vector3.One * 2.1f, Color.Purple, true));
            
            for (int i = 0; i < MAX; i++)
            {
                if (r.Next(100) < 50)
                {
                    this.gameObjects.Add(new _NPC(game, new Vector3(r.Next(-10, 11), 0, r.Next(-10, 11)), Vector3.One * 2.1f, Color.White, false));
                }
                else
                {
                    this.gameObjects.Add(new _Gnomo(game, new Vector3(r.Next(-10, 11), 0, r.Next(-10, 11)), Vector3.One * 2.1f, Color.Orange, false));
                }
            }
        }

        public void Update(GameTime gt)
        {
            //this.player.Update(gt);
            //this.npc.Update(gt);
            //this.gnomo.Update(gt);

            foreach (_Collider c in gameObjects)
            {
                //if ( c.GetType() == typeof(_Player) ||
                //     c.GetType() == typeof(_NPC) || 
                //     c.GetType() == typeof(_Gnomo))
                if (c is _Cube)
                {
                    ((_Cube)c).Update(gt);
                }
            }

            string text = "";
                        
            // colisao CUBE X (NPC && GNOMOS)
            for (int i = 2; i < gameObjects.Count; i++)
            {
                if (gameObjects[0].IsColliding(gameObjects[i].GetBoundingBox()))
                {
                    //text += " = " + gameObjects[i].GetType().ToString() + " COLIDINDO = ";
                    gameObjects.RemoveAt(i);
                    break;
                }
            }

            // colisao PLAYER X (NPC && GNOMOS)
            for (int i = 2; i < gameObjects.Count; i++)
            {
                if (gameObjects[1].IsColliding(gameObjects[i].GetBoundingBox()))
                {
                    text += " = " + gameObjects[i].GetType().ToString() + " x PLAYER COLIDINDO = ";
                    ((_Player)gameObjects[1]).RestorePosition();
                    ((_NPC)gameObjects[i]).RestorePosition();
                    ((_NPC)gameObjects[i]).ChangeState();
                }
            }

            // colisao PLAYER X CUBE
            if (gameObjects[1].IsColliding(gameObjects[0].GetBoundingBox()))
            {
                text += " = CUBE x PLAYER COLIDINDO = ";
                ((_Player)gameObjects[1]).RestorePosition();
            }

            game.Window.Title = text;
        }

        public void Draw(BasicEffect effect)
        {
            foreach (_Collider c in gameObjects)
            {
                c.Draw(effect);
            }
        }
    }
}
