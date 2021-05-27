using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class LocatableResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string BannerImage { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int LocatableTypeId { get; set; }
        public List<LocatableImageResource> LocatableImages {get;set;}
    }
}
