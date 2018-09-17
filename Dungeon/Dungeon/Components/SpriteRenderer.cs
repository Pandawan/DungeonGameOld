using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon.Components
{
    public class SpriteRenderer : Component
    {
        public Texture2D Texture { get; set; }
        
        public Color Color { get; set; }
        
        public Vector2 Pivot { get; set; }

        public SpriteEffects Effects { get; set; }

        public SpriteRenderer(string textureName)
        {
            // Load the texture from the texture name
            Texture = World.Content.Load<Texture2D>(textureName);

            // Set default values
            Color = Color.White;
            Pivot = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
            Effects = SpriteEffects.None;
        }

        public SpriteRenderer(string textureName, Color color, Vector2 pivot, SpriteEffects effects)
        {
            // Load the texture from the texture name
            Texture = World.Content.Load<Texture2D>(textureName);

            Color = color;
            Pivot = pivot;
            Effects = effects;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Make sure the Texture isn't null
            if (Texture != null)
            {
                spriteBatch.Draw(Texture, GameObject.Transform.Position, Texture.Bounds, Color,
                    GameObject.Transform.Rotation, Pivot, GameObject.Transform.Scale,
                    Effects, 1);
            }
        }

        public Vector2 GetTextureSize()
        {
            return new Vector2(Texture.Width, Texture.Height);
        }
    }
}