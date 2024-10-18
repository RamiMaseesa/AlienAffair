using AlienAffair.Sprints.Sprint3.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace AlienAffair.Sprints.Sprint3.GamePlayScripts.Elliot.Dodge
{
    public class DodgeMinigame : SceneBase
    {
        ContentManager contentManager;

        Jaguar jaguar;
        Player man;

        int maxObjectCount = 3;
        List<Obstacle> obstaclesInScene = new List<Obstacle>();
        float[] lanePos = new float[3];

        public DodgeMinigame(ContentManager pContent, Game1 pGame1) : base(pGame1)
        {
            contentManager = pContent;

            CreateObjects();
        }

        protected override void CreateObjects()
        {
            lanePos[0] = _game.Window.ClientBounds.Height * 0.3f;
            lanePos[1] = _game.Window.ClientBounds.Height * 0.5f;
            lanePos[2] = _game.Window.ClientBounds.Height * 0.7f;

            man = new Player(new Vector2(900, lanePos[1]), "Content\\Sprites\\RunningManSpriteSheet", Color.White, lanePos);
            jaguar = new Jaguar(new Vector2(450, lanePos[1]), "Content\\Sprites\\JaguarSpriteSheet", Color.White, man);

            sceneContent.Add(jaguar);
            sceneContent.Add(man);

            LoadContent(contentManager);
        }

        public override void LoadContent(ContentManager pContent)
        {
            base.LoadContent(pContent);

            jaguar.Initialize();
            man.Initialize();
        }

        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);
            //SpawnObjectsL();
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
        }

        private void SpawnObjects()
        {
            Random rnd = new Random();
            int spawnPos = rnd.Next(0, 3);

            if (obstaclesInScene.Count == 0)
            {
                Obstacle obstacle = new Obstacle(new Vector2(_game.Window.ClientBounds.Width, (int)lanePos[spawnPos]), "Content\\Sprites\\Obstacles", Color.White, 75);
                obstacle.LoadSprite(contentManager);
                sceneContent.Add(obstacle);
                obstaclesInScene.Add(obstacle);
            }

            if (obstaclesInScene.Count < maxObjectCount)
            {
                Rectangle spawnBox = new Rectangle(_game.Window.ClientBounds.Width, (int)lanePos[spawnPos], 64, 64);

                for (int i = 0; i < obstaclesInScene.Count; ++i)
                {
                    if (!obstaclesInScene[i].hitBox.Intersects(spawnBox))
                    {
                        Obstacle obstacle = new Obstacle(new Vector2(_game.Window.ClientBounds.Width, lanePos[spawnPos]), "Content\\Sprites\\Obstacles", Color.White, 75);
                        obstacle.LoadSprite(contentManager);
                        sceneContent.Add(obstacle);
                        obstaclesInScene.Add(obstacle);
                    }
                    else
                    {
                        i--;
                    }

                }
            }
        }











        private void SpawnObjectsL()
        {

            if (obstaclesInScene.Count < maxObjectCount)
            {
                Random rnd = new Random();
                int spawnPos = rnd.Next(0, 3);
                bool canSpawn = false;

                if (obstaclesInScene.Count > 0)
                {
                    Rectangle spawnBox = new Rectangle(_game.Window.ClientBounds.Width, (int)lanePos[spawnPos], 64, 64);
                    Point point = new Point(_game.Window.ClientBounds.Width, (int)lanePos[spawnPos]);

                    //Console.WriteLine(point.X + "    " + point.Y);

                    for (int i = 0; i < obstaclesInScene.Count; i++)
                    {
                        int distance = (int)obstaclesInScene[i].position.Y - spawnBox.Y;

                        Console.WriteLine(" distance" + distance);
                        Console.WriteLine("1   " + spawnBox.X + ", " + spawnBox.Y + "   " + obstaclesInScene[i].position.X + "   " + obstaclesInScene[i].position.Y);

                        if (!obstaclesInScene[i].hitBox.Intersects(spawnBox))
                        {
                            Console.WriteLine("2   " + spawnBox.X + ", " + spawnBox.Y + "   " + obstaclesInScene[i].position.X + "   " + obstaclesInScene[i].position.Y);
                            canSpawn = true;
                        }
                        else
                        {
                            Console.WriteLine("niet werken?" + obstaclesInScene.Count);
                            canSpawn = false;
                        }
                    }

                    if (canSpawn == true)
                    {
                        Obstacle obstacle = new Obstacle(new Vector2(_game.Window.ClientBounds.Width, lanePos[spawnPos]), "Content\\Sprites\\Obstacles", Color.White, 75);
                        obstacle.LoadSprite(contentManager);
                        sceneContent.Add(obstacle);
                        obstaclesInScene.Add(obstacle);
                    }
                    else if(canSpawn == false)
                    {
                        Console.WriteLine("NUH UH");
                    }

                }
                else
                {
                    Obstacle obstacle = new Obstacle(new Vector2(_game.Window.ClientBounds.Width, lanePos[spawnPos]), "Content\\Sprites\\Obstacles", Color.White, 75);
                    obstacle.LoadSprite(contentManager);
                    sceneContent.Add(obstacle);
                    obstaclesInScene.Add(obstacle);

                }
            }
        }
    }
}
