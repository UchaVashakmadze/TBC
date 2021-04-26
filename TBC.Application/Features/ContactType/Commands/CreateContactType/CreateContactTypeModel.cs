using System.ComponentModel.DataAnnotations;
using TBC.Common.Resources;

namespace TBC.Application.Features.ContactType.Commands.CreateContactType
{
    /// <summary>
    /// Contact Type Create Model 
    /// </summary>
    public class CreateContactTypeModel
    {
        /// <summary>
        /// Contact Type Name
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "Name")]
        public string Name { get; set; }
    }
}
