using System;
using CodeBase.Task3.Brick;
using UnityEngine;

namespace CodeBase.Task3.Ball
{
    public class MoveBall : MonoBehaviour, IBall
    {
        private const string BackWallTag = "BackWall";
        public float startVelocity = 3f;
        public float maxVelocityMagnitude = 10f;
        private float updateTime = 1f;
        private float forceValue = 2f;
        private Rigidbody _rigidbody;
        private MeshRenderer _meshRenderer;
        private float _ballRadius;
        private Vector3 _lastVelocity;
        private float _timeCounter;
        private bool _ballIsMove = false;

        public Action TouchBackWall;
        public Action TouchBrick;

        public void StartMoving()
        {
            _ballIsMove = true;
            SetStartSpeed();
            ResetTimer();
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.useGravity = false;
            GetBallRadius();
        }

        private void SetStartSpeed()
        {
            _rigidbody.velocity = new Vector3(1f, 0, 1f) * startVelocity;
        }

        private void ResetTimer()
        {
            _timeCounter = updateTime;
        }

        private void GetBallRadius()
        {
            _meshRenderer = _rigidbody.GetComponent<MeshRenderer>();
            _ballRadius = _meshRenderer.bounds.extents.x;
        }

        private void Update()
        {
            if (!_ballIsMove)
                return;

            _lastVelocity = _rigidbody.velocity;
            UpdateBallRotation();
            UpdateBallSpeed();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.GetComponent<IBrick>() != null)
            {
                var speed = _lastVelocity.magnitude;
                var direction = (transform.position - other.transform.position).normalized;
                _rigidbody.velocity = direction * Math.Max(speed, 0);
                TouchBrick?.Invoke();
            }
            else
            {
                var speed = _lastVelocity.magnitude;
                var direction = Vector3.Reflect(_lastVelocity.normalized, other.contacts[0].normal);
                _rigidbody.velocity = direction * Math.Max(speed, 0);
            }

            if (other.transform.CompareTag(BackWallTag))
            {
                TouchBackWall?.Invoke();
            }
        }

        private void UpdateBallSpeed()
        {
            if (_timeCounter <= 0)
            {
                _rigidbody.AddForce(_rigidbody.velocity * forceValue);
                _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, maxVelocityMagnitude);
                _timeCounter = updateTime;
            }
            else
            {
                _timeCounter -= Time.deltaTime;
            }
        }

        private void UpdateBallRotation()
        {
            Vector3 movement = _rigidbody.velocity * Time.deltaTime;
            float distance = movement.magnitude;

            float angle = distance * (180f / Mathf.PI) / _ballRadius;
            Vector3 rotationAxis =
                Vector3.Cross(Vector3.up, movement).normalized;
            _rigidbody.rotation =
                Quaternion.Euler(rotationAxis * angle) * _rigidbody.rotation;
        }
    }
}