using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Dungeon.Components.Player
{
    public class PlayerController : Component
    {
        public float Speed { get; set; }

        public PlayerController(float speed)
        {
            Speed = speed;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Movement();
        }

        private void Movement()
        {
            // Get the Keyboard/Input State
            KeyboardState state = Keyboard.GetState();

            // Create a movement vector to add later
            Vector2 movement = Vector2.Zero;

            // Set movement based on key input
            if (state.IsKeyDown(Keys.Right))
                movement.X += Speed;
            if (state.IsKeyDown(Keys.Left))
                movement.X -= Speed;
            if (state.IsKeyDown(Keys.Up))
                movement.Y -= Speed;
            if (state.IsKeyDown(Keys.Down))
                movement.Y += Speed;

            GameObject.Transform.Position += movement;
        }
    }
}