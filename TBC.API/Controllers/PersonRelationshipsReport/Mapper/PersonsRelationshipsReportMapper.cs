using AutoMapper;
using TBC.Application.Features.Persons.Queries.GetPersonPersonRelationshipsList;

namespace TBC.API.Controllers.PersonRelationshipsReport.Mapper
{
    /// <summary>
    /// Persons Relationships Report Mapper
    /// </summary>
    public class PersonsRelationshipsReportMapper : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PersonsRelationshipsReportMapper()
        {

            CreateMap<GetPersonPersonRelationshipsModel, GetPersonPersonRelationshipsQuery>();
        }
    }
}
