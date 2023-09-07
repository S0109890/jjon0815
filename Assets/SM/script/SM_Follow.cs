using Unity.Mathematics;
using UnityEngine;

namespace Klak.Motion
{
    [RequireComponent(typeof(Rigidbody))]
    [UnityEngine.AddComponentMenu("Klak/Procedural Motion/Smooth Rigidbody Follow")]
    public sealed class SM_Follow : MonoBehaviour
    {
        public enum Interpolator { Exponential, Spring, DampedSpring }

        public Transform target = null;
        public Interpolator interpolator = Interpolator.DampedSpring;
        [Range(0, 20)] public float positionSpeed = 2;
        [Range(0, 20)] public float rotationSpeed = 2;

        private Rigidbody _rb;
        private float3 _vp;
        private float4 _vr;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.useGravity = false; // 중력 영향 제거, 필요에 따라 제거 가능
        }

        private void FixedUpdate()
        {
            var dt = Time.fixedDeltaTime;

            Vector3 targetPositionVelocity = Vector3.zero;
            if (positionSpeed > 0)
            {
                var p = (float3)_rb.position;
                var pt = (float3)target.position;
                var sp = positionSpeed;

                if (interpolator == Interpolator.Exponential)
                {
                    targetPositionVelocity = (pt - p) * sp;
                }
                else if (interpolator == Interpolator.Spring)
                {
                    _vp *= math.exp((1 + sp * 0.5f) * -dt);
                    _vp += (pt - p) * (sp * 0.1f);
                    targetPositionVelocity = _vp;
                }
                else // interpolator == Interpolator.DampedSpring
                {
                    var n1 = _vp - (p - pt) * (sp * sp * dt);
                    var n2 = 1 + sp * dt;
                    _vp = n1 / (n2 * n2);
                    targetPositionVelocity = _vp;
                }
            }

            Vector3 targetAngularVelocity = Vector3.zero;
            if (rotationSpeed > 0)
            {
                var r = ((quaternion)_rb.rotation).value;
                var rt = ((quaternion)target.rotation).value;
                var sp = rotationSpeed;

                if (math.dot(r, rt) < 0) rt = -rt;

                if (interpolator == Interpolator.Exponential)
                {
                    Vector3 angleAxis = Quaternion.FromToRotation(_rb.transform.forward, target.forward).eulerAngles;
                    targetAngularVelocity = angleAxis * sp;
                }
                else if (interpolator == Interpolator.Spring)
                {
                    _vr *= math.exp((1 + sp * 0.5f) * -dt);
                    _vr += (rt - r) * (sp * 0.1f);
                    targetAngularVelocity = _vr.xyz;
                }
                else // interpolator == Interpolator.DampedSpring
                {
                    var n1 = _vr - (r - rt) * (sp * sp * dt);
                    var n2 = 1 + sp * dt;
                    _vr = n1 / (n2 * n2);
                    targetAngularVelocity = _vr.xyz;
                }
            }

            _rb.velocity = targetPositionVelocity;
            _rb.angularVelocity = targetAngularVelocity;
        }

        public void Snap()
        {
            if (positionSpeed > 0) _rb.position = target.position;
            if (rotationSpeed > 0) _rb.rotation = target.rotation;
        }
    }
}