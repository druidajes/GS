using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Domain.Items.Commands
{
    public class DeleteItemCommand : ItemCommand
    {
        public DeleteItemCommand(Guid id)
        {
            Id = id;
        }
    }
}
