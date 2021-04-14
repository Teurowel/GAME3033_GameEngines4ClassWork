using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Health_System;

[RequireComponent(typeof(ZombieComponent))]
public class ZombieHealthComponent : HealthComponent
{
    ZombieStateMachine ZombieStateMachine;

    private void Awake()
    {
        ZombieStateMachine = GetComponent<ZombieStateMachine>();
    }

    public override void Destroy()
    {
        base.Destroy();
        ZombieStateMachine.ChangeState(ZombieStateType.Dead);
        gameObject.GetComponent<Collider>().enabled = false; //when die, disable collider
    }
}
