using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public interface IInputProvider 
    {
        public event Action onGenericAction;
        public InputProviderSO.InputState GetState();
    }
}
