using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PAG
{
    [CreateAssetMenu(fileName ="InputSystem", menuName ="Input/Handlers/InputSystem")]
    public class InputSystemSO : BaseInputHandlerSO
    {
        PlayerInputActions playerInputActions;

        // Instance of input state
        // Input cached here until input provider get state call
        private InputProviderSO.InputState _localInputState;


        // Internal Input Events
        public event Action onGenericAction; 

        private void OnEnable()
        {
            playerInputActions = new PlayerInputActions();

            // Enable all actions
            playerInputActions.Enable();

            playerInputActions.Gameplay.Movement.performed += Movement_performed;
            playerInputActions.Gameplay.Movement.canceled += Movement_canceled;

            playerInputActions.Gameplay.GenericAction.started += GenericAction_started;
            playerInputActions.Gameplay.GenericAction.canceled += GenericAction_canceled; 
        }

        private void OnDisable()
        {
            // Disable all actions
            playerInputActions.Disable();

            playerInputActions.Gameplay.Movement.performed -= Movement_performed;
            playerInputActions.Gameplay.Movement.canceled -= Movement_canceled;

            playerInputActions.Gameplay.GenericAction.started -= GenericAction_started;
        }

        private void Movement_performed(InputAction.CallbackContext context)
        {
            _localInputState.movementDirection = context.ReadValue<Vector2>();
        }
        private void Movement_canceled(InputAction.CallbackContext context)
        {
            _localInputState.movementDirection = context.ReadValue<Vector2>();
        }

        private void GenericAction_started(InputAction.CallbackContext context)
        {
            _inputProvider.OnGenericAction();
        }

        private void GenericAction_canceled(InputAction.CallbackContext obj)
        {
            
        }

        public override InputProviderSO.InputState Process(InputProviderSO.InputState inputState)
        {
            if (shouldProcess)
            {
                //inputState = _localInputProvider.inputState;
                inputState = _localInputState;
            }

            if (nextHandler != null)
            {
                nextHandler.Process(inputState);
            }

            return inputState;
        }
    }
}
