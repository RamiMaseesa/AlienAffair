using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot
{
    public class BackgroundManager
    {
        Game1 game1;

        string[] files;
        List<string> backgroundPaths = new List<string>();
        Texture2D background;

        public BackgroundManager(Game1 pGame1)
        {
            game1 = pGame1;
            background = game1.Content.Load<Texture2D>("Sprites\\Backgrounds\\StarsBackground");
            Initialize();
        }

        private void Initialize()
        {
            files = Directory.GetFiles("Content\\Sprites\\Backgrounds");
            foreach (string file in files)
            {
                string path = file.Remove(0, 8);
                backgroundPaths.Add(path.Remove(path.Length - 4));
            }
        }

        public void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            Console.WriteLine(background);
        }

        public void ChangeBackground(backgrounds pState)
        {
            Console.WriteLine(backgroundPaths[(int)pState]);
            background = game1.Content.Load<Texture2D>(backgroundPaths[(int)pState]);
        }
    }
}
