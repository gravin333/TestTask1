using System;
using UnityEngine;

namespace CodeBase.Task3.Brick
{
    public class BrickMove : MonoBehaviour, IBrick
    {
        public float shiftSpeed = 40f;

        private Camera _camera;
        private float _distance;
        private Rigidbody _rb;

        private void Awake()
        {
            _camera = Camera.main;
            GetDistance();
            _rb = GetComponent<Rigidbody>();
        }

        private void GetDistance()
        {
            _distance = Vector3.Distance(_camera.transform.position, transform.position);
        }

        private void Update()
        {
            SetBrickPosition();
        }

        private void SetBrickPosition()
        {
            Vector3 position =
                _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance));
            Vector3 direction = position - transform.position;
            _rb.AddForce(direction * shiftSpeed);
        }
    }
}