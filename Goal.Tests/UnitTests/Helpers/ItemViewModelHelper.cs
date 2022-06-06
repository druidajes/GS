using Goal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Tests.UnitTests.Helpers
{
    public static class ItemViewModelHelper
    {
        public static ItemViewModel GetTaskViewModel()
        {
            return new ItemViewModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Name",
                Type = "Type",
                Expiration = DateTime.Now.AddDays(180)
            };
        }
    }
}
