using AlienAffair.Sprints.Sprint4.GamePlayScripts.Rafael;
using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Text.Json;
using AlienAffair.Sprints.Sprint4.GamePlayScripts;
using System.Collections.Generic;
using System;

namespace AlienAffair.Sprints.Sprint4.FrameWorkScripts
{
    public class TextWriterScene : SceneBase
    {
        //Tutorial on https://www.tutlane.com/tutorial/csharp/csharp-properties-get-set
        Dialogue _currentDialogue;
        DialogueManager dialogueManager;
        public string jsonPath;


        public Dialogue CurrentDialogue
        {
            get { return _currentDialogue; }
            set
            {
                if (_currentDialogue != value)
                {
                    _currentDialogue = value;
                    _currentDialogue.SetPixel(game.pixel);
                    _currentDialogue.SetSpriteFont(game.gameFont);
                    _currentDialogue.GetDialogueManager(dialogueManager);
                    for (int i = 0; i < _currentDialogue.Text.Length; i++)
                    {
                         _currentDialogue.Text[i].ResetDialogue();
                    }
                    _currentDialogue.ResetDialogue();
                }
            }
        }

        AlienImage alien = new AlienImage(new Vector2(400, 600), new Rectangle(0, 0, 1000, 1333));

        public TextWriterScene(Game1 pGame) : base(pGame)
        {
            jsonPath = "Content/Json/Chapter1.json";
            dialogueManager = new DialogueManager(jsonPath);
            CreateObjects();
        }

        protected override void CreateObjects()
        {
            base.CreateObjects();
            sceneContent.Add(alien);
            
        }

        public override void Update(GameTime pGameTime)
        {
            base.Update(pGameTime);

            CurrentDialogue = dialogueManager.dialogueData;
            alien.Update(pGameTime, (int)_currentDialogue.CurrentEmotion);
            //KeyboardState kstate = Keyboard.GetState();

            _currentDialogue.Update(pGameTime);
            _currentDialogue.Update(pGameTime);

            //switch()
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
            _currentDialogue.Draw(pSpriteBatch, game.gameFont);

        }

        public override void LoadContent(ContentManager pContent)
        {
            base.LoadContent(pContent);
            CurrentDialogue = dialogueManager.dialogueData;

            var jsonFile = File.ReadAllText("Content/Json/Chapter2.json");
        }

        public DialogueManager GetDialogueManager()
        {
            return dialogueManager;
        }
    }
}
