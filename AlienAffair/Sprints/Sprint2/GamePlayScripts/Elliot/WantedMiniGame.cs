using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace AlienAffair.Sprints.Sprint2.GamePlayScripts.Elliot
{
    public class WantedMiniGame
    {
        List<Texture2D> alienSpriteList;
        List<AlienObjectWanted> aliensInScene = new List<AlienObjectWanted>();
        AlienObjectWanted wantedAlien;
        PlayerCircle playerCircle;
        int alienAmount = 100;

        Rectangle gameScreen;

        public WantedMiniGame(ContentManager pContent)
        {
            Initialize(pContent);
        }

        private void Initialize(ContentManager pContent)
        {
            gameScreen = new Rectangle(50, 50, 750, 750);

            Random rnd = new Random();
            wantedAlien = new AlienObjectWanted(new Vector2(rnd.Next(gameScreen.X + 64, gameScreen.Width - 64), rnd.Next(gameScreen.Y + 64, gameScreen.Height - 64)), "Alien Head", Color.Blue, new Rectangle(0, 0, 64, 64));
            wantedAlien.LoadSprite(pContent);
            aliensInScene.Add(wantedAlien);

            for (int i = 0; i < alienAmount; i++)
            {
                AlienObjectWanted alien = new AlienObjectWanted(new Vector2(rnd.Next(gameScreen.X + 64, gameScreen.Width - 64), rnd.Next(gameScreen.Y + 64, gameScreen.Height - 64)), "Alien Head", Color.White, new Rectangle(0, 0, 64, 64));
                alien.LoadSprite(pContent);
                //aliensInScene.Add(alien);
            }

            playerCircle = new PlayerCircle(new Vector2(gameScreen.Width / 2, gameScreen.Height / 2), "White Circle", Color.White * 0.40f, new Rectangle(0, 0, 64, 64));
            playerCircle.LoadSprite(pContent);
        }

        public void Update(GameTime pGameTime)
        {
            foreach (AlienObjectWanted alien in aliensInScene)
            {
                alien.Update(pGameTime);
            }

            playerCircle.MoveCircle(pGameTime, gameScreen);
            playerCircle.DetectWanted(wantedAlien, pGameTime);
            CheckWallCollision();
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

        public void Draw(SpriteBatch pSpriteBatch)
        {
            foreach (AlienObjectWanted alien in aliensInScene)
            {
                alien.Draw(pSpriteBatch);
            }
            playerCircle.Draw(pSpriteBatch);
        }
    }
}
