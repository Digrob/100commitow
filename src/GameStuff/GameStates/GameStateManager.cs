using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.GameStuff.GameStates
{
    public class GameStateManager
    {
        private static GameStateManager _instance;
        private Stack<GameState> _states = new Stack<GameState>();

        public static GameStateManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameStateManager();
                return _instance;
            }
        }

        public void UnloadContent()
        {
            foreach (GameState state in _states)
            {
                state.UnloadContent();
            }
        }

        public GameState Peek()
        {
            return _states.Peek();
        }

        public void AddScreen(GameState state)
        {
            try
            {
                _states.Push(state);
                _states.Peek().Initialize();
                _states.Peek().LoadContent();
            }
            catch (Exception)
            { }
        }

        public void RemoveScreen()
        {
            if (_states.Count > 0)
            {
                try
                {
                    var screen = _states.Peek();
                    _states.Pop();
                }
                catch (Exception)
                { }
            }
        }

        public void ClearScreens()
        {
            while (_states.Count > 0)
            {
                _states.Pop();
            }
        }

        public void ChangeScreen(GameState screen)
        {
            try
            {
                ClearScreens();
                AddScreen(screen);
            }
            catch (Exception)
            { }
        }

        public void Update(GameTime gameTime)
        {
            try
            {
                if (_states.Count > 0)
                {
                    _states.Peek().Update(gameTime);
                }
            }
            catch (Exception)
            { }
        }
        public void Draw()
        {
            try
            {
                if (_states.Count > 0)
                {
                    _states.Peek().Draw();
                }
            }
            catch (Exception)
            { }
        }
    }
}
