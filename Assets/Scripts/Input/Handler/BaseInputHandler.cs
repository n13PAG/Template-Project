using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public abstract class BaseInputHandler : ScriptableObject, IInputHandler
    {
        protected IInputHandler nextHandler;
        public IInputHandler GetNextHandler() { return nextHandler; }

        [Header("Input Provider")]
        [SerializeField] protected InputProvider _inputProvider;

        [Header("Processing Permission")]
        // Handler processing permission
        [SerializeField] protected bool shouldProcess = false;

        // Permission setter
        public void ToggleProcess(bool shouldProcess) { this.shouldProcess = shouldProcess; }

        public IInputHandler SetNext(IInputHandler next, bool shouldProcess)
        {
            nextHandler = next;
            this.shouldProcess = shouldProcess;
            return next;
        }

        public virtual InputProvider.InputState Process(InputProvider.InputState inputState)
        {
            if (nextHandler != null)
            {
                return nextHandler.Process(inputState);
            }
            else
            {
                return inputState;
            }
        }
    }
}
