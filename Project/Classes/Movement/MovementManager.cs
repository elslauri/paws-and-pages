using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Project.Classes.Input;

namespace Project.Classes.Movement
{
    internal class MovementManager
    {
        // TODO: acceleration? 
        private Vector2 acceleration = new Vector2(0.1f, 0.1f);
        public void Move(IMovable movable)
        {
            movable.Position += movable.Speed;
            movable.Speed += acceleration;
            float maxSpeed = 5;
            movable.Speed = Limit(movable.Speed, maxSpeed);

            // TODO: collision box
            if (movable.Position.X + movable.Speed.X > 1600 - 64 || movable.Position.X + movable.Speed.X < 0)
            {
                movable.Speed = new Vector2(movable.Speed.X < 0 ? 1 : -1, movable.Speed.Y);
                acceleration.X *= -1;
            }
            if (movable.Position.Y + movable.Speed.Y > 960 - 96 || movable.Position.Y + movable.Speed.Y < 0)
            {
                movable.Speed = new Vector2(movable.Speed.X, movable.Speed.Y < 0 ? 1 : -1);
                acceleration.Y *= -1;

            }
        }
        // hier juiste plek? nope de Imovable moet hem hebben
        
        public void MoveWithKeys(IMovable movable)
        {
            if (movable.InputReader == null)
            {
                throw new Exception("InputReader is not initialized!");
            }

            var direction = movable.InputReader.ReadInput();

            var distance = direction * movable.Speed;
            movable.Position += distance;
        }

        public void MoveWithMouse(IMovable movable)
        {
            //    // cut? 
            //    if (movable == null)
            //    {
            //        Debug.WriteLine("Null");
            //    }

            //    var direction = movable.InputReader.ReadInput() - movable.Position;

            //    float distance = direction.Length();

            //    // stop when close to mouse
            //    if (distance < 10)
            //    {
            //        movable.Speed = Vector2.Zero;
            //    }

            //    //    direction -= movable.Position;

            //    direction.Normalize();

            //    //var distance = Vector2.Multiply(direction,0.1f);
            //    movable.Speed += direction;
            //    movable.Speed = Limit(movable.Speed, 5);

            //    movable.Position += movable.Speed;
        }

        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

        // TODO: collisions
        
    }
}
