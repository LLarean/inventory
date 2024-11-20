using System;
using UnityEngine;

namespace Infrastructure.Inventory
{
    public class InventaryTemp : MonoBehaviour
    {
        [SerializeField] private ItemDragHandler _itemDragHandler;
        private Vector3 _localPosition;

        private void Start()
        {
            _itemDragHandler.OnBeginDragged += BeginDrag;
            _itemDragHandler.OnEndDragged += EndDrag;
        }

        private void BeginDrag(ItemDragHandler itemDragHandler)
        {
            _localPosition = itemDragHandler.gameObject.transform.localPosition;
        }

        private void EndDrag(ItemDragHandler itemDragHandler)
        {
            itemDragHandler.gameObject.transform.localPosition = _localPosition;
        }
    }
}