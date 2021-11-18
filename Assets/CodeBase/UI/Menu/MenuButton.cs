using CodeBase.GameStates;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Menu
{
    public class MenuButton : MonoBehaviour
    {
        private Button _button;
        private GameStateMachine _gameStateMachine;

        public void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ReturnToMenu);
        }

        private void ReturnToMenu()
        {
            _gameStateMachine.Enter<LoadMenuState>();
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ReturnToMenu);
        }
    }
}
