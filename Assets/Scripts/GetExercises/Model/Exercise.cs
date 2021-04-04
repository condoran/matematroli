using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematroliiCreateConfig.Model
{
    public class BaseExercise
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Id { get; set; }
    }
    public class Exercise : BaseExercise
    {
        public Property Properties { get; set; }
        public string Pack { get; set; }
    }
    public class ExerciseView : BaseExercise
    {
        public List<Configuration> Histories { get; set; }
        public Pack Pack { get; set; }
    }

    public class ExerciseViewRasponse : BaseExercise
    {
        public List<Histories> Histories { get; set; }
        public Pack Pack { get; set; }
        public Property Properties { get; set; }
    }
}
