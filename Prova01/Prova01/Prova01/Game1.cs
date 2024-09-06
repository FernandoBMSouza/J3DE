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
using Prova01.Utilities;
using Prova01.GameObjects;
using Prova01.GameObjects.Shapes;
using Prova01.GameObjects.Windmill;
using Prova01.GameObjects.Prova01;

namespace Prova01
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screen;
        Camera camera;
        BasicEffect effect;

        List<GameObject> go;
        List<Snail> snails;
        List<Snail> loserSnails;

        bool colliderVisible = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "MUNDO PROVA 01";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            screen = Screen.GetInstance();
            screen.Width = graphics.PreferredBackBufferWidth;
            screen.Height = graphics.PreferredBackBufferHeight;

            camera = new Camera(this);
            go = new List<GameObject>();
            go.Add(new Quad(this, Vector3.Zero, Vector3.Zero, new Vector3(100), Color.DarkSlateGray, colliderVisible));
            go.Add(new Track(this, new Vector3(0, 1, 0), new Vector3(0, 0, 0), new Vector3(5, .5f, 5), Color.Black, colliderVisible));

            snails = new List<Snail>();
            snails.Add(new NPC(this, new Vector3(0, 1.8f, -15), new Vector3(0, 270, 0), new Vector3(1, 1, 1), -5, Color.Red, (Track)go[1], colliderVisible));
            snails.Add(new NPC(this, new Vector3(0, 1.8f, -15), new Vector3(0, 270, 0), new Vector3(1, 1, 1), -3, Color.Green, (Track)go[1], colliderVisible));
            snails.Add(new NPC(this, new Vector3(0, 1.8f, -15), new Vector3(0, 270, 0), new Vector3(1, 1, 1), -1, Color.Blue, (Track)go[1], colliderVisible));
            snails.Add(new NPC(this, new Vector3(0, 1.8f, -15), new Vector3(0, 270, 0), new Vector3(1, 1, 1), 1, Color.Yellow, (Track)go[1], colliderVisible));
            snails.Add(new NPC(this, new Vector3(0, 1.8f, -15), new Vector3(0, 270, 0), new Vector3(1, 1, 1), 3, Color.Purple, (Track)go[1], colliderVisible));
            snails.Add(new Player(this, new Vector3(0, 1.8f, -15), new Vector3(0, 270, 0), new Vector3(1, 1, 1), 5, Color.Silver, (Track)go[1], colliderVisible));

            loserSnails = new List<Snail>();

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
            camera.Update(gameTime);
            Window.Title = "ESPECIAL = " + Snail.special;


            foreach (GameObject g in go) g.Update(gameTime);
            foreach (Snail s in snails) s.Update(gameTime);

            // TRATAMENTO DE COLISAO
            foreach (Snail s in snails)
            {
                if (s.IsColliding(((Track)go[1]).GetColliders()[0].GetBoundingBox()) && !s.HasCollidedWithFinish())
                {
                    if (s is Player)
                    {
                        Window.Title = "Colidi com a CHEGADA!";
                    }

                    s.SetWinner(true);
                    loserSnails.AddRange(snails.Where(s2 => s != s2));
                    s.MarkCollisionWithFinish();  // Marca que colidiu com a chegada
                    s.SetColliderColor(Color.Red);
                }
                else if (s.IsColliding(((Track)go[1]).GetColliders()[1].GetBoundingBox()) && !s.HasCollidedWithFirstThird())
                {
                    if (s is Player)
                    {
                        Window.Title = "Colidi com o PRIMEIRO TERCO!";
                        s.IncrementSpecial();
                    }
                    s.MarkCollisionWithFirstThird();  // Marca que colidiu com o primeiro terço
                    s.SetColliderColor(Color.Red);
                }
                else if (s.IsColliding(((Track)go[1]).GetColliders()[2].GetBoundingBox()) && !s.HasCollidedWithSecondThird())
                {
                    if (s is Player)
                    {
                        Window.Title = "Colidi com o SEGUNDO TERCO!";
                        s.IncrementSpecial();
                    }
                    s.MarkCollisionWithSecondThird();  // Marca que colidiu com o segundo terço
                    s.SetColliderColor(Color.Red);
                }
                else
                {
                    s.SetColliderColor(Color.Green);
                }
            }

            RemoveLosers();

            base.Update(gameTime);
        }

        void RemoveLosers()
        {
            if (loserSnails == null) return;

            foreach (Snail snail in loserSnails)
            {
                snails.Remove(snail);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (GameObject g in go) g.Draw(camera, effect);
            foreach (Snail s in snails) s.Draw(camera, effect);

            base.Draw(gameTime);
        }
    }
}
