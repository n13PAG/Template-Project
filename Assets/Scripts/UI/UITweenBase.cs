using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PAG
{
    [RequireComponent(typeof(UIElementBase))]
    public class UITweenBase : MonoBehaviour
    {
        [Header("UI Element")]
        [SerializeField] private UIElementBase _UIElement;

        // UI Element components
        protected RectTransform targetRect;
        protected Image targetImage;

        // Event Assignment
        public enum EventType { OnOpen, OnClose, onPointerEnter, OnPointerExit, OnSubmit, OnSelect, OnDeselect, OnPointerClick, OnPointerUp, CustomEvent }
        [Header("Event")]
        public EventType _EventType;

        [Header("Tween Variables")]
        [SerializeField] protected LeanTweenType tweenType;
        [SerializeField] protected float tweenDuration;
        [SerializeField] protected bool tweeningDone = false;
        [SerializeField] protected bool canRepeatTween = false;
        public bool IsTweenDone() { return tweeningDone; }

        [Header("Looping")]
        [SerializeField] protected bool loopAnimation = false;


        // Chain data for struct use in inheriting classes
        protected int chainIndex = 0;
        protected float chainDuration = 0;
        protected int chainCount = 0;

        protected LeanTween currentTween;
        protected LTDescr tDescr;

        public void Setup(UIElementBase uIElementBase, RectTransform rect, Image image)
        {
            _UIElement = uIElementBase;
            targetRect = rect;
            targetImage = image;
        }

        public virtual void Tween()
        {
            NextTween();
        }

        protected virtual void NextTween()
        {

        }

        protected bool CheckForNextChain(int chainCount)
        {
            if (chainIndex >= chainCount)
            {
                if (loopAnimation)
                {
                    chainIndex = 0;
                    return true;
                }
                else
                {
                    TweenCompleted();

                    // Already completed last chain
                    return false;
                }
            }
            else
            {
                return true;
            }
        }


        public virtual void TweenReturn()
        {

        }

        public void EndLooping()
        {

        }
        
        protected void TweenCompleted()
        {
            if (!canRepeatTween)
            {
                tweeningDone = true;
            }
            else
            {
                chainIndex = 0;
            }

            // Call Next tween in UI element
            _UIElement.tweenCompleted?.Invoke(_EventType);
        }

        protected float GetChainDuration(float percentageOfDuration)
        {
            return (percentageOfDuration * 0.01f) * tweenDuration;
        }
    }
}
