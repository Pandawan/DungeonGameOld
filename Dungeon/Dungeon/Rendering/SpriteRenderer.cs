using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon.Rendering
{
    /// <summary>
    /// Allows a GameObject to render as a Texture/Sprite
    /// </summary>
    public class SpriteRenderer : Component
    {
        /// <summary>
        /// The texture to render
        /// </summary>
        public Texture2D Texture { get; set; }

        /// <summary>
        /// The color to apply to the filter. White is default
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// The pivot point of the texture, where the position should start
        /// </summary>
        public Vector2 Pivot { get; set; }

        /// <summary>
        /// Effects to apply on the sprite such as Flipping
        /// </summary>
        public SpriteEffects Effects { get; set; }

        /// <summary>
        /// Layer at which to render the sprite. (Internally a float between 0 and 1, where 1 is front).
        /// </summary>
        public SortingLayer SortingLayer { get; set; }

        // TODO: Add some sort of sorting order
        public SpriteRenderer(string textureName)
        {
            // Load the texture from the texture name
            Texture = Utilities.Content.Load<Texture2D>(textureName);

            // Set default values
            Color = Color.White;
            Pivot = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
            Effects = SpriteEffects.None;
            SortingLayer = SortingLayerUtilities.DefaultLayer();
        }

        public SpriteRenderer(string textureName, Color color)
        {
            // Load the texture from the texture name
            Texture = Utilities.Content.Load<Texture2D>(textureName);
            Color = color;

            // Set default values
            Pivot = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
            Effects = SpriteEffects.None;
            SortingLayer = SortingLayerUtilities.DefaultLayer();
        }

        public SpriteRenderer(string textureName, Color color, Vector2 pivot, SpriteEffects effects,
            SortingLayer sortingLayer)
        {
            // Load the texture from the texture name
            Texture = Utilities.Content.Load<Texture2D>(textureName);
            Color = color;
            Pivot = pivot;
            Effects = effects;
            SortingLayer = sortingLayer;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Make sure the Texture isn't null
            if (Texture != null)
            {
                // Draw the object using the SpriteRenderer's options
                spriteBatch.Draw(Texture, GameObject.Transform.Position, Texture.Bounds, Color,
                    GameObject.Transform.Rotation, Pivot, GameObject.Transform.Scale,
                    Effects, SortingLayerUtilities.GetValue(SortingLayer));
            }
        }

        public Vector2 GetTextureSize()
        {
            return new Vector2(Texture.Width, Texture.Height);
        }
    }
}