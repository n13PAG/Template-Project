using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public abstract class BaseInputHandlerSO : ScriptableObject, IInputHandler
    {
        protected IInputHandler nextHandler;
        public IInputHandler GetNextHandler() { return nextHandler; }

        [Header("Input Provider")]
        [SerializeField] protected InputProviderSO _inputProvider;

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

        public virtual InputProviderSO.InputState Process(InputProviderSO.InputState inputState)
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
