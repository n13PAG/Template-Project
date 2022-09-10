using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class ActorState
    {
        protected ActorStatemachine stateMachine;
        protected ActorCore actorCore;
        protected float startTime { get; private set; }
        protected float duration { get; private set; }
        protected float unscaledDuration { get; private set; }
        private string animBoolName;
        protected bool isAnimationFinished;
          
        public ActorState(ActorStatemachine statemachine, string animBoolName)
        {
            this.stateMachine = statemachine;
            this.animBoolName = animBoolName;
        }


        public virtual void Enter()
        {
            StateChecks();
            startTime = Time.time;
            duration = 0;
            isAnimationFinished = false;

            // Start Animation Here
            // ------------------------
        }

        public virtual void Exit() 
        {
            // End Animation Here
            // ------------------------
        }

        public virtual void LogicUpdate()
        {
            // Called every frame
            duration += Time.deltaTime;
            unscaledDuration += Time.unscaledDeltaTime;

            StateChecks();
        }


        public virtual void PhyscisUpdate()
        {
            // Called every fixed update
        }

        public virtual void StateChecks() { }

        public virtual void AnimationTrigger() { }
        public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
    }
}
