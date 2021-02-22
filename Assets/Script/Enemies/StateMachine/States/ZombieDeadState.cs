using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeadState : ZombieStates
{
    private static readonly int MovementZHash = Animator.StringToHash("MovementZ");
    private static readonly int IsDeadHash = Animator.StringToHash("isDead");

    public ZombieDeadState(ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {

    }

    public override void Start()
    {
        base.Start();

        OwnerZombie.ZombieNavMesh.isStopped = true;
        OwnerZombie.ZombieNavMesh.ResetPath();

        OwnerZombie.ZombieAnimator.SetFloat(MovementZHash, 0);
        OwnerZombie.ZombieAnimator.SetBool(IsDeadHash, true);
    }

    public override void Exit()
    {
        base.Exit();

        OwnerZombie.ZombieNavMesh.isStopped = true;

        OwnerZombie.ZombieAnimator.SetBool(IsDeadHash, false);
    }
}
