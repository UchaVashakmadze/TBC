using System.Linq;
using AutoMapper;
using TBC.Application.Features.Persons.Commands.CreatePerson;
using TBC.Application.Features.Persons.Commands.UpdatePerson;
using TBC.Application.Features.Persons.Queries.GetPersonDetails;
using TBC.Application.Features.Persons.Queries.GetPersonsList;

namespace TBC.API.Controllers.Person.Mapper
{
    /// <summary>
    /// Persons Mapper
    /// </summary>
    public class PersonsMapper : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PersonsMapper()
        {
            CreateMap<CreatePersonModel, CreatePersonCommand>();
            CreateMap<UpdatePersonModel, UpdatePersonCommand>();
            CreateMap<GetPersonsModel, GetPersonsQuery>();

            CreateMap<Domain.AggregatesModel.PersonAggregate.Person, PersonModel>()
                .ForMember(x => x.FirstName,
                    m => m.MapFrom(f => f.Name.Firstname))
                .ForMember(x => x.LastName,
                    m => m.MapFrom(f => f.Name.Lastname))
                .ForMember(x => x.PersonalNumber,
                    m => m.MapFrom(f => f.PersonalNumber.Value));

            CreateMap<Domain.AggregatesModel.PersonAggregate.PersonAddress, PersonAddressModel>()
                .ForMember(x => x.Id,
                    m => m.MapFrom(f => f.Id))
                .ForMember(x => x.Name,
                    m => m.MapFrom(f => f.Value));

            CreateMap<Domain.AggregatesModel.PersonAggregate.PersonContact, PersonContactModel>()
                .ForMember(x => x.Id,
                    m => m.MapFrom(f => f.Id))
                .ForMember(x => x.Value,
                    m => m.MapFrom(f => f.Value));

            CreateMap<Domain.AggregatesModel.PersonAggregate.PersonRelationship, PersonsRelationsModel>()
                .ForMember(x => x.Id,
                    m => m.MapFrom(f => f.Id))
                .ForMember(x => x.FirstName,
                    m => m.MapFrom(f => f.RelatedPerson.Name.Firstname))
                .ForMember(x => x.LastName,
                    m => m.MapFrom(f => f.RelatedPerson.Name.Lastname));

            CreateMap<Domain.AggregatesModel.PersonAggregate.Person, PersonDetailsModel>()
                .ForMember(x => x.FirstName,
                    m => m.MapFrom(f => f.Name.Firstname))
                .ForMember(x => x.LastName,
                    m => m.MapFrom(f => f.Name.Lastname))
                .ForMember(x => x.PersonalNumber,
                    m => m.MapFrom(f => f.PersonalNumber.Value))
                .ForMember(x => x.Address,
                    m => m.MapFrom(f => f.PersonAddresses.FirstOrDefault()))
                .ForMember(x => x.Contacts,
                    m => m.MapFrom(f => f.PersonContacts))
                .ForMember(x => x.RelatedPersons,
                m => m.MapFrom(f => f.MainPersonRelationships));
        }
    }
}
