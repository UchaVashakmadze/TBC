using System.ComponentModel.DataAnnotations;
using TBC.Common.Resources;

namespace TBC.Application.Features.RelationshipType.Commands.CreateRelationshipType
{
    /// <summary>
    /// Relationship Type Create Model 
    /// </summary>
    public class CreateRelationshipTypeModel
    {
        /// <summary>
        /// Relationship Type Name
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "Name")]
        public string Name { get; set; }
    }
}
