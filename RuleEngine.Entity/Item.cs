namespace RuleEngine.Entity
{
    public class Item:BaseEntity
    {
        public string Name { get; set; }

        public ItemType ItemType { get; set; }
    }

    public enum ItemType{
        Membership=1,
        MembershipUpgrade,
        Book,
        Video,
        PhysicalProduct,

    }
}