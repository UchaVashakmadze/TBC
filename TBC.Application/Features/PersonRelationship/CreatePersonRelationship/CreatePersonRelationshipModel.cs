using System.ComponentModel.DataAnnotations;
using TBC.Common.Resources;

namespace TBC.Application.Features.PersonRelationship.CreatePersonRelationship
{
    /// <summary>
    /// A Person Relationship Create Model 
    /// </summary>
    public class CreatePersonRelationshipModel
    {
        /// <summary>
        /// The Id of the Person
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "PersonId")]
        public int PersonId { get; set; }

        /// <summary>
        /// The Id of the Person to Relate
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "RelatedPersonId")]
        public int RelatedPersonId { get; set; }

        /// <summary>
        /// The Id of the Persons Relationship Type
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "RelationshipTypeId")]
        public int PersonsRelationshipTypeId { get; set; }
    }
}
