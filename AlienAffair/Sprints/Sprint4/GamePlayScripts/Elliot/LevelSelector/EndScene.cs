using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Elliot.LevelSelector
{
    public class EndScene : SceneBase
    {
        Texture2D endScreen;

        public EndScene(Game1 pGame1, int pEmotionPoints) : base(pGame1)
        {
            PickEnding(pEmotionPoints);
        }

        private void PickEnding(int pEmotionPoints)
        {
            switch (pEmotionPoints)
            {
                case <=5:
                    Console.WriteLine("1");
                    endScreen = game.Content.Load<Texture2D>("Sprites\\EndScenes\\BadEnding");
                    break;
                case <=10:
                    Console.WriteLine("2");
                    endScreen = game.Content.Load<Texture2D>("Sprites\\EndScenes\\HalfBadEnding");
                    break;
                case <=15:
                    Console.WriteLine("3");
                    endScreen = game.Content.Load<Texture2D>("Sprites\\EndScenes\\HalfGoodEnding");
                    break;
                case <=20:
                    Console.WriteLine("4");
                    endScreen = game.Content.Load<Texture2D>("Sprites\\EndScenes\\GoodEnding");
                    break;
                default:
                    Console.WriteLine("5");
                    endScreen = game.Content.Load<Texture2D>("Sprites\\EndScenes\\BadEnding");
                    break;
            }
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(endScreen, new Vector2(0, 0), Color.White);
        }
    }
}
