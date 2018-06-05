using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsLibrary.csharp.Experiments.RPG.Models
{
   public abstract class DestructibleObject : Actor
    {
        public DestructibleObject()
        {
            BaseSpeed = 0.0;
            MaxHealth = 10;
            MaxSpeed = 10;
            IsMobile = false;

                
        }
    }



}
