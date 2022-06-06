using Goal.Domain.Items.ValueObjects;

namespace Goal.Domain.Items
{
    public interface IItemFactory
    {
        Item CreateItemInstance(Name name, Domain.Items.ValueObjects.Type type);
    }
}