using ApplicationPublication.Common.BusinessLayer;
using ApplicationPublication.Common.Repository;
using ApplicationPublication.Dto;
using AutoMapper;
using Domain.Entity.publicationEntity;
using InfraPublication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraPublication.BusinessLayer
{
    public class RepostBL : IRepostBL
    {
        private readonly IRepostRepository repostrepository;
        private readonly IMapper mapper;

        public RepostBL(IRepostRepository repostrepository, IMapper mapper)
        {
            this.repostrepository = repostrepository;
            this.mapper = mapper;
        }

        public async Task CreateAsync(RepostDto pub)
        {
            try
            {
                 if (pub != null)
                 {
                   Repost mappedRepost=mapper.Map<Repost>(pub);
                   mappedRepost.UpdatedDate = DateTime.Now;
                   mappedRepost.CreatedDate = DateTime.Now;
                   await repostrepository.Insert(mappedRepost);
                 }
            }
            catch (Exception)
            {

                throw;
            }
       
        }

        public async Task DeleteRePost(string repostId)
        {
            try
            {
                Repost doExist= await repostrepository.GetById(repostId) ?? throw new NullReferenceException("null reference");
                if (doExist != null)
                {
                    repostrepository.Delete(repostId);
                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task<IEnumerable<RepostDto>> GetAllRePostFromPostId(string PostId)
        {

            var doExist = await repostrepository.GetAll();
            return mapper.Map<IEnumerable<RepostDto>>(doExist);
        }

        public async Task<RepostDto> GetRePostById(string repostId)
        {
            try
            {
                  Repost doExist = await repostrepository.GetById(repostId) ?? throw new NullReferenceException("null reference");
                  return mapper.Map<RepostDto>(doExist);
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task UpdatePost(string repostId, RepostDto post)
        {
            try
            {
              Repost doExist = await repostrepository.GetById(repostId) ?? throw new NullReferenceException("null reference");
              if (doExist != null)
              {
                Repost mapped= mapper.Map<Repost>(post); 
                repostrepository.Update(repostId, mapped);
              }
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
