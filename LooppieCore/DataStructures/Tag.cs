using System;
using System.Collections.Generic;
using System.Text;

namespace LooppieCore
{
    public class Tag
    {
        public TagEnum TagEnum { get; set; }

        public Tag(TagEnum tagEnum)
        {
            TagEnum = TagEnum;
        }
    }
}
