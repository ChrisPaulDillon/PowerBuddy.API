using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBuddy.Data.Entities
{
    /// <summary>
    /// Used to store premade workout templates for a given day
    /// </summary>
    public partial class WorkoutTemplate
    {
        public int WorkoutTemplateId { get; set; }
        public string WorkoutName { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
    }
}