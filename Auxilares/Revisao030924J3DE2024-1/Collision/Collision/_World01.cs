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
        _Cube cube;
        _Player player;
        _NPC npc;

        public _World01(Game game)
        {
            this.game = game;
            this.cube = new _Cube(game, Vector3.Zero, Vector3.One * 2.1f, Color.Yellow, true);
            this.player = new _Player(game, new Vector3(3, 0, -3), Vector3.One * 2.1f, Color.Purple, true);
            this.npc = new _NPC(game, new Vector3(-3, 0, 3), Vector3.One * 2.1f, Color.White, true);
        }

        public void Update(GameTime gt)
        {
            this.player.Update(gt);
            this.npc.Update(gt);

            string text = "";

            // colisão com player
            if (cube.IsColliding(this.player.GetBoundingBox()))
            {    
                    //this.game.Window.Title = "PLAYER COLIDINDO";
                    text += "=PLAYER COLIDINDO=";
                    this.cube.GetLineBox().SetColor(Color.Red);
                    this.player.RestorePosition();
                    //return;
            }
            else
            {
                //this.game.Window.Title = "-----";
                this.cube.GetLineBox().SetColor(Color.Yellow);
            }

            // colisao com NPC
            if (cube.IsColliding(this.npc.GetBoundingBox()))
            {
                text += "=NPC COLIDINDO=";
                //this.game.Window.Title = "NPC COLIDINDO";
                this.cube.GetLineBox().SetColor(Color.Red);
                this.npc.RestorePosition();
                this.npc.ChangeState();
            }
            else
            {
                //this.game.Window.Title = "-----";
                this.cube.GetLineBox().SetColor(Color.Yellow);
            }

            // colisao com NPC x PLAYER
            if (player.IsColliding(this.npc.GetBoundingBox()))
            {
                text += "=NPC x PLAYER COLIDINDO=";
                //this.game.Window.Title = "NPC x PLAYER COLIDINDO";
                this.player.GetLineBox().SetColor(Color.Red);
                this.player.RestorePosition();
                this.npc.RestorePosition();
                this.npc.ChangeState();
            }
            else
            {
                //this.game.Window.Title = "-----";
                this.player.GetLineBox().SetColor(Color.Purple);
            }

            game.Window.Title = text;
        }

        public void Draw(BasicEffect effect)
        {
            this.cube.Draw(effect);
            this.player.Draw(effect);
            this.npc.Draw(effect);
        }
    }
}
