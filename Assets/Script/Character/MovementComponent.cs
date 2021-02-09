using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

namespace Character
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float WalkSpeed;
        [SerializeField] private float RunSpeed;
        [SerializeField] private float JumpForce;
        

        //Comp
        PlayerController PlayerController;
        Animator PlayerAnimator;
        Rigidbody PlayerRigidbody;
        NavMeshAgent PlayerNavMesh;

        Vector2 InputVector = Vector2.zero;
        Vector3 MoveDirection = Vector3.zero;

        //GameInputActions InputActions;

        //Animator Hashes
        readonly int MovementXHash = Animator.StringToHash("MovementX");
        readonly int MovementZHash = Animator.StringToHash("MovementZ");
        readonly int IsRunningHash = Animator.StringToHash("IsRunning");
        readonly int IsJumpingHash = Animator.StringToHash("IsJumping");

        private void Awake()
        {
            //InputActions = new GameInputActions();
            PlayerController = GetComponent<PlayerController>();
            PlayerAnimator = GetComponent<Animator>();
            PlayerRigidbody = GetComponent<Rigidbody>();
            PlayerNavMesh = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            Debug.Log("MovementComponent Start");
        }

        private void Update()
        {
            //If we are jumping, return
            if (PlayerController.IsJumping) return;

            //If we don't have any input vector, return
            if (!(InputVector.magnitude > 0))
            {
                MoveDirection = Vector3.zero;
            }
            
            //Calculate move direction
            MoveDirection = transform.forward * InputVector.y + transform.right * InputVector.x;

            //If we are runnig, use runspeed otherwise use walkspeed
            float currentSpeed = PlayerController.IsRunning ? RunSpeed : WalkSpeed;

            Vector3 movementDirection = MoveDirection * (currentSpeed * Time.deltaTime);

            //Give direction
            PlayerNavMesh.Move(movementDirection); 

            //transform.position += movementDirection;
        }

        public void OnMovement(InputValue value)
        {
            //Debug.Log(value.Get());
            InputVector = value.Get<Vector2>();

            PlayerAnimator.SetFloat(MovementXHash, InputVector.x);
            PlayerAnimator.SetFloat(MovementZHash, InputVector.y);
        }

        public void OnRun(InputValue button)
        {
            //Debug.Log(pressed.Get<bool>());
            //Debug.Log(pressed.isPressed);

            PlayerController.IsRunning = button.isPressed;
            PlayerAnimator.SetBool(IsRunningHash, button.isPressed);
        }

        public void OnJump(InputValue button)
        {
            if(PlayerController.IsJumping)
            {
                return;
            }

            PlayerController.IsJumping = true;
            PlayerAnimator.SetBool(IsJumpingHash, true);

            //Disable navmesh
            // PlayerNavMesh.isStopped = true;
            PlayerNavMesh.velocity = Vector3.zero;
            PlayerNavMesh.Move(Vector3.zero);
            PlayerNavMesh.enabled = false;
            

            Invoke(nameof(Jump), 0.1f);            
        }

        public void Jump()
        {
            PlayerRigidbody.AddForce((transform.up + MoveDirection) * JumpForce, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Ground") && !PlayerController.IsJumping) return;

            Debug.Log("Gounrded");
            //Enable navmesh again
            PlayerNavMesh.enabled = true;
            //PlayerNavMesh.isStopped = false;

            PlayerController.IsJumping = false;
            PlayerAnimator.SetBool(IsJumpingHash, false);
        }


        private void MovementPerformed(InputAction.CallbackContext obj)
        {
            // Debug.Log(obj.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            // InputActions.Enable();
            //InputActions.ThirdPerson.Movement.performed += MovementPerformed;
        }


        private void OnDisable()
        {
            //InputActions.ThirdPerson.Movement.performed -= MovementPerformed;
            //InputActions.Disable();
        }
    }
}