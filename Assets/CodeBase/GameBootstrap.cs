using CodeBase.GameStates;
using UnityEngine;

namespace CodeBase
{
    public class GameBootstrap : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
            _game.GameStateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}