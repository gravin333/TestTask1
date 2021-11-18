using CodeBase.AssetManagement;
using CodeBase.Factories;
using CodeBase.SceneManagement;
using CodeBase.UI.Menu;
using UnityEngine;

namespace CodeBase.GameStates
{
    public class LoadTask1State : IBaseState
    {
        private GameStateMachine _gameStateMachine;
        private ISceneLoader _sceneLoader;
        private IUIFactory _uiFactory;

        public LoadTask1State(GameStateMachine gameStateMachine, ISceneLoader sceneLoader, IUIFactory uiFactory)
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
            _sceneLoader.LoadScene(SceneAssetPath.Task1,OnLoadTask1);
        }

        private async void OnLoadTask1()
        {
            GameObject beckMenuButton = await _uiFactory.CreateBeckMenuButton();
            beckMenuButton.GetComponent<MenuButton>().Construct(_gameStateMachine);
        }
    }
}