using ApplciationPublication.Common.BusinessLayer;
using ApplciationPublication.Common.Repository;
using ApplciationPublication.Dto;
using AutoMapper;
using Domain.Entity.publicationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraPublication.BusinessLayer
{
    public class IPublicationBL : IPublicationBl
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IMapper _mapper;

        public IPublicationBL(IPublicationRepository publicationRepository, IMapper mapper)
        {
            _publicationRepository = publicationRepository;
            _mapper = mapper;
        }



        #region publication
        public async Task CreatePublication(PublicationDto pub)
        {
            if( pub == null )
            {
                //----
                var mapped= _mapper.Map<Publication>(pub);
                _publicationRepository.Insert(mapped);
                //----
            }
        }

        public async Task DeletePublication(string pubId)
        {
            var getPub = await _publicationRepository.GetById(pubId);
            if (pubId != null)
            {
                //----
                var mapped = _mapper.Map<Publication>(getPub);
                _publicationRepository.Insert(mapped);
                //----
            }
        }
        public async Task<IEnumerable<PublicationDto>> GetAllbyPublicationID(string userId)
        {
            var getPub = await _publicationRepository.GetAll();
            if (getPub != null)
            {
                //----
                return _mapper.Map<IEnumerable<PublicationDto>>(getPub);
                
                //----
            }
            return null;
        }

        public Task<IEnumerable<PublicationDto>> GetAllPublication()
        {
            throw new NotImplementedException();
        }

        public async Task<PublicationDto> GetPublicationById(string pubId)
        {
            var getPub = await _publicationRepository.GetById(pubId);
            if (getPub != null)
            {
                //----
                return _mapper.Map<PublicationDto>(getPub);

                //----
            }
            return null;
        } 
        public async Task UpdatePublication(string pubId, string content)
        {
            var getPub = await _publicationRepository.GetById(pubId);
            if (pubId != null)
            {
                //----
               
                _publicationRepository.UpdatePublicationContent(pubId,content);
                //----
            }
        }
        #endregion    
    }
}
