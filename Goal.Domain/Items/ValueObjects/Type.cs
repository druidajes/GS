using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Domain.Items.ValueObjects
{
    public readonly struct Type
    {
        private readonly string _text;

        public Type(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException($"Type value is required");
            }

            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
