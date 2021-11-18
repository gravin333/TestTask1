using System;
using System.Collections.Generic;
using CodeBase.Factories;
using CodeBase.SceneManagement;
using CodeBase.Services;

namespace CodeBase.GameStates
{
    public class GameStateMachine
    {
        private Dictionary<Type, IBaseState> _states;
        private IExitableState activeState;

        public GameStateMachine(AllServices services, ISceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IBaseState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, services,sceneLoader),
                [typeof(LoadMenuState)] = new LoadMenuState(this,services.Single<ISceneLoader>(),services.Single<IUIFactory>()),
                [typeof(LoadTask1State)] = new LoadTask1State(this,services.Single<ISceneLoader>(),services.Single<IUIFactory>()),
                [typeof(LoadTask2State)] = new LoadTask2State(this,services.Single<ISceneLoader>(),services.Single<IUIFactory>()),
                [typeof(LoadTask3State)] = new LoadTask3State(this,services.Single<ISceneLoader>(),services.Single<IUIFactory>()),
            };
        }

        public void Enter<TState>() where TState : class, IBaseState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            activeState?.Exit();
            var state = GetState<TState>();
            activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}