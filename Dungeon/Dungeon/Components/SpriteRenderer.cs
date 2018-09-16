using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon.Components
{
    public class SpriteRenderer : Component
    {
        public Texture2D Texture { get; set; }

        public SpriteRenderer(string textureName)
        {
            // Load the texture from the texture name
            Texture = World.Content.Load<Texture2D>(textureName);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Make sure the Texture isn't null
            if (Texture != null)
            {
                // TODO: If want to add Flipping Option, add SpriteEffects
                // TODO: Also add a Color option
                // TODO: Add Custom Pivot Point
                Vector2 pivotPoint = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
                spriteBatch.Draw(Texture, GameObject.Transform.Position, Texture.Bounds, Color.White,
                    GameObject.Transform.Rotation, pivotPoint, GameObject.Transform.Scale,
                    SpriteEffects.None, 1);
            }
        }

        public Vector2 GetTextureSize()
        {
            return new Vector2(Texture.Width, Texture.Height);
        }
    }
}