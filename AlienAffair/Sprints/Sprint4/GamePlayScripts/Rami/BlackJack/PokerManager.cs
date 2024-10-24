using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Rami.BlackJack
{
    public class PokerManager
    {
        private List<CardBase> cards = new List<CardBase>();
        private GraphicsDeviceManager graphics;
        private ContentManager content;
        //private int playerPoints = 0;
        //private int AIPoints = 0;

        private int AICardHeight = 200;
        private int PlayerCardHeight = 600;

        public PokerManager(GraphicsDeviceManager graphics, ContentManager content)
        {
            this.graphics = graphics;
            this.content = content;
        }

        public virtual void OnGameStart()
        {
            AICard card1;
            AICard card2;
            PlayerCard card3;
            PlayerCard card4;
            cards.Add(card1 = new AICard(new Vector2 (400, AICardHeight), new string[] { "Sprites\\PokerClover", "Sprites\\PokerClubs", "Sprites\\PokerDiamand", "Sprites\\PokerHart" }, cards));
            cards.Add(card2 = new AICard(new Vector2 (650, AICardHeight), new string[] { "Sprites\\PokerClover", "Sprites\\PokerClubs", "Sprites\\PokerDiamand", "Sprites\\PokerHart" }, cards));
            cards.Add(card3 = new PlayerCard(new Vector2 (400, PlayerCardHeight), new string[] { "Sprites\\PokerClover", "Sprites\\PokerClubs", "Sprites\\PokerDiamand", "Sprites\\PokerHart" }, cards));
            cards.Add(card4 = new PlayerCard(new Vector2 (650, PlayerCardHeight), new string[] { "Sprites\\PokerClover", "Sprites\\PokerClubs", "Sprites\\PokerDiamand", "Sprites\\PokerHart" }, cards));

            foreach (CardBase card in cards)
            {
                card.LoadSprite(content); 
            }
        }

        public void WinCheck()
        {
            int sumAI = 0;
            int sumPlayer = 0;

            foreach (CardBase cardBase in cards)
            {
                if (cardBase is AICard) sumAI += cardBase.value;
                if (cardBase is PlayerCard) sumPlayer += cardBase.value;
            }

            if (sumPlayer > 21)
            {
                cards.Clear();
                OnGameStart();
                Console.WriteLine("Player Bust");
            }
            else if (sumAI > 21) 
            {
                cards.Clear();
                OnGameStart();
                Console.WriteLine("AI Bust");
            }

            if (sumAI < 17) return;

            if (sumPlayer == sumAI)
            {
                cards.Clear();
                OnGameStart();
                Console.WriteLine("TIE");
            }
            else if (sumPlayer > sumAI)
            {
                cards.Clear();
                OnGameStart();
                Console.WriteLine("Player WIN");
            }
            else
            {
                cards.Clear();
                OnGameStart();
                Console.WriteLine("AI WIN");
            }
        }

        public virtual void Draw(SpriteBatch pSpriteBatch)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].DrawSprite(pSpriteBatch);
            }
        }

        public void OnHit()
        {
            int sum = 0;

            foreach (CardBase cardBase in cards)
            {
                if (cardBase is PlayerCard) sum += cardBase.value;
            }

            if (sum >= 21) return;

            int amountOfPlayerCards = 0;
            foreach (CardBase cardBase in cards)
            {
                if (cardBase is PlayerCard) amountOfPlayerCards++;
            }

            PlayerCard card;
            cards.Add(card = new PlayerCard(new Vector2(400 + amountOfPlayerCards * 250, PlayerCardHeight), new string[] { "Sprites\\PokerClover", "Sprites\\PokerClubs", "Sprites\\PokerDiamand", "Sprites\\PokerHart" }, cards));
            card.LoadSprite(content);

            WinCheck();
        }

        public void OnStand()
        {
            int sum = 0;

            foreach (CardBase cardBase in cards)
            {
                if (cardBase is AICard) sum += cardBase.value;
            }

            if (sum >= 17) return;

            do {
                int amountOfAICards = 0;
                foreach (CardBase cardBase in cards)
                {
                    if (cardBase is AICard) amountOfAICards++;
                }

                AICard card;
                cards.Add(card = new AICard(new Vector2(400 + amountOfAICards * 250, AICardHeight), new string[] { "Sprites\\PokerClover", "Sprites\\PokerClubs", "Sprites\\PokerDiamand", "Sprites\\PokerHart" }, cards));
                card.LoadSprite(content);

                sum = 0;

                foreach (CardBase cardBase in cards)
                {
                    if (cardBase is AICard) sum += cardBase.value;
                }
            } while (sum < 17);

            WinCheck();
        }
    }
}
