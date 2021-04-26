using System.ComponentModel.DataAnnotations;
using TBC.Common.Resources;

namespace TBC.Application.Features.Persons.Queries.GetPersonPersonRelationshipsList
{
    public class GetPersonPersonRelationshipsModel 
    {
        /// <summary>
        /// The Id of the person
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "PersonId")]
        public int? PersonId { get; set; }


        /// <summary>
        /// The Firstname of the Person
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// The Lastname of the Person
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "LastName")]
        public string LastName { get; set; }

    }
}
