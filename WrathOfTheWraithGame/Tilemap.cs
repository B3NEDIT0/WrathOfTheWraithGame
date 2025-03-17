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

        public static Dictionary<Vector2, int> GenerateObstacles(StreamReader streamReader, Dictionary<Vector2, int> finalResult)
        {
            int rowIndex;
            int columnIndex;
            const int ROWS = 36;
            const int COLUMNS = 48;
            Random obstRand = new();
            float numOfObstacles = obstRand.Next(25,30);

            
            for(int i = 0; i < numOfObstacles; i++)
            {
                int obstacleType = obstRand.Next(1, 4);
                int j = 0;
                columnIndex = obstRand.Next(2, COLUMNS - 2);// deciding the range for where the column of the root obstacle node will be chosem.
                rowIndex = obstRand.Next(2, ROWS - 2); // deciding the range for where the row of the root obstacle node will be chosen.  


                switch (obstacleType)
                {
                    case 1:
                        finalResult[new Vector2(columnIndex, rowIndex)] = 3;
                        finalResult[new Vector2(columnIndex + 1, rowIndex)] = 3;
                        finalResult[new Vector2(columnIndex - 1, rowIndex)] = 3;
                        finalResult[new Vector2(columnIndex, rowIndex + 1)] = 3;
                        finalResult[new Vector2(columnIndex, rowIndex - 1)] = 3;
                    break;
                    case 2:
                        finalResult[new Vector2(columnIndex, rowIndex)] = 3;
                        finalResult[new Vector2(columnIndex + 1, rowIndex)] = 3;
                        finalResult[new Vector2(columnIndex, rowIndex - 1)] = 3;
                        finalResult[new Vector2(columnIndex + 1, rowIndex - 1)] = 3;
                        break;
                    case 3:
                        finalResult[new Vector2(columnIndex, rowIndex)] = 3;
                        finalResult[new Vector2(columnIndex + 1, rowIndex)] = 3;
                        finalResult[new Vector2(columnIndex - 1, rowIndex)] = 3;
                        finalResult[new Vector2(columnIndex - 1, rowIndex - 1)] = 3;
                        finalResult[new Vector2(columnIndex + 1, rowIndex - 1)] = 3;
                        break;
                }

            }

            return finalResult;
        }


        public static Dictionary<Vector2, int> Load(string path)
        {
            StreamReader streamReader = new(path);
            string line = "";
            Dictionary<Vector2, int> result1 = new Dictionary<Vector2, int>();
            Dictionary<Vector2, int> result2 = new Dictionary<Vector2, int>();
            int j = 0;

            //
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] indexes = line.Split(',');
                Globals.MapSizeX = indexes.Length * 64;

                for (int i = 0; i < indexes.Length; i++)
                {

                    if (int.TryParse(indexes[i], out int temp)) result1[new Vector2(i, j)] = temp;
                }

                j++;
            }
            Globals.MapSizeY = j * 64;

            result2 = Tilemap.GenerateObstacles(streamReader, result1); // return dictionary of tilemap with generated obstacles. 
            Globals.CurrentObstacles = Tilemap.GetObstacles(result2);
            return result2;
        }

        

        public static void Draw(Dictionary<Vector2, int> _tilemap, List<Rectangle> _rectList, Texture2D _tileSet)
        {
            const int xSCALE = 64; //rounded - 20 columns and each 64 pixels wide, so 64
            const int ySCALE = 64;
            
            foreach(var item in _tilemap)
            {
                Rectangle destination = new((int)item.Key.X * xSCALE , (int)item.Key.Y * ySCALE, xSCALE, ySCALE);
                Rectangle source = _rectList[item.Value];
                Globals.SpriteBatch.Draw(_tileSet, destination, source, Color.White);
            }
            
        }

        public static Dictionary<Vector2, int> GetObstacles(Dictionary<Vector2, int> _tilemap)
        {
            Dictionary<Vector2, int> obstacles = new Dictionary<Vector2, int>();     // local obstacles.
            foreach(var item in _tilemap) {
                if(item.Value == 3) obstacles.Add(item.Key, item.Value); // add obstccles if they have a value of 3.
            }

            return obstacles;
        }

    }
}
