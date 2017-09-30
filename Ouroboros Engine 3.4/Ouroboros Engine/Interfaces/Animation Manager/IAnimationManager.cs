using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace OuroborosEngine.Interfaces
{
    interface IAnimationManager
    {
        ///////////////////////////////////////  ANIMATION  /////////////////////////////////////
        void Animate(GameTime gameTime, ContentManager content, string filename, int frameMax, int spriteLength, int spriteWidth, int spriteHeight);
    }
}
