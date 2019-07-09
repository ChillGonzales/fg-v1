using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fg_v1
{
    public class Avatar : IEntity
    {
        private readonly Texture2D _texture;
        private double _updateTimer;
        private Vector2 _position;
        private readonly Action<GameTime> _updateLogic;

        public Avatar(Texture2D texture, Action<GameTime> updateLogic, Vector2? initialPosition = null)
        {
            _texture = texture;
            _position = initialPosition ?? Vector2.Zero;
            _updateLogic = updateLogic;
        }
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(_texture, _position, Color.White);
        }

        public void Move(Vector2 amount)
        {
            this._position += amount;
        }

        public void Update(GameTime time)
        {
            if (CheckUpdateTime(time))
            {
                _updateLogic(time);
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
            else { return false; }
        }

    }
}
