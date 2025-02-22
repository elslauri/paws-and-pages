﻿using Microsoft.Xna.Framework;
using Project.Classes.Collision;
using Project.Classes.GameObjects.Characters;
using System.Diagnostics;


namespace Project.Classes.Movement
{
    internal class MovementManager
    {
        public void Move(Character character)
        {
            float acceleration = 0.3f;
            character.Speed += character.Speed * acceleration;
            character.Speed = Limit(character.Speed, character.MaxSpeed);

            Vector2 nextPos = character.Position + character.Speed;

            if (IsCharWithinX(character) && IsCharWithinY(character))
            {
                if (!TryMove(nextPos, character))
                {
                    Vector2 nextPosX = new Vector2(character.Position.X + character.Speed.X, character.Position.Y);
                    if (!TryMove(nextPosX, character))
                    {
                        character.Speed = new Vector2(-character.Speed.X * 0.5f, character.Speed.Y);
                    }
                    Vector2 nextPosY = new Vector2(character.Position.X, character.Position.Y + character.Speed.Y);
                    if (!TryMove(nextPosY, character))
                    {
                        character.Speed = new Vector2(character.Speed.X, -character.Speed.Y * 0.5f);
                    }
                    character.Position -= character.Speed * 0.1f;
                }
                else
                {
                    character.Position = nextPos;
                }
            }
            else if (!IsCharWithinX(character))
            {
                character.Speed = new Vector2(-character.Speed.X * 0.5f, character.Speed.Y);
            }
            else if (!IsCharWithinY(character))
            {
                character.Speed = new Vector2(character.Speed.X, -character.Speed.Y * 0.5f);
            }
        }

        public void MoveWithKeys(Character character)
        {
            var direction = character.InputReader.ReadInput();
            float acceleration = 0.3f;
            float friction = 0.7f;

            if (direction != Vector2.Zero)
            {
                character.Speed += direction * acceleration;
            }
            else
            {
                character.Speed *= friction;
            }

            float maxSpeed = character.MaxSpeed;
            character.Speed = Limit(character.Speed, maxSpeed);

            Vector2 nextPos = character.Position + character.Speed;

            if (IsCharWithinX(character) && IsCharWithinY(character))
            {
                if (TryMove(nextPos, character))
                {
                    character.Position = nextPos;
                }
                else
                {
                    character.Speed *= friction;
                }
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

            if (distance < 20)
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

            character.Speed = Limit(character.Speed, character.MaxSpeed);

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
        /// Checks if a next position will collide with any obstacles of the character
        /// </summary>
        /// <param name="targetPos"></param>
        /// <param name="character"></param>
        /// <returns>True if possible, return false if collision</returns>
        private bool TryMove(Vector2 targetPos, Character character)
        {
            var tempCollisionBox = new CollisionBox(targetPos, character.ColBox.Size);
            if (character.obstacles != null)
            {
                foreach (var obstacle in character.obstacles)
                {
                    if (tempCollisionBox.IsCollidingWith(obstacle.ColBox))
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        private bool IsCharWithinX(Character character)
        {
            return character.Position.X + character.Speed.X >= 0 - character.ColBox.Size.X / 2 && character.Position.X + character.Speed.X <= Globals.MapSizeX - 1.5 * character.ColBox.Size.X;

            // return character.Position.X + character.Speed.X <= Globals.mapSizeX - character.ColBox.Size.X || character.Position.X + character.Speed.X >= 0;
        }
        private bool IsCharWithinY(Character character)
        {
            return character.Position.Y + character.Speed.Y >= 0 - character.ColBox.Size.Y / 2 && character.Position.Y + character.Speed.Y <= Globals.MapSizeY - character.ColBox.Size.Y;

            //  return character.Position.Y + character.Speed.Y <= Globals.mapSizeY - character.ColBox.Size.Y || character.Position.Y + character.Speed.Y >= 0;
        }
    }
}
