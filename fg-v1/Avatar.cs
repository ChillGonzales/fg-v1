using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace fg_v1
{
    public class Avatar : IEntity
    {
        private readonly Texture2D _texture;
        private double _updateTimer;
        private AvatarState _state;
        private readonly Action<AvatarState> _updateLogic;

        public Avatar(Texture2D texture, Action<AvatarState> updateLogic, Vector2? initialPosition = null)
        {
            _texture = texture;
            _updateLogic = updateLogic;
            _state = new AvatarState()
            {
                Texture = _texture,
                Position = initialPosition ?? Vector2.Zero
            };
        }
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(_texture, _state.Position, Color.White);
        }

        public void Move(Vector2 amount)
        {
            _state.Position += amount;
        }

        public void Update(GameTime time, GamePadState gamepadState, KeyboardState keyboardState)
        {
            if (CheckUpdateTime(time))
            {
                _state.GameTime = time;
                _state.GamepadState = gamepadState;
                _state.KeyboardState = keyboardState;
                _updateLogic(_state);
            }

        }
        private bool CheckUpdateTime(GameTime gameTime)
        {
            _updateTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (_updateTimer > Constants.UpdateFrequency)
            {
                _updateTimer -= Constants.UpdateFrequency;
                return true;
            }
            return false;
        }

    }
}
