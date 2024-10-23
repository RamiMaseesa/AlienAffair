using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.Wanted
{
    public class WantedMiniGame : SceneBase
    {
        SpriteFont font;

        ContentManager contentManager;
        Texture2D background;
        Color sceneColor = Color.White;

        int[] faceSprites = { 0, 64, 128 };
        int humanAmount = 100;

        ObjectWanted wantedPerson;
        Texture2D wantedSprite;
        int drawWantedPosX;
        int drawWantedPosY;

        PlayerCircle playerCircle;

        float timeLeft = 90f;
        int timesWon = 0;

        Rectangle gameScreen;

        public WantedMiniGame(ContentManager pContent, Game1 pGame1) : base(pGame1)
        {
            contentManager = pContent;
            CreateObjects();
        }

        protected override void CreateObjects()
        {
            sceneContent.Clear();
            background = contentManager.Load<Texture2D>("Sprites\\Backgrounds\\Background_Wanted");
            font = contentManager.Load<SpriteFont>("Fonts\\WantedGameFont");


            gameScreen = new Rectangle(300, 160, 1075, 925);

            Random rnd = new Random();

            drawWantedPosX = faceSprites[rnd.Next(0, 3)];
            drawWantedPosY = faceSprites[rnd.Next(0, 3)];

            wantedPerson = new ObjectWanted(new Vector2(rnd.Next(gameScreen.X + 64, gameScreen.Width - 64), rnd.Next(gameScreen.Y + 64, gameScreen.Height - 64)), "Sprites\\FaceSpriteSheet", sceneColor, new Rectangle(drawWantedPosX, drawWantedPosY, 63, 63));
            wantedPerson.LoadSprite(contentManager);
            sceneContent.Add(wantedPerson);

            wantedSprite = wantedPerson.texture2D;

            for (int i = 0; i < humanAmount; i++)
            {
                int drawPosX = faceSprites[rnd.Next(0, 3)];
                int drawPosY = faceSprites[rnd.Next(0, 3)];

                if (drawPosX != drawWantedPosX || drawPosY != drawWantedPosY)
                {
                    ObjectWanted alien = new ObjectWanted(new Vector2(rnd.Next(gameScreen.X + 64, gameScreen.Width - 64), rnd.Next(gameScreen.Y + 64, gameScreen.Height - 64)), "Sprites\\FaceSpriteSheet", sceneColor, new Rectangle(drawPosX, drawPosY, 63, 63));
                    alien.LoadSprite(contentManager);
                    sceneContent.Add(alien);
                }
                else
                {
                    i--;
                }
            }

            playerCircle = new PlayerCircle(new Vector2((gameScreen.X + gameScreen.Width) / 2, (gameScreen.Y + gameScreen.Height) / 2), "Sprites\\White_Circle", sceneColor * 0.40f, new Rectangle(0, 0, 64, 64));
            playerCircle.LoadSprite(contentManager);
        }

        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);

            if (playerCircle.DetectWanted(wantedPerson, pGameTime) == true)
            {
                timeLeft += 15;
                timesWon++;
                CreateObjects();
            }
            else
            {
                timeLeft -= (float)pGameTime.ElapsedGameTime.TotalSeconds;
            }

            playerCircle.MoveCircle(pGameTime, gameScreen);
            playerCircle.DetectWanted(wantedPerson, pGameTime);
            CheckWallCollision();

            if (timesWon >= 5)
            {
                game.EndMinigame();
            }
            else if (timeLeft <= 0)
            {
                game.EndMinigame();
            }
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(background, new Vector2(0, 0), sceneColor);

            pSpriteBatch.DrawString(font, Math.Floor(timeLeft).ToString(), new Vector2(688, 0), Color.Yellow, 0f, new Vector2(32, 0), 1f, SpriteEffects.None, 1f);

            pSpriteBatch.DrawString(font, "Found:" + timesWon.ToString(), new Vector2(1609, 233), Color.Yellow, 0f, new Vector2(32, 0), 1f, SpriteEffects.None, 1f);

            pSpriteBatch.Draw(wantedSprite, new Vector2(1609, 433), new Rectangle(drawWantedPosX, drawWantedPosY, 63, 63), sceneColor, 0f, new Vector2(0, 0), 1.95f, SpriteEffects.None, 1f);


            base.Draw(pSpriteBatch);
            playerCircle.Draw(pSpriteBatch);

        }

        private void CheckWallCollision()
        {
            foreach (ObjectWanted alien in sceneContent)
            {
                if (alien.position.Y + 64 > gameScreen.Height || alien.position.Y - 64 < gameScreen.Y)
                {
                    alien.FlipDirectionY();
                }
                else if (alien.position.X + 64 > gameScreen.Width || alien.position.X - 64 < gameScreen.X)
                {
                    alien.FlipDirectionX();
                }
            }
        }

        private void EndGame()
        {
            if (game.GetPreviousScene() is TextWriterScene)
            {
                game.ChangeScene(GameStates.textWriterScene);
            }
            else
            {
                game.LoadGame1();
            }
        }
    }
}
