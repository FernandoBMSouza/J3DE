using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using WorldManager.GameObjects;
using WorldManager.GameObjects.BasicWorld;

namespace WorldManager.Worlds
{
    class BasicWorld
    {
        Random random;

        Quad plane;
        Cube house;
        Windmill[] windmills;

        List<GameObject> colliders;

        Texture2D grass;
        Texture2D rocks;
        Texture2D wood;
        Texture2D bricks;

        public BasicWorld(Game1 game)
        {
            int seed = (int)DateTime.Now.Ticks % int.MaxValue;
            random = new Random(seed);

            rocks = game.Content.Load<Texture2D>(@"Images\rocks");
            wood = game.Content.Load<Texture2D>(@"Images\wood");
            grass = game.Content.Load<Texture2D>(@"Images\grass");
            bricks = game.Content.Load<Texture2D>(@"Images\bricks");

            plane = new Quad(game, grass);
            house = new Cube(game, bricks);
            windmills = new Windmill[]
            {
                new Windmill(game, random.Next(1,10), true, rocks, wood),
                new Windmill(game, random.Next(1,10), true, rocks, wood),
            };

            plane.Scale = new Vector3(20, 1, 20);
            house.Position = new Vector3(0, 1, 0);

            windmills[0].Position = new Vector3(-8, 2,0);
            windmills[1].Position = new Vector3( 8, 2,0);

            windmills[0].Rotation = new Vector3(0, MathHelper.ToRadians(45), 0);
            windmills[1].Rotation = new Vector3(0, MathHelper.ToRadians(-45), 0);

            colliders = new List<GameObject>() { plane, house, windmills[0], windmills[1] };
        }

        public void Update(GameTime gameTime, Camera camera)
        {
            foreach(Windmill windmill in windmills) 
                windmill.Update(gameTime);

            foreach (GameObject obj in colliders)
            {
                if (camera.IsColliding(obj.BBox))
                {
                    camera.RestorePosition();
                    obj.SetColliderColor(Color.Red);
                }
                else obj.SetColliderColor(Color.Green);
            }
        }

        public void Draw(Camera camera)
        {
            plane.Draw(camera);
            house.Draw(camera);
            foreach (Windmill windmill in windmills)
                windmill.Draw(camera);
        }
    }
}
