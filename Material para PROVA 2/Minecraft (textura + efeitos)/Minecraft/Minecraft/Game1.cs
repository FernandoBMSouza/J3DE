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
using Minecraft.GameObjects.ShapesTexture;
using Minecraft.GameObjects.Models;
using Minecraft.GameObjects.Shapes;
using Minecraft.GameObjects.Windmill;
using Minecraft.GameObjects.Mine;

namespace Minecraft
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screen;
        ThirdPersonCamera camera;
        Random random;

        Player player;
        List<GameObject> go;
        List<Enemy> enemies;
        List<Texture2D> textures;
        List<Effect> effects;

        bool isCollidingWithAnyEnemy = false;
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

            textures = new List<Texture2D>();
            textures.Add(Content.Load<Texture2D>(@"Images\grass"));
            textures.Add(Content.Load<Texture2D>(@"Images\steve"));
            textures.Add(Content.Load<Texture2D>(@"Images\zombie"));

            effects = new List<Effect>();
            effects.Add(Content.Load<Effect>(@"Effects\basic"));
            effects.Add(Content.Load<Effect>(@"Effects\red"));

            go = new List<GameObject>();
            go.Add(new QuadTexture(this, Vector3.Zero, Vector3.Zero, new Vector3(100), effects[0], textures[0], colliderVisible));

            player = new Player(this, new Vector3(0, 2.7f, 0),Vector3.Zero, Vector3.One, textures[1], effects[0], colliderVisible);
            enemies = new List<Enemy>();
            for (int i = 0; i < 50; i++)
            {
                enemies.Add(new Enemy(this, new Vector3(random.Next((int)-(go[0].GetDimension().X / 2), (int)(go[0].GetDimension().X / 2)),
                                                        2.7f,
                                                        random.Next((int)-(go[0].GetDimension().Z / 2), (int)(go[0].GetDimension().Z / 2))),
                                                        Vector3.Zero, Vector3.One, textures[2], effects[0], colliderVisible));
            }


            camera = new ThirdPersonCamera(this, player);
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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();
            camera.Update(gameTime, player);

            player.Update(gameTime);
            foreach (GameObject g in go) g.Update(gameTime);
            foreach (Enemy e in enemies) e.Update(gameTime);

            // TRATAMENTO DE COLISAO
            isCollidingWithAnyEnemy = false;
            foreach (Enemy e in enemies)
            {
                if (player.IsColliding(e.GetCollider()))
                {
                    player.RestorePosition();
                    player.HitEffect(effects[1]);
                    player.SetColliderColor(Color.Red);
                    e.SetColliderColor(Color.Red);
                    isCollidingWithAnyEnemy = true;
                }
                else
                {
                    e.SetColliderColor(Color.Green);
                }
            }

            if (!isCollidingWithAnyEnemy)
            {
                player.RestoreEffect(effects[0]);
                player.SetColliderColor(Color.Green);
            }

            // CHECAGEM DE LIMITES
            if (player.GetPosition().X >= go[0].GetDimension().X / 2 || player.GetPosition().X <= -(go[0].GetDimension().X / 2) ||
                player.GetPosition().Z >= go[0].GetDimension().Z / 2 || player.GetPosition().Z <= -(go[0].GetDimension().Z / 2))
            {
                player.RestorePosition();
            }
            foreach (Enemy e in enemies)
            {
                if (e.GetPosition().X >= go[0].GetDimension().X / 2 || e.GetPosition().X <= -(go[0].GetDimension().X / 2) ||
                    e.GetPosition().Z >= go[0].GetDimension().Z / 2 || e.GetPosition().Z <= -(go[0].GetDimension().Z / 2))
                {
                    e.RestorePosition();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (GameObject g in go) g.Draw(camera);
            foreach (Enemy e in enemies) e.Draw(camera);
            player.Draw(camera);

            base.Draw(gameTime);
        }
    }
}