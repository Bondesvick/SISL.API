using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using SISL.Core.DTOs;
using SISL.Core.DTOs.Request;
using SISL.Core.DTOs.Response;
using SISL.Core.Entities;
using SISL.Core.Extensions;

namespace SISL.Infrastructure.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //POST
            CreateMap<SaveCustomerAccountDto, CustomerAccount>()
                .ForMember(dest => dest.SislDocuments, opt
                    => opt.MapFrom(src => src.Documents))
                .ForMember(dest => dest.SureName, opt
                    => opt.MapFrom(src => src.SureName.ToUpper()))
                .ForMember(dest => dest.FirstName, opt
                    => opt.MapFrom(src => src.FirstName.ToUpper()))
                .ForMember(dest => dest.OtherNames, opt
                    => opt.MapFrom(src => src.OtherNames.ToUpper()))
                .ForMember(dest => dest.NextOfKin, opt
                    => opt.MapFrom(src => src.NextOfKin.ToUpper()))
                .ForMember(dest => dest.NextOfKinSurname, opt
                    => opt.MapFrom(src => src.NextOfKinSurname.ToUpper()))
                .ForMember(dest => dest.NextOfKinOtherNames, opt
                    => opt.MapFrom(src => src.NextOfKinOtherNames.ToUpper()))
                .ForMember(dest => dest.MothersMaidenName, opt
                    => opt.MapFrom(src => src.MothersMaidenName.ToUpper()))
                .ForMember(dest => dest.City, opt
                    => opt.MapFrom(src => src.City.ToTitleCase()))
                .ForMember(dest => dest.CompName, opt
                    => opt.MapFrom(src => src.CompName.ToTitleCase()))
                .ForMember(dest => dest.NOKNationality, opt
                    => opt.MapFrom(src => src.NOKNationality.ToTitleCase()))
                .ForMember(dest => dest.PermanentAddress, opt
                    => opt.MapFrom(src => src.PermanentAddress.ToTitleCase()))
                .ForMember(dest => dest.LGA, opt
                    => opt.MapFrom(src => src.LGA.ToTitleCase()))
                .ForMember(dest => dest.Occupation, opt
                    => opt.MapFrom(src => src.Occupation.ToTitleCase()))
                .ForMember(dest => dest.Relationship, opt
                    => opt.MapFrom(src => src.Relationship.ToTitleCase()))
                .ForMember(dest => dest.ContactAddress, opt
                    => opt.MapFrom(src => src.ContactAddress.ToTitleCase()))
                .ForMember(dest => dest.OfficialAddress, opt
                    => opt.MapFrom(src => src.OfficialAddress.ToTitleCase()))
                .ForMember(dest => dest.PEPWho, opt
                    => opt.MapFrom(src => src.PEPWho.ToTitleCase()))
                .ForMember(dest => dest.PoliticallyExposedPerson, opt
                    => opt.MapFrom(src => src.PoliticallyExposedPerson.ToTitleCase()))
                .ForMember(dest => dest.PositionHeld, opt
                    => opt.MapFrom(src => src.PositionHeld.ToTitleCase()));

            CreateMap<SaveSislHistoryDto, SislHistory>();
            CreateMap<SislDocumentModel, SislDocument>()
                .ForMember(dest => dest.Title, opt
                    => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.FileName, opt
                    => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ContentOrPath, opt
                    => opt.MapFrom(src => src.Base64Content))
                .ForMember(dest => dest.ContentType, opt
                    => opt.MapFrom(src => GetDocumentContentType(src.Name)));

            //GET
            CreateMap<CustomerAccount, CustomerAccountDto>()
                .ForMember(dest => dest.SislHistories, opts
                    => opts.MapFrom(src => src.SislHistories))
                .ForMember(dest => dest.SislDocuments, opts => opts.MapFrom(src => src.SislDocuments));

            CreateMap<SislHistory, SislHistoryDto>().ForMember(dest => dest.SislStatus,
                opts
                    => opts.MapFrom(src => src.SislStatus));

            CreateMap<SislStatus, SislStatusDto>();

            CreateMap<SislDocument, GetSislDocumentDto>();
        }

        private string GetDocumentContentType(string fileName)
        {
            string contenttype = "";
            switch (fileName.Split('.')[1].ToLower())
            {
                case "doc":
                    contenttype = "application/vnd.ms-word";
                    break;

                case "docx":
                    contenttype = "application/vnd.ms-word";
                    break;

                case "pdf":
                    contenttype = "application/pdf";
                    break;

                case "jpg":
                    contenttype = "image/jpeg";
                    break;

                case "svg":
                    contenttype = "image/svg+xml";
                    break;

                case "jpeg":
                    contenttype = "image/jpeg";
                    break;

                case "png":
                    contenttype = "image/png";
                    break;

                case "gif":
                    contenttype = "image/gif";
                    break;
            }
            return contenttype;
        }
    }
}