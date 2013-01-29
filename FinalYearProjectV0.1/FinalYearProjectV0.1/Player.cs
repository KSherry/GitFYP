using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FinalYearProjectV0._1
{
    class Player : Entity
    {
        public Vector2 acceleration;
        public int capacity;
        public int maxCapacity;

        float rotationSpeed;
        int currentWeapon;

        public override void Initialize()
        {
            base.Initialize();

            _pos.X = 100;
            _pos.Y = 100;
            _maxSpeed = 100.0f;
            _health = 100.0f;
            _shield = 100.0f;
            //_mass = 10.0f;

            capacity = 0;
            maxCapacity = 15;
            rotationSpeed = 5.0f;

            currentWeapon = 0;
        }

        public override void LoadContent()
        {
            base.LoadContent();

            _sprite = Game1.Instance.Content.Load<Texture2D>("PlayerShip");
        }

        public override void Update(GameTime gameTime)
        {
            float timeDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);

            _look.X = (float)Math.Sin(_rotation);
            _look.Y = -(float)Math.Cos(_rotation);

            if (_velocity.Length() > _maxSpeed)
            {
                _velocity.Normalize();
                _velocity *= _maxSpeed;
            }

            _pos += _velocity * timeDelta;

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Up))
                _velocity += _look * _maxSpeed * timeDelta;
            
            if (keyState.IsKeyDown(Keys.Left))
                _rotation -= rotationSpeed * timeDelta;

            if (keyState.IsKeyDown(Keys.Right))
                _rotation += rotationSpeed * timeDelta;

            if (keyState.IsKeyDown(Keys.Space))
            {                
                _shield--;

                if (_shield <= 0)
                    _health--;

                _health = (int)MathHelper.Clamp(_health, 0, 100);
                _shield = (int)MathHelper.Clamp(_shield, 0, 100);
            }

            if (keyState.IsKeyDown(Keys.RightShift))
            {
                capacity++;

                capacity = (int)MathHelper.Clamp(capacity, 0, 15);
            } 
            if (keyState.IsKeyDown(Keys.LeftShift))
            {
                capacity--;

                capacity = (int)MathHelper.Clamp(capacity, 0, 15);
            }
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Draw(gameTime);

            Vector2 origin;
            origin.X = _sprite.Width / 2;
            origin.Y = _sprite.Height / 2;

            Game1.Instance.spriteBatch.Draw(_sprite, _pos, null, Color.White, _rotation, origin, 1.0f, SpriteEffects.None, 1);
        }

    }
}
