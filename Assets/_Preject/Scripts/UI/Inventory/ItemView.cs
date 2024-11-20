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
    }
}