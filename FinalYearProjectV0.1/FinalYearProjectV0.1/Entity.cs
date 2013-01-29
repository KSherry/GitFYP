/***
 * Class Description:   An abstract class used as a base for anything that can be considered
 *                      an entity within the game.
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FinalYearProjectV0._1
{
    class Entity
    {
        public Vector2 _pos; // Declares a position vector for any entity
        public Vector2 _look; // Declared a look vector for any entity
        public Vector2 _velocity; // Declares a velocity vector for any enity
        public float _maxSpeed; // Declares a speed value for any entity
        public float _rotation; // Declares a roation value for any entity
        public float _health; // Declares a health value for any entity
        public float _shield; // Declared a shield value for any entity

        public Texture2D _sprite; // Declares a sprite variable for any entity

        public bool _alive; // Boolean to test whether entity is alive

        public bool Alive
        {
            get { return _alive; }
            set { _alive = value;}
        }

        public virtual void Initialize()
        {
            _pos = Vector2.Zero;
            _velocity = Vector2.Zero;

            _look.X = 0;
            _look.Y = -1;

            _maxSpeed= 0.0f;
            _health = 0.0f;
            _shield = 0.0f;
        }

        public virtual void LoadContent() { }
        public virtual void UnloadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime) { }
    }
}

