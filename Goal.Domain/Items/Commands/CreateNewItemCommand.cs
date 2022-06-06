using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Domain.Items.Commands
{
    public class CreateNewItemCommand : ItemCommand
    {
        public CreateNewItemCommand(string name, string type)
        {
            Name = name;
            Type = type;
            Expiration = DateTime.Now.AddDays(180);
        }
    }
}
