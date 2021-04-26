using System.ComponentModel.DataAnnotations;
using TBC.Common.Resources;

namespace TBC.Application.Features.City.Commands.CreateCity
{
    /// <summary>
    /// Citiy Create Model 
    /// </summary>
    public class CreateCityModel
    {
        /// <summary>
        /// City Name
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "Name")]
        public string Name { get; set; }
    }
}
