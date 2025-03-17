using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathOfTheWraithGame
{
    public class Dominator : Enemy
    {
        private float timer;
        private float waitTime;
        public Dominator()
        {
            this.position = new Vector2(800, 600);
            this.Texture = Globals.Content.Load<Texture2D>("purpleenemy");
        }
        

        public override void Update()
        {
            if (isActive)
            {
                
            }

            if (!isActive)
            {
                this.idleCount += Globals.DeltaTime;
                this.timer += Globals.DeltaTime;
                this.position.Y += MathF.Sin(idleCount * 2f) * .5f;
            }
        }


        public override void Draw()
        {
            Globals.SpriteBatch.Draw(texture, this.position, this.boundBox, Color.White, 0f, this.origin, 0.3f, SpriteEffects.None, 0f);
        }

        /*

         private List<Point> AStar(Point start, Point goal)
         {
             var openSet = new SortedSet<(int f, int x, int y)>(Comparer<(int, int, int)>.Create((a, b) => a.f == b.f ? (a.x == b.x ? a.y - b.y : a.x - b.x) : a.f - b.f));
             var cameFrom = new Dictionary<Point, Point>();
             var gScore = new Dictionary<Point, int> { [start] = 0 };
             var fScore = new Dictionary<Point, int> { [start] = Manhattan(start, goal) };

             openSet.Add((fScore[start], start.X, start.Y));

             while (openSet.Count > 0)
             {
                 var current = openSet.Min;
                 openSet.Remove(current);
                 Point currentPoint = new Point(current.x, current.y);

                 if (currentPoint == goal)
                     return ReconstructPath(cameFrom, currentPoint);

                 foreach (var neighbor in GetNeighbors(currentPoint))
                 {
                     int tentativeGScore = gScore[currentPoint] + 1;
                     if (!gScore.ContainsKey(neighbor) || tentativeGScore < gScore[neighbor])
                     {
                         cameFrom[neighbor] = currentPoint;
                         gScore[neighbor] = tentativeGScore;
                         fScore[neighbor] = gScore[neighbor] + Manhattan(neighbor, goal);
                         openSet.Add((fScore[neighbor], neighbor.X, neighbor.Y));
                     }
                 }
             }
             return new List<Point>();
         }

         private int Manhattan(Point a, Point b)
         {
             return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
         }

         private List<Point> GetNeighbors(Point p)
         {
             List<Point> neighbors = new List<Point>();
             foreach (var d in new[] { new Point(1, 0), new Point(-1, 0), new Point(0, 1), new Point(0, -1) })
             {
                 Point np = new Point(p.X + d.X, p.Y + d.Y);
                 if (np.X >= 0 && np.X < gridWidth && np.Y >= 0 && np.Y < gridHeight && grid[np.X, np.Y] == 0)
                     neighbors.Add(np);
             }
             return neighbors;
         }

         private List<Point> ReconstructPath(Dictionary<Point, Point> cameFrom, Point current)
         {
             List<Point> path = new List<Point> { current };
             while (cameFrom.ContainsKey(current))
             {
                 current = cameFrom[current];
                 path.Add(current);
             }
             path.Reverse();
             return path;
         }
        */
     }

    
}



