using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Items
{
    [CreateAssetMenu(menuName = "Item")]
    public class AssetItem : ScriptableObject, IItem
    {
        string IItem.Name => _name;
        Sprite IItem.UIIcon => _uiIcon;

        [SerializeField] private string _name;
        [SerializeField] private Sprite _uiIcon;

    }
}