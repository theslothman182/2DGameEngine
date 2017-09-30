using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OuroborosEngine.Managers.InputManager;
using WaxenV_1.Managers.BehaviourManager.WStateMachine;
using WaxenV_1.Managers.Entity_Manager;

namespace OuroborosEngine.Interfaces
{
    public interface IEntity
    {
        ///////////////////////////////////////  GETTERS AND SETTERS  /////////////////////////////////////
        string IdName { get; }
        int IdNumber { get; }
        Texture2D Image { get; set; }
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }

        ///////////////////////////////////////  SET ID  /////////////////////////////////////
        void setID(string idName, int idNumber);

        ///////////////////////////////////////  UPDATE AND DRAW  /////////////////////////////////////
        void Update();
        void Update(GameTime dt, ContentManager content);
        void Update(Vector2 playerPos);
        void Draw(SpriteBatch spriteBatch);

        ///////////////////////////////////////  INPUT EVENTS  /////////////////////////////////////
        void GetInput(Object source, myEventArgs args);
        void GetKeyUp(Object source, myEventArgs args);

        ///////////////////////////////////////  STATE MACHINE  /////////////////////////////////////
        void SetStateMachine(PlayerStateMachine machine);

    }
}
