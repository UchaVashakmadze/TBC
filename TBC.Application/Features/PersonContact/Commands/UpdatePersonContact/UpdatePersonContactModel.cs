using System.ComponentModel.DataAnnotations;
using TBC.Common.Resources;

namespace TBC.Application.Features.PersonContact.Commands.UpdatePersonContact
{
    /// <summary>
    /// Person Contact for Update 
    /// Id of Person Contact Type, 
    /// The Value, 
    /// </summary>
    public class UpdatePersonContactModel
    {
        /// <summary>
        /// Id of Person Contact
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Id of Person
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "PersonId")]
        public int PersonId { get; set; }

        /// <summary>
        /// Id of Person Contact Type
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "ContactTypeId")]
        public int PersonContactTypeId { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "Value")]
        public string Value { get; set; }
    }
}
