using Amazon.Runtime.Internal.Util;
using ApplicationPublication.Common.BusinessLayer;
using ApplicationPublication.Common.Repository;
using ApplicationPublication.Dto;
using AutoMapper;
using Domain.Entity.publicationEntity;
using InfraPublication.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InfraPublication.BusinessLayer
{
    public class PublicationBL : IPublicationBl
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly ILogger<PublicationBL> _logger;
        private readonly IMapper _mapper;

        public PublicationBL(IPublicationRepository publicationRepository, IMapper mapper, ILogger<PublicationBL> logger)
        {
            _logger = logger;
            _publicationRepository = publicationRepository;
            _mapper = mapper;
        }



        #region publication
        public async Task CreatePublication(AddPublicationDto pub)
        {
            try
            {
                Publication mapped= _mapper.Map<Publication>(pub);
                mapped.UpdatedDate=DateTime.Now;
                mapped.CreatedDate=DateTime.Now;
                _publicationRepository.Insert(mapped);
                //----
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
            }//----
              
        }

        public async Task DeletePublication(string pubId)
        {
            try
            {
                Publication getPub = await _publicationRepository.GetById(pubId) ?? throw new NullReferenceException();
                 //----
                 if(getPub != null) 
                {
                    _publicationRepository.Delete(pubId);
                    
                }
                 //----
           
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
            }//----
        }
        public async Task<IEnumerable<PublicationDto>> GetAllbyPublicationByUserId(string userId)
        {
            try
            {
                IEnumerable<Publication> getPub = await _publicationRepository.GetAllPublicationByUserId(userId) 
                                                                 ?? throw new NullReferenceException("no user found inside ") ;
                return _mapper.Map<IEnumerable<PublicationDto>>(getPub);
                 
            }
            catch(ArgumentException)
            {
                IEnumerable<PublicationDto> Empty = Enumerable.Empty<PublicationDto>();
                return Empty;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
                IEnumerable<PublicationDto> Empty = Enumerable.Empty<PublicationDto>();
                return Empty;
            }//----

        }

        public async Task<IEnumerable<PublicationDto>> GetAllPublication()
        {
            try
            { 
                return _mapper.Map<IEnumerable<PublicationDto>>(await _publicationRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
                IEnumerable<PublicationDto> Empty = Enumerable.Empty<PublicationDto>();
                return Empty;
            }
           
        }

        public async Task<PublicationDto> GetPublicationById(string pubId)
        {
            try
            {
               Publication getPublic = await _publicationRepository.GetById(pubId) 
                                             ?? throw new ArgumentException() ;
                if (string.IsNullOrEmpty(getPublic.Review))
                {
                    //----
                    return _mapper.Map<PublicationDto>(getPublic);

                    //----
                }
                return new PublicationDto();  
            } catch (Exception ex) 
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
                return new PublicationDto();
            }
           
        }
        public async Task UpdatePublication(string pubId, string title, string content)
        {
            try
            {
                Publication getPub = await _publicationRepository.GetById(pubId)
                                    ?? throw new NullReferenceException("null reference");
                if (getPub != null)
                {
                    await _publicationRepository.UpdatePublicationContent(pubId ,title,content);
                    //----
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
               
            }
        }
        #endregion    
    }
}
