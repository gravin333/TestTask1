using CodeBase.GameStates;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Menu
{
    public class MenuWindow : MonoBehaviour
    {
        public Button task1;
        public Button task2;
        public Button task3;

        private GameStateMachine _gameStateMachine;

        public void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            SubscribeButtons();
        }

        private void SubscribeButtons()
        {
            task1.onClick.AddListener(ClickTask1);
            task2.onClick.AddListener(ClickTask2);
            task3.onClick.AddListener(ClickTask3);
        }

        private void OnDestroy()
        {
            UnSubscribeButtons();
        }

        private void UnSubscribeButtons()
        {
            task1.onClick.RemoveListener(ClickTask1);
            task2.onClick.RemoveListener(ClickTask2);
            task3.onClick.RemoveListener(ClickTask3);
        }

        private void ClickTask4()
        {
        }

        private void ClickTask3()
        {
            _gameStateMachine.Enter<LoadTask3State>();
        }

        private void ClickTask2()
        {
            _gameStateMachine.Enter<LoadTask2State>();
        }

        private void ClickTask1()
        {
            _gameStateMachine.Enter<LoadTask1State>();
        }
    }
}