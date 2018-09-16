using System;
using Microsoft.Xna.Framework;

namespace Dungeon.Components
{
    public class Transform : Component
    {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; }

        public Transform(Vector2 position)
        {
            Position = position;
            Rotation = 0;
            Scale = Vector2.One;
        }

        public Transform(Vector2 position, float rotation)
        {
            Position = position;
            Rotation = rotation;
            Scale = Vector2.One;
        }

        public Transform(Vector2 position, float rotation, Vector2 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }

        #region Modifiers

        public void Move(Vector2 offset)
        {
            GameObject.Transform.Position = Vector2.Add(GameObject.Transform.Position, offset);
        }

        /// <summary>
        /// Apply the given angle to the current rotation. (Not from Origin).
        /// </summary>
        /// <param name="angle">The angle to apply (in Radians)</param>
        public void Rotate(float angle)
        {
            Rotate(angle, RotationMode.Radians);
        }

        /// <summary>
        /// Apply the given angle to the current rotation. (Not from Origin).
        /// </summary>
        /// <param name="angle">The angle to apply</param>
        /// <param name="mode">Whether the value is in Degrees or Radians</param>
        public void Rotate(float angle, RotationMode mode)
        {
            switch (mode)
            {
                // If Degrees, Convert with Angle * Pi / 180
                case RotationMode.Degrees:
                    Rotation += angle * (float) Math.PI / 180;
                    break;
                case RotationMode.Radians:
                    Rotation += angle;
                    break;
            }
        }

        #endregion
    }

    public enum RotationMode
    {
        Radians,
        Degrees
    }
}