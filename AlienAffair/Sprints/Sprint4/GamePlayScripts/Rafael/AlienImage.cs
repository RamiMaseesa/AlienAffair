using System;
using System.Runtime.ConstrainedExecution;
using AlienAffair.Sprints.Sprint4.FrameWorkScripts;
using Microsoft.Xna.Framework;

namespace AlienAffair.Sprints.Sprint4.GamePlayScripts.Rafael;

public class AlienImage : GameObject
{

    int indexX = 0;

    public AlienImage(Vector2 pPosition, Rectangle pRectangle) : base(pPosition, pRectangle)
    {
        path = "Sprites\\AlienSprites";
        scale = 0.8f;
    }

    public void Update(GameTime pGameTime, int dialogueEmotion)
    {
        ChangeRectangle(dialogueEmotion);
    }

    public void ChangeRectangle(int pIndexY)
    {
        int indexY = pIndexY;

        if(pIndexY > 6)
        {
            indexX = 1;
            indexY = indexY - 6;
        }
        else
            indexX = 0;

        rectangle = new Rectangle(0 + (1000 * indexY), 0 + (1333 * indexX), 1000 ,1333);
    }

}
