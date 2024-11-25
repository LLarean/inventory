using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        
        public void Initialize(in ItemModel itemModel)
        {
            _icon.sprite = itemModel.Icon;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("OnCollisionEnter2D");
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter");
        }
    }
}