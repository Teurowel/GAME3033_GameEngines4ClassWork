using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Health_System;

[RequireComponent(typeof(ZombieComponent))]
public class ZombieHealthComponent : HealthComponent
{
    StateMachine ZombieStateMachine;

    private void Awake()
    {
        ZombieStateMachine = GetComponent<StateMachine>();
    }

    public override void Destroy()
    {
        ZombieStateMachine.ChanceState(ZombieStateType.Dead);
    }
}
