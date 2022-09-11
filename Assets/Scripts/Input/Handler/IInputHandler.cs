using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public interface IInputHandler
    {
        public void ToggleProcess(bool shouldProcess);
        public IInputHandler SetNext(IInputHandler next, bool shouldProcess);
        public abstract InputProviderSO.InputState Process(InputProviderSO.InputState inputState);
    }
}
