using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon.Components
{
    public class SpriteRenderer : Component
    {
        public Texture2D Texture { get; set; }
        private ContentManager Content { get; set; }

        public SpriteRenderer(ContentManager content, string textureName)
        {
            Content = content;
            Texture = Content.Load<Texture2D>(textureName);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Make sure the Texture isn't null
            if (Texture != null)
            {
                spriteBatch.Draw(Texture, GameObject.Position, Color.White);
            }
        }
    }
}