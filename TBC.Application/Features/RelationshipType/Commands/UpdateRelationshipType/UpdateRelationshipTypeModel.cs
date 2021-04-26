using System.ComponentModel.DataAnnotations;
using TBC.Common.Resources;

namespace TBC.Application.Features.RelationshipType.Commands.UpdateRelationshipType
{
    /// <summary>
    /// Relationship Type Update Model 
    /// </summary>
    public class UpdateRelationshipTypeModel
    {
        /// <summary>
        /// Relationship Type Name
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "Name")]
        public string Name { get; set; }
    }
}
