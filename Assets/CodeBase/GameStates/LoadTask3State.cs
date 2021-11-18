using CodeBase.AssetManagement;
using CodeBase.Factories;
using CodeBase.SceneManagement;
using CodeBase.UI.Menu;
using UnityEngine;

namespace CodeBase.GameStates
{
    public class LoadTask3State : IBaseState
    {
        private readonly IUIFactory _uiFactory;
        private readonly ISceneLoader _sceneLoader;
        private readonly GameStateMachine _gameStateMachine;

        public LoadTask3State(GameStateMachine gameStateMachine, ISceneLoader sceneLoader, IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
            _gameStateMachine = gameStateMachine;
        }
        public void Exit()
        {
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(SceneAssetPath.Task3,OnLoadTask3);
        }

        private async void OnLoadTask3()
        {
            GameObject beckMenuButton = await _uiFactory.CreateBeckMenuButton();
            beckMenuButton.GetComponent<MenuButton>().Construct(_gameStateMachine);
        }
    }
}