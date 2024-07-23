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

namespace Minecraft
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random random;

        Screen screen;
        Camera camera;

        Quad plane;
        Player player;
        Enemy[] enemies;

        List<Character> characters;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            IsMouseVisible = true;
            Window.Title = "MINECRAFT";
        }

        protected override void Initialize()
        {
            screen = Screen.GetInstance();
            screen.Width = graphics.PreferredBackBufferWidth;
            screen.Height = graphics.PreferredBackBufferHeight;

            int seed = (int)DateTime.Now.Ticks % int.MaxValue;
            random = new Random(seed);

            camera = new Camera(this);

            plane = new Quad(this, GraphicsDevice);
            plane.Scale = new Vector3(20, 1, 20);

            player = new Player(this, GraphicsDevice);
            player.Position = new Vector3(0, player.Size.Y / 2, 0);

            characters = new List<Character>() { player };

            enemies = new Enemy[50];
            for (int i = 0; i < enemies.Length; i++)
                enemies[i] = new Enemy(this, GraphicsDevice);

            foreach (Enemy enemy in enemies)
            {
                characters.Add(enemy);
                enemy.Position = new Vector3(random.Next((int)-plane.Size.X / 2, (int)plane.Size.X / 2),
                                             enemy.Size.Y / 2,
                                             random.Next((int)-plane.Size.Z / 2, (int)plane.Size.Z / 2));
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            camera.Update(gameTime);
            player.Update(gameTime);
            foreach (Enemy enemy in enemies) enemy.Update(gameTime);
            
            //Checagem de colisao
            foreach (Enemy enemy in enemies)
            {
                if (player.IsColliding(enemy.BBox))
                {
                    player.RestorePosition();
                    enemy.RestorePosition();

                    enemy.SetColliderColor(Color.Red);
                }
                else enemy.SetColliderColor(Color.Green);
            }

            // Checa se saiu do cenario
            foreach (Character character in characters)
            {
                if (character.Position.X >= plane.Size.X/2 || character.Position.X <= -plane.Size.X/2 || 
                    character.Position.Z >= plane.Size.Z/2 || character.Position.Z <= -plane.Size.Z/2)
                {
                    character.RestorePosition();
                }
            }

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // RasterizerState rs = new RasterizerState();
            //rs.CullMode = CullMode.None;
            //rs.FillMode = FillMode.WireFrame;
            // GraphicsDevice.RasterizerState = rs;

            GraphicsDevice.SamplerStates[0] = SamplerState.LinearClamp;
            plane.Draw(camera, false);
            GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            player.Draw(camera, false);
            foreach (Enemy enemy in enemies) enemy.Draw(camera, false);

            base.Draw(gameTime);
        }
    }
}
