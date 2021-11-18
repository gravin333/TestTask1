using System;
using System.Threading;
using UnityEngine;

namespace CodeBase.Task4
{
    public class CutSectionsTester : MonoBehaviour
    {
        private CutLines _cutLines;

        private void Awake()
        {
            _cutLines = new CutLines();
            //main line
            Line mainLine = new Line()
            {
                PositionStart = new Vector3(0, 0, 0),
                PositionEnd = new Vector3(4, 1, 0)
            };

            //true intersection to main line
            Line line1 = new Line()
            {
                PositionStart = new Vector3(1, 2, 0),
                PositionEnd = new Vector3(2, -2, 0)
            };

            //true intersection to main line
            Line line2 = new Line()
            {
                PositionStart = new Vector3(3, -2, 0),
                PositionEnd = new Vector3(3, 2, 0)
            };

            //false intersection to main line
            Line line3 = new Line()
            {
                PositionStart = new Vector3(-1, 1, 0),
                PositionEnd = new Vector3(-1, -1, 0)
            };

            Line[] lines = new[] {line1, line2, line3};
            
            ToDoSomething(mainLine, lines);
        }

        private async void ToDoSomething(Line mainLine, Line[] lines)
        {
            Line[] result = await _cutLines.SeparatingLines(mainLine, lines);
        }
    }
}