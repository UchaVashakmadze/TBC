using System.ComponentModel.DataAnnotations;
using Common.Shared.Base;
using TBC.Common.Resources;

namespace TBC.Application.Features.RelationshipType.Queries.GetRelationshipTypes
{
    /// <summary>
    /// Get Relationship Types Model 
    /// </summary>
    public class GetRelationshipTypesModel : IBaseListModel
    {
        /// <summary>
        /// Relationship Type Name
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "Name")]
        public string SearchQuery { get; set; }

        /// <summary>
        /// Page Number
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "PageNumber")]
        public int? PageNumber { get; set; }

        /// <summary>
        /// Page Size
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "PageSize")]
        public int? PageSize { get; set; }
    }
}
