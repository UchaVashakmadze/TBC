using System.ComponentModel.DataAnnotations;
using TBC.Common.Resources;

namespace TBC.Application.Features.City.Commands.UpdateCity
{
    /// <summary>
    /// City Update Model 
    /// </summary>
    public class UpdateCityModel
    {
        /// <summary>
        /// City Name
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "Name")]
        public string Name { get; set; }
    }
}
