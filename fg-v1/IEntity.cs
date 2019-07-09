using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        void Update(GameTime time);
        void Draw(SpriteBatch batch);
    }
}
