using Amazon.Runtime.Internal.Util;
using ApplicationPublication.Common.BusinessLayer;
using ApplicationPublication.Common.Repository;
using ApplicationPublication.Dto;
using ApplicationTheather.Common.Interfaces.IRepository;
using AutoMapper;
using Domain.Entity.publicationEntity;
using Domain.Enum;
using Domain.ServiceResponse;
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
        public async Task<ServiceResponse<PublicationDto>> CreatePublication(AddPublicationDto pub)
        {
            ServiceResponse<PublicationDto> response = new();
            try
            {
                Publication mapped= _mapper.Map<Publication>(pub);
                mapped.UpdatedDate=DateTime.Now;
                mapped.CreatedDate=DateTime.Now;
                await _publicationRepository.Insert(mapped);
                //----
                response.Success = true;
                response.Errortype = Errortype.Good;
           
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
                response.Success = false;
                response.Message = $"operation unSucess : {ex.Message}";
                response.Errortype = Errortype.Bad;
            }
            return response;

        }
        /// <summary>
        /// supprimer une publication par Id
        /// </summary>
        /// <param name="pubId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<PublicationDto>> DeletePublication(string pubId)
        {
            ServiceResponse<PublicationDto> response = new();
            try
            {
                Publication getPub = await _publicationRepository.GetById(pubId) ?? throw new NullReferenceException();
              
                   _= _publicationRepository.Delete(pubId);

                response.Success = true;
                response.Errortype = Errortype.Good;

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
                response.Success = false;
                response.Message = $"operation unSucess : {ex.Message}";
                response.Errortype = Errortype.Bad;
            }
            return response ;
        }
        /// <summary>
        /// récu^pére toutes les publication 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<IEnumerable<PublicationDto>>> GetAllbyPublicationByUserId(string userId)
        {
            ServiceResponse<IEnumerable<PublicationDto>>response = new();
            try
            {
                IEnumerable<Publication> getPub = await _publicationRepository.GetAllPublicationByUserId(userId) 
                                                                 ?? throw new NullReferenceException("no user found inside ") ;
                response.Data= _mapper.Map<IEnumerable<PublicationDto>>(getPub);
                response.Success = true;
                response.Errortype = Errortype.Good;
                
                
            }

            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
                IEnumerable<PublicationDto> Empty = Enumerable.Empty<PublicationDto>();
              
            }//----
            return response;
        }
        /// <summary>
        /// récupére toutes les publications 
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<IEnumerable<PublicationDto>>> GetAllPublication()
        {
            ServiceResponse<IEnumerable<PublicationDto>> response = new();
            try
            { 
                
                response.Data =_mapper.Map<IEnumerable<PublicationDto>>(await _publicationRepository.GetAll());
                response.Success = true;
                response.Errortype = Errortype.Good;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
                response.Success = false;
                response.Message = $"operation unSucess : {ex.Message}";
                response.Errortype = Errortype.Bad;
            }
            return response;
        }
        /// <summary>
        /// récupére les publication par Id
        /// </summary>
        /// <param name="pubId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<PublicationDto>> GetPublicationById(string pubId)
        {
            ServiceResponse<PublicationDto> response = new();
            try
            {
               Publication getPublic = await _publicationRepository.GetById(pubId) 
                                             ?? throw new ArgumentException() ;
                if (string.IsNullOrEmpty(getPublic.Review))
                {
                    throw new ArgumentException() ;
                }
               
                    //----
                response.Data= _mapper.Map<PublicationDto>(getPublic);

                response.Success = true;
                response.Errortype = Errortype.Good;
            } 
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
                response.Success = false;
                response.Message = $"operation unSucess : {ex.Message}";
                response.Errortype = Errortype.Bad;
            }
            return response;
        }
        /// <summary>
        /// récupére toutes les publication lier a une piece 
        /// </summary>
        /// <param name="pieceId"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<IEnumerable<PublicationDto>>> GetPublicationByPiece(int pieceId)
        {
            ServiceResponse<IEnumerable<PublicationDto>> response = new();
            try
            {
                IEnumerable<Publication> Getpublication = await _publicationRepository.GetAllPublicationByPieceId(pieceId);
                response.Data= _mapper.Map<IEnumerable<PublicationDto>>(Getpublication);

                response.Success = true;
                response.Errortype = Errortype.Good;
              
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
                response.Success = false;
                response.Message = $"operation unSucess : {ex.Message}";
                response.Errortype = Errortype.Bad;
            }
            return response;
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

        public async Task<ServiceResponse<PublicationDto>> UpdatePublication(string pubId, string title, string content)
        {
            ServiceResponse<PublicationDto> response = new();
            try
            {
                Publication getPub = await _publicationRepository.GetById(pubId)
                                    ?? throw new NullReferenceException("null reference");
            
           
                    
                await _publicationRepository.UpdatePublicationContent(pubId ,title,content);
                response.Success = true;
                response.Errortype = Errortype.Good;

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now:dd/mm/yyyy} an error occured in creationPublication  {ex}");
                response.Success = false;
                response.Message = $"operation unSucess : {ex.Message}";
                response.Errortype = Errortype.Bad;
            }
            return response;
        }
        #endregion    
    }
}
