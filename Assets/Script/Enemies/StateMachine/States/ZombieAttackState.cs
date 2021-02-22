using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : ZombieStates
{
    private GameObject FollowTarget;
    private float AttackRange = 2.0f;

    private static readonly int MovementZHash = Animator.StringToHash("MovementZ");
    private static readonly int IsAttackingHash = Animator.StringToHash("isAttacking");

    public ZombieAttackState(GameObject followTarget, ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {
        FollowTarget = followTarget;
        UpdateInterval = 2.0f;
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        OwnerZombie.ZombieNavMesh.isStopped = true;
        OwnerZombie.ZombieNavMesh.ResetPath();
        OwnerZombie.ZombieAnimator.SetFloat(MovementZHash, 0.0f);
        OwnerZombie.ZombieAnimator.SetBool(IsAttackingHash, true);
    }

    // Update is called once per frame
    public override void Update()
    {
        //Keep looking at target
        OwnerZombie.transform.LookAt(FollowTarget.transform.position, Vector3.up);

        //Calculate distance between target
        float distanceBetween = Vector3.Distance(OwnerZombie.transform.position, FollowTarget.transform.position);

        //If target is far than attack range, go back to follow
        if (distanceBetween >= AttackRange)
        {
            StateMachine.ChangeState(ZombieStateType.Follow);
        }

        //if zombie health < 0, die
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();

        //Add damage to target
    }

    public override void Exit()
    {
        base.Exit();

        OwnerZombie.ZombieAnimator.SetBool(IsAttackingHash, false);
    }
}
