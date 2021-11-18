using CodeBase.AssetManagement;
using CodeBase.Factories;
using CodeBase.SceneManagement;
using CodeBase.UI.Menu;
using UnityEngine;

namespace CodeBase.GameStates
{
    public class LoadTask2State : IBaseState
    {
        private readonly IUIFactory _uiFactory;
        private readonly ISceneLoader _sceneLoader;
        private readonly GameStateMachine _gameStateMachine;

        public LoadTask2State(GameStateMachine gameStateMachine, ISceneLoader sceneLoader, IUIFactory uiFactory)
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
            _sceneLoader.LoadScene(SceneAssetPath.Task2,OnLoadTask2);
        }

        private async void OnLoadTask2()
        {
            GameObject beckMenuButton = await _uiFactory.CreateBeckMenuButton();
            beckMenuButton.GetComponent<MenuButton>().Construct(_gameStateMachine);
        }
    }
}