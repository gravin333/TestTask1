using UnityEngine;

namespace CodeBase.Task2
{
    public class RotateObject : MonoBehaviour
    {
        public float rotateSpeed = .5f;

        void Update()
        {
            transform.RotateAround(transform.position,Vector3.up, rotateSpeed);
        }
    }
}
