using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace OuroborosEngine.Interfaces
{
    public interface IState
    {
        ///////////////////////////////////////  UPDATE AND DRAW  /////////////////////////////////////
        void Update();
        void Update(GameTime dT, ContentManager content, Vector2 position);
        void Draw(SpriteBatch spriteBatch);

        // had to be added for the state change between the wax states, as they are defined a dictionary of IStates
        Boolean IsMelted { get; set; }
    }
}
