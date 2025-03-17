using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathOfTheWraithGame
{
    public abstract class GameState
    {
        public abstract void Draw();

        public abstract void Update();

        public abstract void Post();

    }
}
