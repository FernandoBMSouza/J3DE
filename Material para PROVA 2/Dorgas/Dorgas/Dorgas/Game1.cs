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
using Dorgas.Utilities;
using Dorgas.GameObjects;
using Dorgas.GameObjects.ShapesTexture;
using Dorgas.GameObjects.Models;
using Dorgas.GameObjects.Shapes;
using Dorgas.GameObjects.Windmill;
using Dorgas.GameObjects.Mine;
using Dorgas.GameObjects.Drogas;
using System.Diagnostics;

namespace Dorgas
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screen;
        ThirdPersonCamera camera;
        static Random random;

        Player player;
        List<GameObject> go;
        List<Mushroom> mushrooms;
        List<Texture2D> textures;
        List<Effect> effects;

        Color backGroundColor;

        //bool isCollidingWithAnyEnemy = false;
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

            backGroundColor = Color.CornflowerBlue;

            textures = new List<Texture2D>();
            textures.Add(Content.Load<Texture2D>(@"Images\grass"));
            textures.Add(Content.Load<Texture2D>(@"Images\steve"));
            textures.Add(Content.Load<Texture2D>(@"Images\zombie"));
            textures.Add(Content.Load<Texture2D>(@"Images\azul"));
            textures.Add(Content.Load<Texture2D>(@"Images\amarelo"));
            textures.Add(Content.Load<Texture2D>(@"Images\vermelho"));
            textures.Add(Content.Load<Texture2D>(@"Images\roxo"));

            effects = new List<Effect>();
            effects.Add(Content.Load<Effect>(@"Effects\basic"));
            effects.Add(Content.Load<Effect>(@"Effects\red"));
            effects.Add(Content.Load<Effect>(@"Effects\blue"));
            effects.Add(Content.Load<Effect>(@"Effects\purple"));
            effects.Add(Content.Load<Effect>(@"Effects\yellow"));
            effects.Add(Content.Load<Effect>(@"Effects\invert"));
            effects.Add(Content.Load<Effect>(@"Effects\grayscale"));
            effects.Add(Content.Load<Effect>(@"Effects\embacado"));

            go = new List<GameObject>();
            go.Add(new QuadTexture(this, Vector3.Zero, Vector3.Zero, new Vector3(100), effects[0], textures[0], colliderVisible));

            mushrooms = new List<Mushroom>();
            for(int i = 0; i < 100; i++)
                mushrooms.Add(new Mushroom(this, new Vector3(random.Next(-(int)go[0].GetDimension().X / 2, (int)go[0].GetDimension().X / 2), .5f, random.Next(-(int)go[0].GetDimension().Z / 2, (int)go[0].GetDimension().Z / 2)), Vector3.Zero, new Vector3(1), textures[random.Next(3, 7)], effects[0], colliderVisible));

            player = new Player(this, new Vector3(0, 2.7f, 0),Vector3.Zero, Vector3.One, textures[1], effects[0], colliderVisible);

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
            foreach (GameObject m in mushrooms) m.Update(gameTime);

            // TRATAMENTO DE COLISAO
            for (int i = 0; i < mushrooms.Count; i++)
            {
                if(player.IsColliding(mushrooms[i].GetCollider()))
                {
                    mushrooms.RemoveAt(i);
                    backGroundColor = new Color(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                    Debug.WriteLine("Background Color: R(" + backGroundColor.R + "), G(" + backGroundColor.G + "), B(" + backGroundColor.B +")");
                    ((ShapeTexture)go[0]).SetEffect(effects[random.Next(1, effects.Count)]);
                    ((Character)player).SetEffect(effects[random.Next(5, effects.Count)]);
                }
            }


            //isCollidingWithAnyEnemy = false;
            //foreach (Enemy e in enemies)
            //{
            //    if (player.IsColliding(e.GetCollider()))
            //    {
            //        player.RestorePosition();
            //        player.HitEffect(effects[1]);
            //        player.SetColliderColor(Color.Red);
            //        e.SetColliderColor(Color.Red);
            //        isCollidingWithAnyEnemy = true;
            //    }
            //    else
            //    {
            //        e.SetColliderColor(Color.Green);
            //    }
            //}

            //if (!isCollidingWithAnyEnemy)
            //{
            //    player.RestoreEffect(effects[0]);
            //    player.SetColliderColor(Color.Green);
            //}

            // CHECAGEM DE LIMITES
            if (player.GetPosition().X >= go[0].GetDimension().X / 2 || player.GetPosition().X <= -(go[0].GetDimension().X / 2) ||
                player.GetPosition().Z >= go[0].GetDimension().Z / 2 || player.GetPosition().Z <= -(go[0].GetDimension().Z / 2))
            {
                player.RestorePosition();
            }
            //foreach (Enemy e in enemies)
            //{
            //    if (e.GetPosition().X >= go[0].GetDimension().X / 2 || e.GetPosition().X <= -(go[0].GetDimension().X / 2) ||
            //        e.GetPosition().Z >= go[0].GetDimension().Z / 2 || e.GetPosition().Z <= -(go[0].GetDimension().Z / 2))
            //    {
            //        e.RestorePosition();
            //    }
            //}

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backGroundColor);

            foreach (GameObject g in go) g.Draw(camera);
            foreach (GameObject m in mushrooms) m.Draw(camera);
            //foreach (Enemy e in enemies) e.Draw(camera);
            player.Draw(camera);

            base.Draw(gameTime);
        }
    }
}
