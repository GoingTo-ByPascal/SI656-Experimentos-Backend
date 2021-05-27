using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models

{
    public class LocatableImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int LocatableId { get; set; }
        public Locatable Locatable { get; set; }

    }
}
