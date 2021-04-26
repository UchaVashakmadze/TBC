using System;
using System.ComponentModel.DataAnnotations;
using Common.Shared.Base;
using TBC.Common.Resources;
using TBC.Common.SharedModels;
using TBC.Domain.Enums;

namespace TBC.Application.Features.Persons.Queries.GetPersonsList
{
    /// <summary>
    /// Get Persons List
    /// </summary>
    public class GetPersonsModel : IBaseListModel
    {
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

        /// <summary>
        /// Search Query
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "SearchQuery")]
        public string SearchQuery { get; set; }

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

        /// <summary>
        /// The Date of Birth of the Person
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "BirthDate")]
        public DataRangeModel<DateTime?> BirthDate { get; set; }

        /// <summary>
        /// Gender of the Person
        /// </summary>
        [Display(ResourceType = typeof(StringResource), Name = "Gender")]
        public Gender Gender { get; set; }
    }
}
