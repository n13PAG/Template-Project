using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class ActorNormalState : ActorState
    {
        public ActorNormalState(ActorStatemachine statemachine, string animBoolName) : base(statemachine, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhyscisUpdate()
        {
            base.PhyscisUpdate();
        }

        public override void StateChecks()
        {
            base.StateChecks();
        }
        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();
        }

        public override void AnimationTrigger()
        {
            base.AnimationTrigger();
        }
    }
}
