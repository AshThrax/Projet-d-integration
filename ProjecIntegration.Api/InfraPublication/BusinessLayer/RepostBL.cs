using ApplciationPublication.Common.BusinessLayer;
using ApplciationPublication.Common.Repository;
using ApplciationPublication.Dto;
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
            if (pub != null)
            {
                var mapped=mapper.Map<RePost>(pub);
                repostrepository.Insert(mapped);
            }
        }

        public async Task DeleteRePost(string repostId)
        {
            var doExist= await repostrepository.GetById(repostId);
            if (doExist != null)
            {
               
                repostrepository.Delete(repostId);
            }
        }

        public async Task<IEnumerable<RepostDto>> GetAllRePostFromPostId(string PostId)
        {

            var doExist = await repostrepository.GetAll();
            return mapper.Map<IEnumerable<RepostDto>>(doExist);
        }

        public async Task<RepostDto> GetRePostById(string repostId)
        {

            var doExist = await repostrepository.GetById(repostId);
            return mapper.Map<RepostDto>(doExist);
        }

        public async Task UpdatePost(string repostId, RepostDto post)
        {
            var doExist = await repostrepository.GetById(repostId);
            if (doExist != null)
            {
                var mapped= mapper.Map<RePost>(post); 
                repostrepository.Update(repostId, mapped);
            }
        }
    }
}
