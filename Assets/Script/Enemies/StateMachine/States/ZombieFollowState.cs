using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollowState : ZombieStates
{
    private readonly GameObject FollowTarget;
    private const float StopDistance = 2.0f;

    private static readonly int MovementZHash = Animator.StringToHash("MovementZ");

    public ZombieFollowState(GameObject followTarget, ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {
        FollowTarget = followTarget;
        UpdateInterval = 2.0f;
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        OwnerZombie.ZombieNavMesh.SetDestination(FollowTarget.transform.position); //set target's position
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();

        OwnerZombie.ZombieNavMesh.SetDestination(FollowTarget.transform.position); //set target's position
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        //SEt animator parameter
        OwnerZombie.ZombieAnimator.SetFloat(MovementZHash, OwnerZombie.ZombieNavMesh.velocity.normalized.z);

        float distance = Vector3.Distance(OwnerZombie.transform.position, FollowTarget.transform.position);
        Debug.Log(distance);

        //If we are close enough to target
        if (distance < StopDistance)
        {
            Debug.Log("Attack");
            StateMachine.ChangeState(ZombieStateType.Attack);
        }


    }
}
