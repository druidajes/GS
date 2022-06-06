using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Domain.Items.ValueObjects
{
    public readonly struct Name
    {
        private readonly string _text;

        public Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException($"Name value is required");
            }

            _text = text;
        }
        public override string ToString()
        {
            return _text;
        }
    }
}
