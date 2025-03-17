using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Runtime.CompilerServices;

namespace WrathOfTheWraithGame
{
    public static class GUIManager
    {
        public static List<Button> InitialiseButtonList(Texture2D texture, List<Button> buttons)
        {
          
            foreach(var button in buttons) {
                button.Texture = texture;
            }

            return buttons;
        }

        public static void DrawMainMenuButtons(List<Button> buttonList)
        {
           for(int i = 0; i < buttonList.Count;i++) 
            {
                buttonList[i].Draw(new Vector2(Globals.Resolution.X / 2 - buttonList[i].Texture.Width/2, (i + 1) * 280- 200));
            }
        }

        public static void ButtonsUpdate(List<Button> buttonList)
        {
            foreach(var button in buttonList)
            {
                button.Update(Globals.GameTime);
            }
        }
    }
}