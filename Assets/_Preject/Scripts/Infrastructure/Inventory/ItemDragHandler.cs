using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Inventory
{
    [RequireComponent(typeof(RectTransform))]
    public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform _rectTransform;
        private Canvas _canvas;
        
        private Vector2 _offset;
        private bool _isDraggable = true;

        public event Action<ItemDragHandler> OnBeginDragged;
        public event Action<ItemDragHandler> OnEndDragged;

        public void EnableDraggable() => _isDraggable = true;
        
        public void DisableDraggable() => _isDraggable = false;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_isDraggable == false) return;
            
            var localPoint = GetLocalPoint(eventData);
            _offset = localPoint - _rectTransform.anchoredPosition;
            
            OnBeginDragged?.Invoke(this);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_isDraggable == false) return;

            var localPoint = GetLocalPoint(eventData);
            _rectTransform.anchoredPosition = localPoint - _offset;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (_isDraggable == false) return;

            OnEndDragged?.Invoke(this);
        }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
        }

        private Vector2 GetLocalPoint(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                eventData.position,
                _canvas.worldCamera,
                out Vector2 localPoint);
            
            return localPoint;
        }
    }
}