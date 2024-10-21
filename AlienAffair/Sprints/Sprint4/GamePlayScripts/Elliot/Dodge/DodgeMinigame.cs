using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.Dodge
{
    public class DodgeMinigame : SceneBase
    {
        ContentManager contentManager;

        Jaguar jaguar;
        Player man;

        int maxObjectCount = 3;
        List<Obstacle> obstaclesInScene = new List<Obstacle>();
        float[] lanePos = new float[3];
        float objectSpawnTimer = 1f;

        public DodgeMinigame(ContentManager pContent, Game1 pGame1) : base(pGame1)
        {
            contentManager = pContent;
            CreateObjects();
        }

        protected override void CreateObjects()
        {
            lanePos[0] = game.Window.ClientBounds.Height * 0.3f;
            lanePos[1] = game.Window.ClientBounds.Height * 0.5f;
            lanePos[2] = game.Window.ClientBounds.Height * 0.7f;

            man = new Player(new Vector2(900, lanePos[1]), "Sprites\\RunningManSpriteSheet", Color.White, lanePos);
            jaguar = new Jaguar(new Vector2(450, lanePos[1]), "Sprites\\JaguarSpriteSheet", Color.White, man);

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
            SpawnObjects(pGameTime);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
        }

        private void SpawnObjects(GameTime pGameTime)
        {
            objectSpawnTimer -= (float)pGameTime.ElapsedGameTime.TotalSeconds;
            
            Random rnd = new Random();
            int spawnPos = rnd.Next(0, 3);

            if (objectSpawnTimer < 0)
            {
                Obstacle obstacle = new Obstacle(new Vector2(game.Window.ClientBounds.Width, (int)lanePos[spawnPos]), "Sprites\\Obstacles", Color.White, 75);
                obstacle.LoadSprite(contentManager);
                sceneContent.Add(obstacle);
                obstaclesInScene.Add(obstacle);

                objectSpawnTimer = rnd.Next(3, 5);
            }
        }
    }
}
