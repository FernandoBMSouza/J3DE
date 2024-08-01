using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{    
    public class SceneManager
    {
        static SceneManager instance = null;
        SCENE currentScene;
        Scene scene = null;
        Random random;
        Game game;
        
        private SceneManager(Game game)
        {
            this.game = game;
            this.random = new Random();
            this.scene = new Opening(game);
            this.currentScene = SCENE.SCN_OPENING;
        }    

        static public SceneManager GetInstance(Game game)
        {
            if (instance == null)
            {
                instance = new SceneManager(game);
            }
            return instance;
        }

        public void Update(GameTime gameTime)
        {
            scene.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            scene.Draw(spriteBatch);
        }

        public void ChangeScene()
        {
            switch (currentScene)
            {
                case SCENE.SCN_OPENING:                    
                    scene = new Level01(game);
                    currentScene = SCENE.SCN_LEVEL_01;
                    break;

                case SCENE.SCN_LEVEL_01:
                    int rnd = random.Next(100);
                    if (rnd < 50)
                    {
                        scene = new Congrats(game);
                        currentScene = SCENE.SCN_CONGRATS;
                    }
                    else
                    {
                        scene = new GameOver(game);
                        currentScene = SCENE.SCN_GAMEOVER;
                    }
                    break;                  
                   
                case SCENE.SCN_CONGRATS:
                case SCENE.SCN_GAMEOVER:
                    scene = new Opening(game);
                    currentScene = SCENE.SCN_OPENING;
                    break;

                default:
                    scene = new Opening(game);
                    currentScene = SCENE.SCN_OPENING;
                    Console.WriteLine("SCENEMANAGER: OCORREU UM ERRO");
                    break;
            }
        }
    }

    public enum SCENE
    {
        SCN_OPENING,
        SCN_LEVEL_01,
        SCN_LEVEL_02, 
        SCN_CONGRATS,
        SCN_GAMEOVER,
    }
}
