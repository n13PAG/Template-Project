using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class ActorStatemachine
    {
        public ActorState CurrentState { get; private set; }
        public void Initialize(ActorState startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(ActorState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
