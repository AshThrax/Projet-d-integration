using ApplicationPublication.Dto;
using Domain.Entity.publicationEntity;
using Domain.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationPublication.Common.BusinessLayer
{
    public interface IPostBL
    {
        #region post
        /// <summary>
        /// supprime un poste sur  base de son identifiant
        /// </summary>
        /// <param name="postId">identifiant du post </param>
        /// <returns></returns>
        Task<ServiceResponse<PostDto>> DeletePost(string postId);
        /// <summary>
        /// récupère un poste par son identifiant 
        /// </summary>
        /// <param name="postId">identifiant du post a récuperer </param>
        /// <returns></returns>
        Task<ServiceResponse<PostDto>> GetPostById(string postId);
        /// <summary>
        /// retourne une liste de poste liée a une publication
        /// </summary>
        /// <param name="PubId">identifiant de la publication</param>
        /// <returns></returns>
        Task<ServiceResponse<IEnumerable<PostDto>>> GetAllPostFromPublicationId(string PubId);
        /// <summary>
        ///   mets a jours un object de type poste
        /// </summary>
        /// <param name="postId">identifiant du post</param>
        /// <param name="Content">contenue a mettre a jour</param>
        /// <returns></returns>
        Task<ServiceResponse<PostDto>> UpdatePost(string postId, string Content);
        /// <summary>
        ///    creer un object de type post
        /// </summary>
        /// <param name="publicationtid">identifiant de la publication</param>
        /// <param name="pub">object post provenant du client</param>
        /// <returns></returns>
        Task<ServiceResponse<PostDto>> CreateAsync(string publicationtid, AddPostDto pub);
        #endregion

        Task<ServiceResponse<IEnumerable<PostDto>>> GetPostFromUserId(string userId);
        Task<bool> IsAuthor(string postId, string userId);
    }
}
