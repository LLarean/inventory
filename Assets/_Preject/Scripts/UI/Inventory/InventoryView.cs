using System.Collections.Generic;
using UnityEngine;

namespace UI.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private ItemView _itemView;
        [SerializeField] private Transform _contentItems ;
        [Space]
        [SerializeField] private int _numberOfItems;

        private List<ItemView> _items = new List<ItemView>();
        
        private void Start()
        {
            for (int i = 0; i < _numberOfItems; i++)
            {
                var newItem = Instantiate(_itemView, _contentItems);
                _items.Add(newItem);
            }
        }
    }
}