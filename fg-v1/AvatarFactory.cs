using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fg_v1
{
    public class AvatarFactory
    {
        private readonly ContentManager _contentManager;

        public AvatarFactory(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }
        public IEntity GetAvatar(AvatarType avatarType)
        {
            switch (avatarType)
            {
                case AvatarType.Player:
                    return new Avatar(_contentManager.Load<Texture2D>(Constants.PlayerTextureName), x => PlayerStateHandler.Handle(x));
                default:
                    return null;
            }
        }
    }
    public enum AvatarType
    {
        Player = 0,
        NPC = 1
    }
}
