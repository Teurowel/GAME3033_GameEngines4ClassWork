using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public ZombieStates CurrentState { get; private set; }
    protected Dictionary<ZombieStateType, ZombieStates> States; //dictionary for all states
    private bool Running;

    private void Awake()
    {
        States = new Dictionary<ZombieStateType, ZombieStates>();
    }

    public void Initialize(ZombieStateType startingState)
    {
        //Check if states dictionary have this key
        if(States.ContainsKey(startingState))
        {
            ChangeState(startingState);
        }
        else if(States.ContainsKey(ZombieStateType.Idle))
        {
            ChangeState(ZombieStateType.Idle);
        }
    }

    public void AddState(ZombieStateType stateName, ZombieStates state)
    {
        //If states dictionary already have this key, return
        if(States.ContainsKey(stateName))
        {
            return;
        }

        States.Add(stateName, state);
    }

    public void RemoveState(ZombieStateType stateName)
    {
        //If states dictionary doesn't have this key, return
        if (States.ContainsKey(stateName) == false)
        {
            return;
        }

        States.Remove(stateName);
    }

    public void ChangeState(ZombieStateType nextState)
    {
        //If we are running state machine
        if(Running)
        {
            //Stop first
            StopRunningState();
        }

        //If states dictionary doesn't have this key, return
        if (States.ContainsKey(nextState) == false)
        {
            return;
        }

        //change current state
        CurrentState = States[nextState];
        CurrentState.Start();

        //IF current state have update interval
        if(CurrentState.UpdateInterval > 0)
        {
            InvokeRepeating(nameof(IntervalUpdate), 0.0f, CurrentState.UpdateInterval);
        }

        //Set runnign true
        Running = true;
    }

    private void StopRunningState()
    {
        //Set running false
        Running = false;

        //Exit current state
        CurrentState.Exit();

        //Cancle invoke of interval update function
        CancelInvoke(nameof(IntervalUpdate));
    }

    private void IntervalUpdate()
    {
        if(Running)
        {
            CurrentState.IntervalUpdate();
        }
    }

    private void Update()
    {
        if (Running)
        {
            CurrentState.Update();
        }
    }

    private void FixedUpdate()
    {
        if (Running)
        {
            CurrentState.FixedUpdate();
        }
    }
}
