﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using OuroborosEngine.Managers.BehaviourManager.EStateMachine.States;

namespace WaxenV_1.Managers.BehaviourManager.WStateMachine.States
{
    class WalkRight : PlayerState
    {
        ///////////////////////////////////////  CONSTRUCTOR  /////////////////////////////////////


        // USE: the base constructor
        public WalkRight(ContentManager content) : base(content)//, GraphicsDevice gd) : base(content)//, gd)
        {

        }


        ///////////////////////////////////////  UPDATE AND DRAW  /////////////////////////////////////


        /// <summary>METHOD: set the update behaviour for this state</summary>
        /// <param name="dt">the game loops time</param>
        /// <param name="content">grabs the content manager from the game scene</param>
        /// <param name="position">the positionof the the animation in the scene</param>
        public override void Update(GameTime dT, ContentManager content, Vector2 position)
        {
            // DECLARE: a keyboard state that recognises key input
            KeyboardState keystate = keystate = Keyboard.GetState();
            // IF: the right key is down
            if (keystate.IsKeyDown(Keys.D))
            {
                // ANIMATE: the sprite for walking right
                animMgr.Animate(dT, content, "walkright",4,48,40,70);
                // PLAY: the sound for walking
                soundmanager.Play("walking3", content);
            }
            else
            {
                // SET: the current animation to the first one in the list
                animMgr.currentAnim = new Rectangle(0, 0, 40, 70);
                // STOP: the sound effect
                soundmanager.Stop();
            }

            // CHANGE: the position of the texture in the relation to the player/entity
            animMgr.animPos = new Rectangle((int)position.X, (int)position.Y, 40, 70);
            
        }

        /// <summary>METHOD: draw the animation for this state</summary>
        /// <param name="spriteBatch">uses the Spritebatch.Draw() method</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            // DRAW: the current animation sprite
            spriteBatch.Draw(animMgr.currentSprite, animMgr.animPos, animMgr.currentAnim, Color.AntiqueWhite);
        }

    }
}