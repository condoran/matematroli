using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematroliiCreateConfig.Model
{
    public class BaseMission
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Id { get; set; }
    }

    public class Mission:BaseMission
    {
        public List<string> Configurations { get; set; }
    }

    public class MissionView:BaseMission
    {
        public List<Configuration> Configurations { get; set; }
    }
}
