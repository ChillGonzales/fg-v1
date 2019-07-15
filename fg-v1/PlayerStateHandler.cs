using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fg_v1
{
    public static class PlayerStateHandler
    {
        private static Vector2 _up = new Vector2(0, -100);
        private static Vector2 _right = new Vector2(10, 0);
        private static Vector2 _down = new Vector2(0, 10);
        private static Vector2 _left = new Vector2(-10, 0);
        private static Vector2 _gravity = new Vector2(0, 0.5f);
        private const int _floorY = 300;

        public static void Handle(AvatarState state)
        {
            if (state.MovementState == MovementState.Lag)
            {
                state.MovementState = MovementState.Idle;
                return;
            }
            state.Position += state.KeyboardState.GetPressedKeys().Aggregate(Vector2.Zero, (acc, cur) =>
            {
                if (cur == Keys.W && state.Position.Y == _floorY)
                    acc += _up;
                else if (cur == Keys.A)
                    acc += _left;
                else if (cur == Keys.S)
                    acc += _down;
                else if (cur == Keys.D)
                    acc += _right;
                return acc;
            });

            state.Position += _gravity * state.GameTime.ElapsedGameTime.Milliseconds;
            state.Position = state.Position.Ceiling(300, _floorY);
        }
    }
    public static class VectorUtility
    {
        public static Vector2 Floor(this Vector2 input, int x_floor, int y_floor)
        {
            if (input.X < x_floor)
                input.X = x_floor;
            if (input.Y < y_floor)
                input.Y = y_floor;
            return input;
        }
        public static Vector2 Ceiling(this Vector2 input, int x_ceil, int y_ceil)
        {
            if (input.X > x_ceil)
                input.X = x_ceil;
            if (input.Y > y_ceil)
                input.Y = y_ceil;
            return input;
        }
    }
}
