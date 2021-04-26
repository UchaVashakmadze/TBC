using System.ComponentModel.DataAnnotations;
using TBC.Common.Resources;

namespace TBC.Application.Features.PersonContact.Commands.CreatePersonContact
{
    /// <summary>
    /// A Person Contact 
    /// The Id of the Contact Type, 
    /// The Value, 
    /// </summary>
    public class CreatePersonContactModel
    {
        /// <summary>
        /// The Id of the Person
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "PersonId")]
        public int PersonId { get; set; }

        /// <summary>
        /// The Id of the Contact Type
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "ContactTypeId")]
        public int PersonContactTypeId { get; set; }

        /// <summary>
        /// The Value
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "Value")]
        public string Value { get; set; }
    }
}
