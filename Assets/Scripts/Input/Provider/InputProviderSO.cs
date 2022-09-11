using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    [CreateAssetMenu(fileName ="InputProvider", menuName ="Input/InputProvider")]
    public class InputProviderSO : ScriptableObject, IInputProvider
    {
        [Header("Input Handlers")]
        [SerializeField] private List<BaseInputHandlerSO> inputHandlers = new List<BaseInputHandlerSO>();

        public event Action onGenericAction;
        public void OnGenericAction()
        {
            //if (inputState.canPerformAction)
                onGenericAction?.Invoke();
        }

        public void SetupHandlers()
        {
            for (int i = 0; i < inputHandlers.Count; i++)
            {
                if (i < inputHandlers.Count - 1)
                    inputHandlers[i].SetNext(inputHandlers[i + 1], false);
            }
        }

        public void ToggleHandler(int index, bool shouldProcess)
        {
            if (index < 0 || index >= inputHandlers.Count)
            {
                Debug.LogWarning("Handler index passed in out of bounds");
            }
            else
            {
                inputHandlers[index].ToggleProcess(shouldProcess);
            }
        }

        public InputState GetState()
        {
            return inputHandlers[0].Process(inputState);
        }

        [System.Serializable]
        public struct InputState
        {
            public Vector2 movementDirection;
            public bool canPerformAction;
        }

        public InputState inputState;
    }
}
