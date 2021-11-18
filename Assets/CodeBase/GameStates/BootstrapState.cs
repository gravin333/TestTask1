using CodeBase.AssetManagement;
using CodeBase.Factories;
using CodeBase.SceneManagement;
using CodeBase.Services;

namespace CodeBase.GameStates
{
    internal class BootstrapState : IBaseState
    {
        private GameStateMachine _gameStateMachine;
        private AllServices _allServices;
        private ISceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, AllServices allServices, ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _allServices = allServices;
            _gameStateMachine = gameStateMachine;
            
            RegistrationServices();
        }

        private void RegistrationServices()
        {
            _allServices.Register<IAsset>(new AssetProvider());
            _allServices.Register(_sceneLoader);
            _allServices.Register<IUIFactory>(new UIFactory(_allServices.Single<IAsset>()));
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _gameStateMachine.Enter<LoadMenuState>();
        }
    }
}