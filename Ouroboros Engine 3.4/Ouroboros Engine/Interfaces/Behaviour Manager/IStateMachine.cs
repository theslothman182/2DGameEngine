using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace OuroborosEngine.Interfaces
{
    public interface IStateMachine
    {
        ///////////////////////////////////////  HANDLE STATES  /////////////////////////////////////
        void Add(string id, IState state);
        void Remove(string id);
        void Clear();
        void Change(string id);

        ///////////////////////////////////////  UPDATE AND DRAW  /////////////////////////////////////
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
