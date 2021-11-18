using CodeBase.GameStates;
using CodeBase.SceneManagement;
using CodeBase.Services;

namespace CodeBase
{
    public class Game
    {
        public readonly GameStateMachine GameStateMachine;

        public Game()
        {
            GameStateMachine = new GameStateMachine(AllServices.Container,new SceneLoader());
        }
    }
}