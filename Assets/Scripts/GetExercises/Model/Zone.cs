using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematroliiCreateConfig.Model
{
    public class BaseZone
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Id { get; set; }
    }

    public class Zone:BaseZone
    {
        public string Mission { get; set; }
    }

    public class ZoneView:BaseZone
    {
        public List<Configuration> Packs { get; set; }
        public Mission Mission { get; set; }
    }
}
