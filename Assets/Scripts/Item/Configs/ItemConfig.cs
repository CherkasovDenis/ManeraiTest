using UnityEngine;

namespace ManeraiTest.Item.Configs
{
    [CreateAssetMenu(fileName = nameof(ItemConfig), menuName = "Configs/ItemConfig")]
    public class ItemConfig : ScriptableObject
    {
        public string Id => _id;

        public ItemType Type => _type;

        public string Name => _name;

        public float Mass => _mass;

        [SerializeField]
        private string _id;

        [SerializeField]
        private ItemType _type;

        [SerializeField]
        private string _name;

        [SerializeField]
        private float _mass;
    }
}