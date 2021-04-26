using System.ComponentModel.DataAnnotations;
using TBC.Common.Resources;

namespace TBC.Application.Features.ContactType.Commands.UpdateContactType
{
    /// <summary>
    /// Contact Type Update Model 
    /// </summary>
    public class UpdateContactTypeModel
    {
        /// <summary>
        /// Contact Type Name
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "Name")]
        public string Name { get; set; }
    }
}
