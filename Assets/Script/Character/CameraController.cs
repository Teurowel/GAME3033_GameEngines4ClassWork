using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GameObject FollowTarget;
        [SerializeField] private float RotationSpeed = 1;
        [SerializeField] private float HorizontalDamping = 1;

        private Transform FollowTargetTransform;

        private Vector2 PreviousMouseInput;

        // Start is called before the first frame update
        void Start()
        {
            FollowTargetTransform = FollowTarget.transform;

            PreviousMouseInput = Vector2.zero;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnLook(InputValue delta)
        {
            Vector2 aimValue = delta.Get<Vector2>();

            //Make rotation and apply that to follow target tranform
            FollowTargetTransform.rotation *= Quaternion.AngleAxis(
                Mathf.Lerp(PreviousMouseInput.x, aimValue.x, 1f / HorizontalDamping) * RotationSpeed, transform.up);

            //Give follow target's rotation to player's rotation
            transform.rotation = Quaternion.Euler(0, FollowTargetTransform.rotation.eulerAngles.y, 0);

            //Reset follow target's rotation to zero
            FollowTargetTransform.localEulerAngles = Vector3.zero;

            PreviousMouseInput = aimValue;
        }
    }
}