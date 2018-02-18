using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Console_Automapper.Model;

namespace Console_Automapper.Automapper
{
    /// <summary>
    /// Class MemberProfile.
    /// </summary>
    public class MemberProfile
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper _mapper;

        /// <summary>
        /// The mapper configuration
        /// </summary>
        private MapperConfiguration _mapperConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberProfile"/> class.
        /// </summary>
        public MemberProfile()
        {
            //建立MapperConfiguration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Member, MemberMapper>()
                    //對應到MemberMapper的ID,資料來自於Member裡id
                    .ForMember(destination => destination.ID, opts => opts.MapFrom(source => source.id))
                    .ForMember(destination => destination.UserName, opts => opts.MapFrom(source => source.UserName))
                    .ForMember(destination => destination.Birthday, opts => opts.MapFrom(source => source.Birthday));

            });
            this._mapperConfiguration = config;
        }

        /// <summary>
        /// Creates the mapper.
        /// </summary>
        /// <returns>IMapper.</returns>
        public IMapper CreateMapper()
        {
            this._mapper = this._mapperConfiguration.CreateMapper();
            return this._mapper;
        }
    }
}
