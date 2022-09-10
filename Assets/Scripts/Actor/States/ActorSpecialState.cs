using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class ActorSpecialState : ActorState
    {
        public ActorSpecialState(ActorStatemachine statemachine, string animBoolName) : base(statemachine, animBoolName)
        {
        }
    }
}
