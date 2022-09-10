using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class ActorCore : MonoBehaviour
    {
        public ActorStatemachine Statemachine { get; private set; }

        protected virtual void Awake()
        {
            Statemachine = new ActorStatemachine();
        }

        protected virtual void Start() {}

        protected virtual void Update()
        {
            Statemachine.CurrentState.LogicUpdate();
        }

        protected virtual void FixedUpdate()
        {
            Statemachine.CurrentState.PhyscisUpdate();
        }
    }
}
