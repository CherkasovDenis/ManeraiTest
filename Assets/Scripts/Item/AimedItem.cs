namespace ManeraiTest.Item
{
    public class AimedItem
    {
        public ItemType ItemType { get; }
        public float Distance { get; }

        public AimedItem(ItemType itemType, float distance)
        {
            ItemType = itemType;
            Distance = distance;
        }
    }
}