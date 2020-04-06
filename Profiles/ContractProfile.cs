using System.Collections.Generic;
using System.IO;
using AutoMapper;
using GestaoContratos.Models;
using Microsoft.AspNetCore.Http;

namespace GestaoContratos.Profiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            //var contractFile = contractViewModel.File;

            //await using var stream = new MemoryStream();
            //await contractFile.CopyToAsync(stream);

            //contractViewModel.FileName = contractFile.FileName;
            //contract.File = stream.ToArray();

            CreateMap<IFormFile, byte[]>()
                         .ConvertUsing((file, bytes) =>
                         {
                             var target = new MemoryStream();
                             file.CopyTo(target);
                             return target.ToArray();
                         });

            CreateMap<ContractViewModel, Contract>().ForMember(
                dest => dest.FileName,
                opt => opt.MapFrom(src => src.File.FileName));
            //.ForMember(
            //dest => dest.File,
            //opt => opt.MapFrom(src => src.File));
            CreateMap<Contract, ContractViewModel>().ForMember(dest =>dest.File,expression => expression.Ignore());


            //CreateMap<IEnumerable<ContractViewModel>, IEnumerable<Contract>>();
            //CreateMap<IEnumerable<Contract>, IEnumerable<ContractViewModel>>();


        }
    }
}