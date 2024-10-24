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
        private ContentManager contentManager;

        private MovingBackground background;

        private Jaguar jaguar;
        private Player player;
        private float baseAnimationSpeed = 0.2f;

        private bool gameOver = false;
        private float timeLeft = 30f;
        private float speedUpTimer = 10f;

        float baseSpeed = 178f;

        private List<Obstacle> obstaclesInScene = new List<Obstacle>();
        private float[] lanePos = new float[3];
        private float objectSpawnTimer = 1f;
        private int minSpawnTime = 1;
        private int maxSpawnTime = 3;

        private Obstacle hitObject;

        public DodgeMinigame(ContentManager pContent, Game1 pGame1) : base(pGame1)
        {
            contentManager = pContent;
            CreateObjects();
        }

        protected override void CreateObjects()
        {
            background = new MovingBackground(game, baseSpeed);

            lanePos[0] = game.Window.ClientBounds.Height * 0.3f;
            lanePos[1] = game.Window.ClientBounds.Height * 0.5f;
            lanePos[2] = game.Window.ClientBounds.Height * 0.7f;

            player = new Player(new Vector2(900, lanePos[1]), "Sprites\\RunningManSpriteSheet", Color.White, lanePos);
            jaguar = new Jaguar(new Vector2(450, lanePos[1]), "Sprites\\JaguarSpriteSheet", Color.White, player);

            sceneContent.Add(jaguar);
            sceneContent.Add(player);

            LoadContent(contentManager);
        }

        public override void LoadContent(ContentManager pContent)
        {
            base.LoadContent(pContent);

            jaguar.Initialize();
            player.Initialize();
        }

        public override void Update(GameTime pGameTime)
        {
            background.MoveBackground(pGameTime);
            base.Update(pGameTime);
            CheckForCollision();

            if (gameOver == false)
            {
                SpawnObjects(pGameTime);
                Timers(pGameTime);
            }
            else
            {
                jaguar.GameOver(pGameTime);
                player.PlayFallAnimation(game.Content.Load<Texture2D>("Sprites\\FallingManSpriteSheet"));

                if (jaguar.hitBox.Contains(player.hitBox))
                {
                    game.EndMinigame();
                }
            }
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            background.DrawBackground(pSpriteBatch);
            sceneContent.Reverse();
            base.Draw(pSpriteBatch);
            sceneContent.Reverse();

            pSpriteBatch.DrawString(game.gameFont, Math.Floor(timeLeft).ToString(), new Vector2(game.Window.ClientBounds.Width / 2, 10f), Color.Yellow, 0f, game.gameFont.MeasureString(Math.Floor(timeLeft).ToString()) / 2, 1f, SpriteEffects.None, 1f);
        }

        private void SpawnObjects(GameTime pGameTime)
        {
            objectSpawnTimer -= (float)pGameTime.ElapsedGameTime.TotalSeconds;

            Random rnd = new Random();
            int spawnPos = rnd.Next(0, 3);

            if (objectSpawnTimer < 0)
            {
                Obstacle obstacle = new Obstacle(new Vector2(game.Window.ClientBounds.Width, (int)lanePos[spawnPos]), "Sprites\\Obstacles", Color.White, baseSpeed);
                obstacle.LoadSprite(contentManager);
                sceneContent.Add(obstacle);
                obstaclesInScene.Add(obstacle);

                objectSpawnTimer = rnd.Next(minSpawnTime, maxSpawnTime);
            }
        }

        private void CheckForCollision()
        {
            for (int i = 0; i < obstaclesInScene.Count; i++)
            {
                if (obstaclesInScene[i].hitBox.Intersects(player.hitBox))
                {
                    hitObject = obstaclesInScene[i];
                    gameOver = true;
                }
            }

            if (hitObject != null && !hitObject.hitBox.Intersects(player.hitBox))
            {
                hitObject = null;
            }
        }

        private void Timers(GameTime pGameTime)
        {
            timeLeft -= (float)pGameTime.ElapsedGameTime.TotalSeconds;
            speedUpTimer -= (float)pGameTime.ElapsedGameTime.TotalSeconds;

            if (timeLeft <= 0)
            {
                game.EndMinigame();
            }

            if (speedUpTimer <= 0)
            {
                speedUpTimer = 10f;
                baseSpeed += 25;
                baseAnimationSpeed *= 0.5f;
                player.ChangeSpeed(baseAnimationSpeed);
                jaguar.ChangeSpeed(baseAnimationSpeed);
                background.ChangeSpeed(baseSpeed);
                for (int i = 0; i < obstaclesInScene.Count; i++)
                {
                    obstaclesInScene[i].ChangeSpeed(baseSpeed);
                }
            }
        }
    }
}
