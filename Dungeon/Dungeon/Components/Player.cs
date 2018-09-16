using Microsoft.Xna.Framework;

namespace Dungeon.Components
{
    public class Player : Component
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (GameObject.Transform.Position.X + GameObject.Transform.GetRelativeCenter().X > World.Graphics.GraphicsDevice.Viewport.Width)
            {
                GameObject.Transform.Position = GameObject.Transform.GetRelativeCenter();
            }

            GameObject.Transform.Move(new Vector2(1, 0));
        }
    }
}