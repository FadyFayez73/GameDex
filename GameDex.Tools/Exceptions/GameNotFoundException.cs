using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.Tools.Exceptions
{
    public class GameNotFoundException : Exception
    {
        public GameNotFoundException(int id) : base($"Game with ID {id} was not found.")
        { 
        }
    }
}
