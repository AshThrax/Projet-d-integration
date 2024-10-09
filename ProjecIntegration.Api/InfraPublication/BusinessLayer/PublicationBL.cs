using Amazon.Runtime.Internal.Util;
using ApplicationPublication.Common.BusinessLayer;
using ApplicationPublication.Common.Repository;
using ApplicationPublication.Dto;
using ApplicationTheather.Common.Interfaces.IRepository;
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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PublicationBL(IPublicationRepository publicationRepository, IMapper mapper, ILogger<PublicationBL> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _publicationRepository = publicationRepository;
            _userRepository= userRepository;
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
                await _publicationRepository.Insert(mapped);
                //----
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
            }//----
              
        }
        /// <summary>
        /// supprimer une publication par Id
        /// </summary>
        /// <param name="pubId"></param>
        /// <returns></returns>
        public async Task DeletePublication(string pubId)
        {
            try
            {
                Publication getPub = await _publicationRepository.GetById(pubId) ?? throw new NullReferenceException();
                 //----
                 if(getPub != null) 
                {
                   _= _publicationRepository.Delete(pubId);
                    
                }
                 //----
           
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
            }//----
        }
        /// <summary>
        /// récu^pére toutes les publication 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PublicationDto>> GetAllbyPublicationByUserId(string userId)
        {
            try
            {
                IEnumerable<Publication> getPub = await _publicationRepository.GetAllPublicationByUserId(userId) 
                                                                 ?? throw new NullReferenceException("no user found inside ") ;
                
                IEnumerable<PublicationDto> getPublicationDto= _mapper.Map<IEnumerable<PublicationDto>>(getPub);
                
                return getPublicationDto;
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
        /// <summary>
        /// récupére toutes les publications 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// récupére les publication par Id
        /// </summary>
        /// <param name="pubId"></param>
        /// <returns></returns>
        public async Task<PublicationDto> GetPublicationById(string pubId)
        {
            try
            {
               Publication getPublic = await _publicationRepository.GetById(pubId) 
                                             ?? throw new ArgumentException() ;
                if (!string.IsNullOrEmpty(getPublic.Review))
                {
                    //----
                    PublicationDto getPublication= _mapper.Map<PublicationDto>(getPublic);

                    return getPublication;
                }
                return new PublicationDto();  
            } catch (Exception ex) 
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
                return new PublicationDto();
            }
           
        }
        /// <summary>
        /// récupére toutes les publication lier a une piece 
        /// </summary>
        /// <param name="pieceId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PublicationDto>> GetPublicationByPiece(int pieceId)
        {
            try
            {
                IEnumerable<Publication> Getpublication = await _publicationRepository.GetAllPublicationByPieceId(pieceId);
                IEnumerable<PublicationDto> getPublicationDto= _mapper.Map<IEnumerable<PublicationDto>>(Getpublication);

               
                return getPublicationDto;   
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
                return Enumerable.Empty<PublicationDto>();
            }
        }

        public async Task<bool> Hasreview(int pieceId, string userId)
        {
            try
            {
                bool hasreview = await _publicationRepository.Doexist(pieceId,userId);
                return (hasreview);
            }
            catch (Exception ex)
            {

                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
                return false;
            }
        }

        /// <summary>
        /// vérifie qu'un utilisateur est bie propriétaire d'une publication
        /// </summary>
        /// <param name="pubId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> IsAuthor(string pubId, string userId)
        {
            try
            {
                Publication? getpublication =await _publicationRepository.GetById(pubId);
                return (getpublication.UserId.Equals(userId));
            }
            catch (Exception ex)
            {

                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
                return false;
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
