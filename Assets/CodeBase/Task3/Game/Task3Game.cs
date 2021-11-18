using System;
using CodeBase.Task3.Ball;
using CodeBase.Task3.UI;
using UnityEngine;

namespace CodeBase.Task3.Game
{
    public class Task3Game : MonoBehaviour
    {
        public UICounter uiCounter;
        public MoveBall moveBall;

        private int _brickCounter = 0;
        private int _backWallCounter = 0;

        private void Awake()
        {
            moveBall.TouchBrick += IncBrickCounter;
            moveBall.TouchBackWall += IncBackWallCounter;
        }

        private void IncBrickCounter()
        {
            uiCounter.brickCounter.text = $"{_brickCounter += 1}";
        }
        
        private void IncBackWallCounter()
        {
            uiCounter.backWallCounter.text = $"{_backWallCounter += 1}";
        }

        private void OnDestroy()
        {
            moveBall.TouchBrick -= IncBrickCounter;
            moveBall.TouchBackWall -= IncBackWallCounter;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                moveBall.StartMoving();
            }
        }
    }
}
