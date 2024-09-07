using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Minecraft.Utilities;
using Minecraft.GameObjects;
using Minecraft.GameObjects.Shapes;
using Minecraft.GameObjects.Windmill;
using Minecraft.GameObjects.Character;

namespace Minecraft
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screen;
        ThirdPersonCamera camera;
        BasicEffect effect;
        Random random;
        List<GameObject> go;

        bool colliderVisible = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "MINECRAFT";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            screen = Screen.GetInstance();
            screen.Width = graphics.PreferredBackBufferWidth;
            screen.Height = graphics.PreferredBackBufferHeight;

            random = new Random();

            go = new List<GameObject>();
            go.Add(new Quad(this, Vector3.Zero, Vector3.Zero, new Vector3(100), Color.Green, colliderVisible));
            go.Add(new Player(this, new Vector3(random.Next((int)-(go[0].GetDimension().X / 2), (int)(go[0].GetDimension().X / 2)),
                                                   2.7f,
                                                   random.Next((int)-(go[0].GetDimension().Z / 2), (int)(go[0].GetDimension().Z / 2))),
                                                   Vector3.Zero, Vector3.One, Color.DarkRed, colliderVisible));

            for (int i = 0; i < 50; i++)
            {
                go.Add(new Enemy(this, new Vector3(random.Next((int)-(go[0].GetDimension().X / 2), (int)(go[0].GetDimension().X / 2)), 
                                                   2.7f, 
                                                   random.Next((int)-(go[0].GetDimension().Z / 2), (int)(go[0].GetDimension().Z / 2))), 
                                                   Vector3.Zero, Vector3.One, Color.LawnGreen, colliderVisible));
            }

            camera = new ThirdPersonCamera(this, (Player)go[1]);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            effect = new BasicEffect(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();
            camera.Update(gameTime, (Player)go[1]);

            foreach (GameObject g in go) g.Update(gameTime);

            // TRATAMENTO DE COLISAO
            foreach (GameObject g in go)
            {
                if (g != go[1] && g is Character)
                {
                    if (go[1].IsColliding(g.GetCollider()))
                    {
                        ((Player)go[1]).RestorePosition();
                        go[1].SetColliderColor(Color.Red);
                        g.SetColliderColor(Color.Red);
                    }
                    else
                    {
                        go[1].SetColliderColor(Color.Green);
                        g.SetColliderColor(Color.Green);
                    }
                }
            }

            // CHECAGEM DE LIMITES
            foreach (GameObject g in go)
            {
                if (g is Character)
                {
                    if (g.GetPosition().X >= go[0].GetDimension().X / 2 || g.GetPosition().X <= -(go[0].GetDimension().X / 2) ||
                        g.GetPosition().Z >= go[0].GetDimension().Z / 2 || g.GetPosition().Z <= -(go[0].GetDimension().Z / 2))
                    {
                        ((Character)g).RestorePosition();
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (GameObject g in go) g.Draw(camera, effect);

            base.Draw(gameTime);
        }
    }
}
