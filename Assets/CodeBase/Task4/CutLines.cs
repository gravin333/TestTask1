using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Task4
{
    public class CutLines
    {
        public async Task<Line[]> SeparatingLines(Line mainLine, Line[] lines)
        {
            Task<Line[]> task = Task<Line[]>.Factory.StartNew(() =>
            {
                List<Line> newLines = new List<Line>();

                foreach (var line in lines)
                {
                    Vector3 intersectionPoint = GetIntersectionPoint(mainLine, line);
                    if (IntersectionPointIsCorrect(intersectionPoint))
                    {
                        newLines.Add(new Line() {PositionStart = line.PositionStart, PositionEnd = intersectionPoint});
                        newLines.Add(new Line() {PositionStart = intersectionPoint, PositionEnd = line.PositionEnd});
                    }
                    else
                    {
                        newLines.Add(line);
                    }
                }

                newLines.Add(mainLine);
                return newLines.ToArray();
            });
            return await task;
        }

        private Vector3 GetIntersectionPoint(Line current, Line testLine)
        {
            Vector3 aDiff = current.PositionEnd - current.PositionStart;
            Vector3 bDiff = testLine.PositionEnd - testLine.PositionStart;
            if (LineIntersection(out var intersection, current.PositionStart, aDiff, testLine.PositionStart, bDiff))
            {
                float aSqrMagnitude = aDiff.sqrMagnitude;
                float bSqrMagnitude = bDiff.sqrMagnitude;

                if ((intersection - current.PositionStart).sqrMagnitude <= aSqrMagnitude
                    && (intersection - current.PositionEnd).sqrMagnitude <= aSqrMagnitude
                    && (intersection - testLine.PositionStart).sqrMagnitude <= bSqrMagnitude
                    && (intersection - testLine.PositionEnd).sqrMagnitude <= bSqrMagnitude)
                {
                    return intersection;
                }
            }

            //negative infinity as a wrong intersection
            return Vector3.negativeInfinity;
        }


        private bool LineIntersection(out Vector3 intersection, Vector3 linePoint1,
            Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
        {
            Vector3 lineVec3 = linePoint2 - linePoint1;
            Vector3 crossVec1AND2 = Vector3.Cross(lineVec1, lineVec2);
            Vector3 crossVec3AND2 = Vector3.Cross(lineVec3, lineVec2);

            float planarFactor = Vector3.Dot(lineVec3, crossVec1AND2);

            if (Mathf.Abs(planarFactor) < 0.0001f
                && crossVec1AND2.sqrMagnitude > 0.0001f)
            {
                float s = Vector3.Dot(crossVec3AND2, crossVec1AND2) / crossVec1AND2.sqrMagnitude;
                intersection = linePoint1 + (lineVec1 * s);
                return true;
            }
            else
            {
                intersection = Vector3.zero;
                return false;
            }
        }

        private static bool IntersectionPointIsCorrect(Vector3 intersectionPoint)
        {
            return !intersectionPoint.Equals(Vector3.negativeInfinity);
        }
    }
}