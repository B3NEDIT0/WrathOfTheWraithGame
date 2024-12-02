using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;

namespace WrathOfTheWraithGame
{
    public static class Tilemap
    {
        public static Dictionary<Vector2, int> Load(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            string line = "";
            Dictionary<Vector2, int> result = new Dictionary<Vector2, int>();
            int j = 0;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] indexes = line.Split(',');

                for (int i = 0; i < indexes.Length; i++)
                {

                    if (int.TryParse(indexes[i], out int temp)) result[new Vector2(i, j)] = temp;
                }

                j++;
            }

            return result;
        }

        public static void Draw(Dictionary<Vector2, int> _tilemap, List<Rectangle> _rectList, Texture2D _tileSet)
        {
            const int X_SCALE = 186;
            const int Y_SCALE = 170;

            foreach(var item in _tilemap)
            {
                Rectangle destination = new((int)item.Key.X * X_SCALE, (int)item.Key.Y * Y_SCALE, X_SCALE, Y_SCALE);
                Rectangle source = _rectList[item.Value];
                Globals.SpriteBatch.Draw(_tileSet, destination, source, Color.White);
            }
        }


    }
}
