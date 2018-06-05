using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eknowID.AppCode
{
    public class PageProfession
    {

        public PageProfession(string name, string shortDesc, string description)
        {
            Name = name;
            ShortDesc = shortDesc;
            Description = description;
        }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }

    }
}