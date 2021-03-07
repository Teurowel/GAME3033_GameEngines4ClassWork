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

        [SerializeField] private LayerMask JumpLayerMask; //jump layer mask(ground)
        [SerializeField] private float JumpThreshold = 0.1f; //jump distance threshhold
        [SerializeField] private float JumpLandingCheckDelay = 0.1f; //delay before start landing check
        [SerializeField] private float MoveDirectionBuffer = 2.0f;

        //Comp
        PlayerController PlayerController;
        Animator PlayerAnimator;
        Rigidbody PlayerRigidbody;
        //NavMeshAgent PlayerNavMesh;

        Vector2 InputVector = Vector2.zero;
        Vector3 MoveDirection = Vector3.zero;
        Vector3 NextPositionCheck = Vector3.zero;

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
            //PlayerNavMesh = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            //Debug.Log("MovementComponent Start");
        }

        private void Update()
        {
            //If we are jumping, return
            if (PlayerController.IsJumping) return;

            //Calculate move direction
            MoveDirection = transform.forward * InputVector.y + transform.right * InputVector.x;

            //If we are runnig, use runspeed otherwise use walkspeed
            float currentSpeed = PlayerController.IsRunning ? RunSpeed : WalkSpeed;    
            
            Vector3 movementDirection = MoveDirection * (currentSpeed * Time.deltaTime);

            NextPositionCheck = transform.position + MoveDirection * MoveDirectionBuffer;

            if(NavMesh.SamplePosition(NextPositionCheck, out NavMeshHit hit, 1f, NavMesh.AllAreas))
            {
                transform.position += movementDirection;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.collider.CompareTag("Ground") || !PlayerController.IsJumping)
            {
                return;
            }

            //Debug.Log("Gounrded");
            //Enable navmesh again
            //PlayerNavMesh.enabled = true;
            //PlayerNavMesh.isStopped = false;

            PlayerController.IsJumping = false;
            PlayerAnimator.SetBool(IsJumpingHash, false);
        }

        private void OnDrawGizmos()
        {
            if(NextPositionCheck != Vector3.zero)
            {
                Gizmos.DrawWireSphere(NextPositionCheck, 0.5f);
            }
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

            //stop nav mesh first, because nav mesh doesn't allow jump
            //PlayerNavMesh.isStopped = true;
            //PlayerNavMesh.enabled = false;

            PlayerController.IsJumping = button.isPressed; //set bool

            PlayerAnimator.SetBool(IsJumpingHash, button.isPressed); //player animation

            ////Disable navmesh
            //// PlayerNavMesh.isStopped = true;
            //PlayerNavMesh.velocity = Vector3.zero;
            //PlayerNavMesh.Move(Vector3.zero);
            //PlayerNavMesh.enabled = false;
            Debug.Log(MoveDirection);
            PlayerRigidbody.AddForce((transform.up + MoveDirection) * JumpForce, ForceMode.Impulse);
            //Invoke(nameof(Jump), 0.1f);            

            //Keep invoking landing check
            //InvokeRepeating(nameof(LandingCheck), JumpLandingCheckDelay, 0.1f);
        }

        private void LandingCheck()
        {
            //Do ray cast
            if(Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 100.0f, JumpLayerMask))
            {
                Debug.Log(hit.distance); 

                //If we jump higher than threshold
                if(!(hit.distance < JumpThreshold) || !PlayerController.IsJumping)
                {
                    return;
                }
                
                //enable navmesh again
                //PlayerNavMesh.enabled = true;
                //PlayerNavMesh.isStopped = false;

                //Set jump to flase
                PlayerController.IsJumping = false;
                PlayerAnimator.SetBool(IsJumpingHash, false);

                CancelInvoke(nameof(LandingCheck));
                
            }
        }

        public void Jump()
        {
            PlayerRigidbody.AddForce((transform.up + MoveDirection) * JumpForce, ForceMode.Impulse);
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