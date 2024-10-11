using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace AlienAffair.Sprints.Sprint2.GamePlayScripts.Elliot
{
    public class WantedMiniGame
    {
        SpriteFont font;

        ContentManager Content;
        Texture2D background;
        Color sceneColor = Color.White;

        int[] faceSprites = { 0, 64, 128 };
        int humanAmount = 100;
        List<AlienObjectWanted> aliensInScene = new List<AlienObjectWanted>();

        AlienObjectWanted wantedAlien;
        Texture2D wantedAlienSprite;
        int drawWantedPosX;
        int drawWantedPosY;

        PlayerCircle playerCircle;

        float timeLeft = 90f;
        int timesWon = 0;

        Rectangle gameScreen;

        public WantedMiniGame(ContentManager pContent)
        {
            Content = pContent;
            Initialize();
        }

        private void Initialize()
        {
            aliensInScene.Clear();
            background = Content.Load<Texture2D>("Content\\Sprites\\Background Wanted");
            font = Content.Load<SpriteFont>("Content\\Fonts\\WantedGameFont");


            gameScreen = new Rectangle(300, 160, 1075, 925);

            Random rnd = new Random();

            drawWantedPosX = faceSprites[rnd.Next(0, 3)];
            drawWantedPosY = faceSprites[rnd.Next(0, 3)];

            wantedAlien = new AlienObjectWanted(new Vector2(rnd.Next(gameScreen.X + 64, gameScreen.Width - 64), rnd.Next(gameScreen.Y + 64, gameScreen.Height - 64)), "Content\\Sprites\\FaceSpriteSheet", sceneColor, new Rectangle(drawWantedPosX, drawWantedPosY, 63, 63));
            wantedAlien.LoadSprite(Content);
            aliensInScene.Add(wantedAlien);

            wantedAlienSprite = wantedAlien.texture2D;

            for (int i = 0; i < humanAmount; i++)
            {
                int drawPosX = faceSprites[rnd.Next(0, 3)];
                int drawPosY = faceSprites[rnd.Next(0, 3)];

                if (drawPosX != drawWantedPosX || drawPosY != drawWantedPosY)
                {
                    AlienObjectWanted alien = new AlienObjectWanted(new Vector2(rnd.Next(gameScreen.X + 64, gameScreen.Width - 64), rnd.Next(gameScreen.Y + 64, gameScreen.Height - 64)), "Content\\Sprites\\FaceSpriteSheet", sceneColor, new Rectangle(drawPosX, drawPosY, 63, 63));
                    alien.LoadSprite(Content);
                    aliensInScene.Add(alien);
                }
                else
                {
                    i--;
                }
            }

            playerCircle = new PlayerCircle(new Vector2((gameScreen.X + gameScreen.Width) / 2, (gameScreen.Y + gameScreen.Height) / 2), "Content\\Sprites\\White Circle", sceneColor * 0.40f, new Rectangle(0, 0, 64, 64));
            playerCircle.LoadSprite(Content);
        }

        public void Update(GameTime pGameTime)
        {
            foreach (AlienObjectWanted alien in aliensInScene)
            {
                alien.Update(pGameTime);
            }

            if (playerCircle.DetectWanted(wantedAlien, pGameTime) == true)
            {
                timeLeft += 15;
                timesWon++;
                Initialize();
            }
            else
            {
                timeLeft -= (float)pGameTime.ElapsedGameTime.TotalSeconds;
            }

            playerCircle.MoveCircle(pGameTime, gameScreen);
            playerCircle.DetectWanted(wantedAlien, pGameTime);
            CheckWallCollision();
        }

        public void Draw(SpriteBatch pSpriteBatch)
        {
            if (timesWon >= 5)
            {
                pSpriteBatch.DrawString(font, "You Win!", new Vector2(960, 540), Color.Green, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);
            }
            else if (timeLeft > 0)
            {
                pSpriteBatch.Draw(background, new Vector2(0, 0), sceneColor);

                pSpriteBatch.DrawString(font, Math.Floor(timeLeft).ToString(), new Vector2(688, 0), Color.Yellow, 0f, new Vector2(32, 0), 1f, SpriteEffects.None, 1f);

                pSpriteBatch.DrawString(font, "Found:" + timesWon.ToString(), new Vector2(1609, 233), Color.Yellow, 0f, new Vector2(32, 0), 1f, SpriteEffects.None, 1f);

                pSpriteBatch.Draw(wantedAlienSprite, new Vector2(1609, 433), new Rectangle(drawWantedPosX, drawWantedPosY, 63, 63), sceneColor, 0f, new Vector2(0, 0), 1.95f, SpriteEffects.None, 1f);

                foreach (AlienObjectWanted alien in aliensInScene)
                {
                    alien.Draw(pSpriteBatch);
                }
                playerCircle.Draw(pSpriteBatch);
            } 
            else if (timeLeft <= 0)
            {
                pSpriteBatch.DrawString(font, "You Lose!", new Vector2(960, 540), Color.Red, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);
            }
        }

        private void CheckWallCollision()
        {
            foreach (AlienObjectWanted alien in aliensInScene)
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
    }
}
