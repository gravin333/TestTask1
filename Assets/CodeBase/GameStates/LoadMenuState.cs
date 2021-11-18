
using CodeBase.AssetManagement;
using CodeBase.Factories;
using CodeBase.SceneManagement;
using CodeBase.UI.Menu;
using UnityEngine;

namespace CodeBase.GameStates
{
    public class LoadMenuState : IBaseState
    {
        private GameStateMachine _gameStateMachine;
        private ISceneLoader _sceneLoader;
        private IUIFactory _uiFactory;

        public LoadMenuState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader,IUIFactory uiFactory)
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
            _sceneLoader.LoadScene(SceneAssetPath.Menu,OnLoadedMenu);
        }

        private async void OnLoadedMenu()
        {
            GameObject menuWindow = await _uiFactory.CreateMenu();
            menuWindow.GetComponent<MenuWindow>().Construct(_gameStateMachine);
            
        }
    }
}