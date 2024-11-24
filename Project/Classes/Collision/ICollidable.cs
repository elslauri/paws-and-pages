using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.Collision
{
    internal interface ICollidable
    {
        CollisionBox BoxCollision { get; set; }
    }
}
