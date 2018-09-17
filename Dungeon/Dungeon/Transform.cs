using System;
using Dungeon.Rendering;
using Microsoft.Xna.Framework;

namespace Dungeon
{
    /// <summary>
    /// Controls a GameObject's Position, Rotation and Scale
    /// </summary>
    public class Transform : Component
    {
        /// <summary>
        /// Position of the GameObject in the world
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Rotation of the GameObject in the world.
        /// (Always in radians).
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        /// Scale of this GameObject.
        /// (Default is (1, 1)).
        /// </summary>
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

        #region Getters

        /// <summary>
        /// Get the center position of the texture relative to the texture's (0,0) corner.
        /// Returns Vector2.Zero if there is no SpriteRenderer
        /// </summary>
        /// <returns>Relative Center Position</returns>
        public Vector2 GetRelativeCenter()
        {
            // Texture is dependent on Sprite Renderer, make sure there is one, if not, Vector2.Zero
            return GameObject.GetComponent<SpriteRenderer>() != null
                // If there is one, get the Center of the texture with (TextureSize / 2), then scale it
                ? Vector2.Divide(GameObject.GetComponent<SpriteRenderer>().GetTextureSize(), 2) * Scale
                : Vector2.Zero;
        }

        #endregion

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
        /// <param name="mode">Whether the given angle value is in Degrees or Radians. Degrees will be converted to Radians.</param>
        public void Rotate(float angle, RotationMode mode)
        {
            switch (mode)
            {
                // If angle is in Degrees, convert it to Radians because Rotation is ALWAYS in Radians
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