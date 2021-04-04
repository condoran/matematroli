using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematroliiCreateConfig.Model
{
    public class BasePack
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Id { get; set; }
    }

    public class Pack:BasePack
    {
        public string Zone { get; set; }
    }

    public class PackView:BasePack
    {
        public List<Configuration> Exercises { get; set; }
        public Zone Zone { get; set; }
    }
}
