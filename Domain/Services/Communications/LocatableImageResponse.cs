using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class LocatableImageResponse : BaseResponse<LocatableImage>
    {
        public LocatableImageResponse(string message) : base(message){}

        public LocatableImageResponse(LocatableImage locatableImage) : base(locatableImage) { }
    }
}
