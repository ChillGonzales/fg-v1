using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fg_v1
{
    public interface IEntity
    {
        void Move(Vector2 amount);
        void Update(GameTime time, GamePadState gamepadState, KeyboardState keyboardState);
        void Draw(SpriteBatch batch);
    }
}
