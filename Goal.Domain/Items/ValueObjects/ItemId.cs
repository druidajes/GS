using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Domain.Items.ValueObjects
{
    public struct ItemId
    {
        private readonly Guid _itemId;

        public ItemId(Guid itemId)
        {
            if (itemId.Equals(Guid.Empty))
                throw new ArgumentNullException($"Task Id does not have any value");

            _itemId = itemId;
        }

        public Guid ToGuid()
        {
            return _itemId;
        }
    }
}
