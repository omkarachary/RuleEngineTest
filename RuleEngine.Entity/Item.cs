namespace RuleEngine.Entity
{
    public class Item:BaseEntity
    {
        public string Name { get; set; }

        public ItemType ItemType { get; set; }
    }

    public enum ItemType{
        MemberShip=1,
        MemberShipUpgrade,
        Book,
        Video,
        PhysicalProduct,

    }
}