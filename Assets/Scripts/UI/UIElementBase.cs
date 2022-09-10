using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PAG
{
    public class UIElementBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler
    {
        [Header("UI Components")]
        [SerializeField] private RectTransform UI_Rect;
        [SerializeField] private Image UI_Image;

        [Header("UI State")]
        [SerializeField] protected bool elementOpened = false;
        [SerializeField] protected bool pointerOver = false;
        [SerializeField] protected bool pointerClicked = false;
        [SerializeField] protected bool isSelected = false;

        // Events
        protected UnityEvent onOpenEvent = new UnityEvent();
        protected UnityEvent onCloseEvent = new UnityEvent();
        protected UnityEvent onPointerEnterEvent = new UnityEvent();
        protected UnityEvent onPointerExitEvent = new UnityEvent();
        protected UnityEvent onSubmitEvent = new UnityEvent();
        protected UnityEvent onSelectEvent = new UnityEvent();
        protected UnityEvent onDeselectEvent = new UnityEvent();
        protected UnityEvent onPointerClickEvent = new UnityEvent();
        protected UnityEvent onPointerUpEvent = new UnityEvent();
        protected UnityEvent<UITweenBase.EventType> onNewEventInvoked = new UnityEvent<UITweenBase.EventType>();
        public UnityEvent<UITweenBase.EventType> tweenCompleted = new UnityEvent<UITweenBase.EventType>();

        [Header("Tween List")]
        [SerializeField] protected List<UITweenBase> fulltweenList = new List<UITweenBase>();
        protected List<UITweenBase> onOpen_tweenList = new List<UITweenBase>();
        protected List<UITweenBase> onClose_tweenList = new List<UITweenBase>();
        protected List<UITweenBase> onPointerEnter_tweenList = new List<UITweenBase>();
        protected List<UITweenBase> onPointerExit_tweenList = new List<UITweenBase>();
        protected List<UITweenBase> onSubmit_tweenList = new List<UITweenBase>();
        protected List<UITweenBase> onSelect_tweenList = new List<UITweenBase>();
        protected List<UITweenBase> onDeselect_tweenList = new List<UITweenBase>();
        protected List<UITweenBase> onPointerClick_tweenList = new List<UITweenBase>();
        protected List<UITweenBase> onPointerUp_tweenList = new List<UITweenBase>();
        protected List<UITweenBase> unAssignedTweenList = new List<UITweenBase>();

        private void OnEnable()
        {
            // Components
            if (UI_Rect == null)
                UI_Rect = GetComponent<RectTransform>();

            if (UI_Image == null)
                UI_Image = GetComponent<Image>();

            elementOpened = gameObject.activeInHierarchy;

            AssignTweens();

            SubscribeTweenList(onOpen_tweenList, onOpenEvent);
            SubscribeTweenList(onClose_tweenList, onCloseEvent);
            SubscribeTweenList(onPointerEnter_tweenList, onPointerEnterEvent);
            SubscribeTweenList(onPointerExit_tweenList, onPointerExitEvent);
            SubscribeTweenList(onSubmit_tweenList, onSubmitEvent);
            SubscribeTweenList(onSelect_tweenList, onSelectEvent);
            SubscribeTweenList(onDeselect_tweenList, onDeselectEvent);
            SubscribeTweenList(onPointerClick_tweenList, onPointerClickEvent);
            SubscribeTweenList(onPointerUp_tweenList, onPointerUpEvent);
        }

        private void OnDisable()
        {
            UnsubscribeTweenList(onOpen_tweenList, onOpenEvent);
            UnsubscribeTweenList(onClose_tweenList, onCloseEvent);
            UnsubscribeTweenList(onPointerEnter_tweenList, onPointerEnterEvent);
            UnsubscribeTweenList(onPointerExit_tweenList, onPointerExitEvent);
            UnsubscribeTweenList(onSubmit_tweenList, onSubmitEvent);
            UnsubscribeTweenList(onSelect_tweenList, onSelectEvent);
            UnsubscribeTweenList(onDeselect_tweenList, onDeselectEvent);
            UnsubscribeTweenList(onPointerClick_tweenList, onPointerClickEvent);
            UnsubscribeTweenList(onPointerUp_tweenList, onPointerUpEvent);
        }

        #region UI Actions
        public virtual void Open()
        {
            elementOpened = true;
            onOpenEvent?.Invoke();
        }

        public virtual void Close()
        {
            elementOpened = false;
            onCloseEvent?.Invoke();
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            pointerOver = true;
            onPointerEnterEvent?.Invoke();
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            pointerOver = false;
            onPointerExitEvent?.Invoke();
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (!pointerClicked)
            {
                pointerClicked = true;
                onPointerClickEvent?.Invoke();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (pointerClicked)
            {
                pointerClicked = false;
                onPointerUpEvent?.Invoke();
            }
        }

        public void OnSelect(BaseEventData eventData)
        {
            if (!isSelected)
            {
                isSelected = true;
                onSelectEvent?.Invoke();
            }
        }

        public void OnDeselect(BaseEventData eventData)
        {
            if (isSelected)
            {
                isSelected = false;
                onDeselectEvent?.Invoke();
            }
        }

        #endregion

        #region Tween
        protected void AddTween(UITweenBase uITween, List<UITweenBase> tweenList)
        {
            uITween.Setup(this, UI_Rect, UI_Image);
            tweenList.Add(uITween);
        }

        protected void AssignTweens()
        {
            if (fulltweenList.Count == 0)
            {
                GetComponents(fulltweenList);
            }

            for (int i = 0; i < fulltweenList.Count; i++)
            {
                var tween = fulltweenList[i];

                switch (tween._EventType)
                {
                    case UITweenBase.EventType.OnOpen:

                        AddTween(tween, onOpen_tweenList);

                        break;
                    case UITweenBase.EventType.OnClose:

                        AddTween(tween, onClose_tweenList);

                        break;
                    case UITweenBase.EventType.onPointerEnter:

                        AddTween(tween, onPointerEnter_tweenList);

                        break;
                    case UITweenBase.EventType.OnPointerExit:

                        AddTween(tween, onPointerExit_tweenList);

                        break;
                    case UITweenBase.EventType.OnSubmit:

                        AddTween(tween, onSubmit_tweenList);

                        break;
                    case UITweenBase.EventType.OnSelect:

                        AddTween(tween, onSelect_tweenList);

                        break;
                    case UITweenBase.EventType.OnDeselect:

                        AddTween(tween, onDeselect_tweenList);

                        break;
                    case UITweenBase.EventType.OnPointerClick:

                        AddTween(tween, onPointerClick_tweenList);

                        break;

                    case UITweenBase.EventType.OnPointerUp:

                        AddTween(tween, onPointerUp_tweenList);

                        break;

                    case UITweenBase.EventType.CustomEvent:

                        AddTween(tween, unAssignedTweenList);

                        break;
                }
            }
        }

        protected void SubscribeTweenList(List<UITweenBase> tweenList, UnityEvent unityEvent)
        {
            foreach (var t in tweenList)
            {
                unityEvent.AddListener(t.Tween);
            }
        }

        protected void UnsubscribeTweenList(List<UITweenBase> tweenList, UnityEvent unityEvent)
        {
            foreach (var t in tweenList)
            {
                unityEvent.RemoveListener(t.Tween);
            }
        }
        #endregion
    }
}
