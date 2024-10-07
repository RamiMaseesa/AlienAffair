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
        int alienAmount = 50;

        public WantedMiniGame(ContentManager pContent)
        {
            Initialize(pContent);
        }

        private void Initialize(ContentManager pContent)
        {
            Random rnd = new Random();
            wantedAlien = new AlienObjectWanted(new Vector2(rnd.Next(0, 1921), rnd.Next(1081)), "Alien Head");

            for (int i = 0; i < alienAmount; i++)
            {
                AlienObjectWanted alien = new AlienObjectWanted(new Vector2(rnd.Next(0, 1921), rnd.Next(1081)), "Alien Head");
                aliensInScene.Add(alien);
                alien.LoadSprite(pContent);
            }
        }

        public void Update(GameTime pGameTime)
        {
            foreach (AlienObjectWanted alien in aliensInScene)
            {
                alien.Update(pGameTime);
            }
        }
        public void Draw(SpriteBatch pSpriteBatch)
        {
            foreach (AlienObjectWanted alien in aliensInScene)
            {
                alien.Draw(pSpriteBatch);
            }
        }
    }
}
