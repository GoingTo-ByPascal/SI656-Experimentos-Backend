using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources.SaveResources
{
    public class SavePlanResource
    {
        [Required]
        public string Name { get; set; }

    }
}
