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
using Prova02.Utilities;
using Prova02.GameObjects;
using Prova02.GameObjects.ShapesTexture;
using Prova02.GameObjects.Models;
using Prova02.GameObjects.Shapes;
using Prova02.GameObjects.Windmill;
using Prova02.GameObjects.Mine;
using Prova02.Utilities.Collision;

namespace Prova02
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screen;
        Camera camera;
        Random random;
        BasicEffect be;

        List<GameObject> go;
        List<Character> cotonetes;
        List<Texture2D> textures;
        List<Effect> effects;

        List<Collider> colliders;

        //bool isCollidingWithAnyEnemy = false;
        bool colliderVisible = false;
        float elevatorSpeed = 2f;
        float angle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "Prova 02";
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
            be = new BasicEffect(GraphicsDevice);

            textures = new List<Texture2D>();
            textures.Add(Content.Load<Texture2D>(@"Images\grass"));
            textures.Add(Content.Load<Texture2D>(@"Images\steve"));
            textures.Add(Content.Load<Texture2D>(@"Images\azul"));
            textures.Add(Content.Load<Texture2D>(@"Images\branco"));
            textures.Add(Content.Load<Texture2D>(@"Images\amarelo"));

            effects = new List<Effect>();
            effects.Add(Content.Load<Effect>(@"Effects\basic"));
            effects.Add(Content.Load<Effect>(@"Effects\yellow"));

            go = new List<GameObject>();
            go.Add(new CubeTexture(this, new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(10, 1, 90), effects[0], textures[0], colliderVisible));
            go.Add(new CubeTexture(this, new Vector3(20, 0, 40), new Vector3(0, 0, 0), new Vector3(50, 1, 10), effects[0], textures[0], colliderVisible));
            go.Add(new CubeTexture(this, new Vector3(50, 0, 40), new Vector3(0, 0, 0), new Vector3(10, 1, 10), effects[0], textures[2], colliderVisible));
            go.Add(new CubeTexture(this, new Vector3(60, 10, 25), new Vector3(0, 0, 0), new Vector3(10, 1, 40), effects[0], textures[0], colliderVisible));
            go.Add(new CubeTexture(this, new Vector3(60, 10, -25), new Vector3(0, 0, 0), new Vector3(10, 1, 40), effects[0], textures[0], colliderVisible));
            go.Add(new CubeTexture(this, new Vector3(50, 10, -40), new Vector3(0, 0, 0), new Vector3(20, 1, 10), effects[0], textures[0], colliderVisible));
            go.Add(new CubeTexture(this, new Vector3(60, 20, 0), new Vector3(0, 0, 0), new Vector3(1, 12, 1), effects[0], textures[0], colliderVisible)); // corda

            go[6].SetPivot(new Vector3(0, 5f, 0));

            cotonetes = new List<Character>();
            for (int i = 0; i < 6; i++)
                cotonetes.Add(new Character(this, new Vector3(i - 2, 3f, 0), new Vector3(0, 0, 0), Vector3.One, textures[2], textures[3], textures[4], effects[0], colliderVisible));

            camera = new Camera(this);

            colliders = new List<Collider>();
            colliders.Add(new Collider(this, new Vector3(0, 1, 40), new Vector3(8), new Vector3(1, 1, 1), Color.Yellow, colliderVisible));
            colliders.Add(new Collider(this, new Vector3(60, 10, 40), new Vector3(8), new Vector3(1, 1, 1), Color.Yellow, colliderVisible));
            colliders.Add(new Collider(this, new Vector3(60, 10, -40), new Vector3(8), new Vector3(1, 1, 1), Color.Yellow, colliderVisible));
            colliders.Add(new Collider(this, new Vector3(60, 10, 10), new Vector3(8), new Vector3(1, 1, 1), Color.Yellow, colliderVisible));
            colliders.Add(new Collider(this, new Vector3(60, 10, -10), new Vector3(8), new Vector3(1, 1, 1), Color.Yellow, colliderVisible));
            colliders.Add(new Collider(this, new Vector3(0, 10, -40), new Vector3(8), new Vector3(1, 1, 1), Color.Yellow, colliderVisible));

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
            camera.Update(gameTime);

            foreach (GameObject g in go) g.Update(gameTime);
            foreach (Character c in cotonetes) c.Update(gameTime);

            angle += 200f * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            go[6].SetRotation(new Vector3(0, 0, 70f * (float)Math.Sin(MathHelper.ToRadians(angle))));

            // TRATAMENTO DE COLISAO
            //isCollidingWithAnyEnemy = false;

            foreach (Character c in cotonetes)
            {
                if(c.IsColliding(colliders[0].GetBoundingBox()))
                {
                    c.SetRotation(new Vector3(0,90,0));
                }

                if(c.IsColliding(go[2].GetCollider()))
                {
                    //c.AddPosition(new Vector3(1,0,0));
                    if (go[2].GetPosition().Y <= 10)
                    {
                        c.SetState(2);
                        go[2].AddPosition(new Vector3(0, elevatorSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f, 0));
                        c.SetPosition(go[2].GetPosition() + new Vector3(0,3f,0));
                    }
                    else c.SetState(0);
                }

                if (c.IsColliding(colliders[1].GetBoundingBox()))
                {
                    c.SetRotation(new Vector3(0, 180, 0));
                }

                if (c.IsColliding(colliders[2].GetBoundingBox()))
                {
                    c.SetRotation(new Vector3(0, 270, 0));
                }

                if (c.IsColliding(colliders[3].GetBoundingBox()))
                {
                    //c.SetState(2);
                    c.HitEffect(effects[1]);
                }

                //if(c.IsColliding(go[6].GetCollider()))
                //{
                //    if (go[6].GetPosition().Y <= 10)
                //    {
                //        go[6].AddPosition(new Vector3(0, 0,elevatorSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f));
                //        c.SetPosition(go[2].GetPosition() + new Vector3(0, 3f, 0));
                //    }
                //    else c.SetState(0);
                //}

                if (c.IsColliding(colliders[4].GetBoundingBox()))
                {
                    c.SetState(0);
                }

                if (c.IsColliding(colliders[5].GetBoundingBox()))
                {
                    c.SetPosition(new Vector3(0,3,-30));
                    c.SetRotation(new Vector3(0, 5, 0));
                }
            }


            //foreach (Character c in cotonetes)
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (GameObject g in go) g.Draw(camera);
            foreach (Character c in cotonetes) c.Draw(camera);
            foreach (Collider c in colliders) c.Draw(camera);

            base.Draw(gameTime);
        }
    }
}
