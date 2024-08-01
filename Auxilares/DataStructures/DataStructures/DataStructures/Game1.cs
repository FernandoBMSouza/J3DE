//#define _VECTOR_
//#define _MATRIX_
//#define _ARRAY_
//#define _LIST_
#define _LINKEDLIST_


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

namespace DataStructures
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int MAX = 10000;
        const int LINES = 4;
        const int COLUMNS = 2500;

#if _VECTOR_
        _GameObject[] go;
#elif _MATRIX_
        _GameObject[,] go;
#elif _ARRAY_
        Array go;
#elif _LIST_
        List<_GameObject> go;
#elif _LINKEDLIST_
        LinkedList<_GameObject> go;
#endif

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            Window.Title = "DATA STRUCTURES";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D[] t = new Texture2D[]
            {
                Content.Load<Texture2D>(@"Images\amarelo"),
                Content.Load<Texture2D>(@"Images\vermelho"),
                Content.Load<Texture2D>(@"Images\azul"),
                Content.Load<Texture2D>(@"Images\verde"),
            };

#if _VECTOR_
            go = new _GameObject[MAX];
#elif _MATRIX_
            go = new _GameObject[LINES,COLUMNS];
#elif _ARRAY_
            go = Array.CreateInstance(typeof(_GameObject), MAX);
#elif _LIST_
            go = new List<_GameObject>();
#elif _LINKEDLIST_
            go = new LinkedList<_GameObject>();
#endif

#if _VECTOR_
            for (int i = 0; i < go.Length; i++)
            {
                go[i] = new _GameObject(new Vector2(Window.ClientBounds.Width / 2 - t[0].Width / 10, Window.ClientBounds.Height / 2 - t[0].Height / 10),
                                        new Point(t[0].Width / 5, t[0].Height / 5),
                                        ref t[i % t.Length]);
            }
#elif _MATRIX_
            for (int i = 0; i < go.GetLength(0); i++)
            {
                for (int j = 0; j < go.GetLength(1); j++)
                {
                    go[i,j] = new _GameObject(new Vector2(Window.ClientBounds.Width / 2 - t[0].Width / 10, Window.ClientBounds.Height / 2 - t[0].Height / 10),
                                              new Point(t[0].Width / 5, t[0].Height / 5),
                                              ref t[j % t.Length]);
                }
            }
#elif _ARRAY_
            for (int i = 0; i < go.Length; i++)
            {
                go.SetValue(new _GameObject(new Vector2(Window.ClientBounds.Width / 2 - t[0].Width / 10, Window.ClientBounds.Height / 2 - t[0].Height / 10),
                                            new Point(t[0].Width / 5, t[0].Height / 5),
                                            ref t[i % t.Length]), i);
            }
#elif _LIST_
            for (int i = 0; i < MAX; i++)
            {
                go.Add(new _GameObject(new Vector2(Window.ClientBounds.Width / 2 - t[0].Width / 10, Window.ClientBounds.Height / 2 - t[0].Height / 10),
                                       new Point(t[0].Width / 5, t[0].Height / 5),
                                       ref t[i % t.Length]));
            }
#elif _LINKEDLIST_
            for (int i = 0; i < MAX; i++)
            {
                go.AddLast(new _GameObject(new Vector2(Window.ClientBounds.Width / 2 - t[0].Width / 10, Window.ClientBounds.Height / 2 - t[0].Height / 10),
                                           new Point(t[0].Width / 5, t[0].Height / 5),
                                           ref t[i % t.Length]));
            }
#endif
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            foreach (_GameObject g in go) g.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            spriteBatch.Begin();
            foreach (_GameObject g in go) g.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
