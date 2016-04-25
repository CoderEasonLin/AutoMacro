using System.Collections.Generic;
using AutoMacro.Class;

namespace AutoMacro
{
    public class Macro
    {
        public List<Movement> Movements { get; set; }

        public Macro()
        {
            Movements = new List<Movement>();
        }

        public void Run()
        {
            foreach (var movement in Movements)
            {
                movement.Do();
            }
        }
    }
}