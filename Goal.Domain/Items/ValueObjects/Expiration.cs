using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Domain.Items.ValueObjects
{
    public readonly struct Expiration
    {
        private readonly DateTime _expiration;

        public Expiration(DateTime? expiration)
        {
            if (expiration == null)
            {
                throw new ArgumentNullException($"Expiration value is required");
            }

            _expiration = (DateTime)expiration;
        }
        public DateTime ToDatetime()
        {
            return _expiration;
        }
    }
}
