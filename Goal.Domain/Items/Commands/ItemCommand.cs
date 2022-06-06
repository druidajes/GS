using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Domain.Items.Commands
{
    public class ItemCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime Expiration { get; set; }
    }
}
