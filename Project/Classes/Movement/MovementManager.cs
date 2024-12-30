using Microsoft.Xna.Framework;
using Project.Classes.Collision;
using Project.Classes.GameObjects.Characters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Project.Classes.Movement
{
    internal class MovementManager
    {
        // TODO: acceleration? 
        private Vector2 acceleration = new Vector2(2f, 2f);
        

        public void Move(IMovable movable)
        {
            var nextPos = movable.Position + movable.Speed;
            // TODO: checkCollisions and reverse speed

            movable.Position += movable.Speed;
            movable.Speed += acceleration;
            float maxSpeed = 5;
            movable.Speed = Limit(movable.Speed, maxSpeed);

            if (IsCharWithinX(movable))
            {
                movable.Speed = new Vector2(movable.Speed.X < 0 ? 1 : -1, movable.Speed.Y);
                acceleration.X *= -1;
            }
            if (IsCharWithinY(movable))
            {
                movable.Speed = new Vector2(movable.Speed.X, movable.Speed.Y < 0 ? 1 : -1);
                acceleration.Y *= -1;
            }
        }
        
        public void MoveWithKeys(Character character)
        {
            var direction = character.InputReader.ReadInput();

            float acceleration = 0.2f;

            character.Speed += direction * acceleration;

            float maxSpeed = 5;
            character.Speed = Limit(character.Speed, maxSpeed);

            var nextPos = character.Position + character.Speed;

            if (IsMCWithinBounds(nextPos))
            {
                character.Position = TryMove(nextPos, character);
            }
            else
                character.Speed = Vector2.Zero;
        }
    

        /// <summary>
        /// Follows a movable target with an offset. No obstacles untill pathfinding is added
        /// </summary>
        /// <param name="movable"></param>
        /// <param name="target"></param>
        /// <param name="offset"></param>
        public void MoveWithTarget(Character character, IMovable target, Vector2 offset)
        {
            
            Vector2 direction = (target.Position - offset) - character.Position;
            float distance = direction.Length();

            if (distance < 10)
            {
                character.Speed *= 0.9f;
                if (character.Speed.Length() < 0.1f)
                {
                    character.Speed = Vector2.Zero;
                }
                return;
            }
            
            direction.Normalize();
            float acceleration = 3f;

            character.Speed += direction * acceleration;

            float maxSpeed = 2f;
            character.Speed = Limit(character.Speed, maxSpeed);

            character.Position += character.Speed;
        }

        /// <summary>
        /// Limits speed to a maximum
        /// </summary>
        /// <param name="v"></param>
        /// <param name="max"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks if movement is possible with obstacles
        /// </summary>
        /// <param name="targetPos"></param>
        /// <param name="character"></param>
        /// <param name="obstacles"></param>
        /// <returns>New position if movement possible, else current position</returns>
        private Vector2 TryMove(Vector2 targetPos, Character character)
        {
            var tempCollisionBox = new CollisionBox(targetPos, character.ColBox.Size, character.ColBox.texture);
            foreach (var obstacle in character.obstacles)
            {
                if (tempCollisionBox.IsCollidingWith(obstacle.ColBox))
                {
                    return character.Position;
                }
            }
            return targetPos;
        }


        // TODO: this is a fix because sprite MC is weird (so fix sprite instead of this code)

        private bool IsMCWithinBounds(Vector2 p)
        {
           // return p.X >= -48 && p.X <= (1600 - 144) && p.Y >= 0 && p.Y <= (960 - 96); // from screen
            return p.X >= -48 && p.X <= (Globals.mapSizeX-144) && p.Y >= 0 && p.Y <= (Globals.mapSizeY-120); // from map? 

        }
        private bool IsCharWithinX(IMovable movable)
        {
            return movable.Position.X + movable.Speed.X > Globals.mapSizeX - 64 || movable.Position.X + movable.Speed.X < 0;
        }
        private bool IsCharWithinY(IMovable movable)
        {
            return movable.Position.Y + movable.Speed.Y > Globals.mapSizeY - 96 || movable.Position.Y + movable.Speed.Y < 0;
        }
    }
}
