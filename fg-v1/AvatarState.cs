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
    public class AvatarState
    {
        public Vector2 Position { get; set; }
        public MovementState MovementState { get; set; }
        public Texture2D Texture { get; set; }
        public GameTime GameTime { get; set; }
        public GamePadState GamepadState { get; set; }
        public KeyboardState KeyboardState { get; set; }
    }
    public enum MovementState
    {
        Idle,
        Lag
    }
}
