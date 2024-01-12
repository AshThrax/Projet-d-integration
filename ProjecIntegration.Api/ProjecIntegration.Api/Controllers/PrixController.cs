using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.DTO.prix;
using ProjecIntegration.Api.Infrastructure.Service;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrixController : ControllerBase
    {
        private readonly IPrixRepository _prixService;
        private readonly IMapper _mapper;
        public PrixController(IPrixRepository prixService,IMapper mapper) 
        {
            _prixService = prixService;
            _mapper = mapper;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrixDto>> GetById([FromBody] int id)
        {
              try
              {
                var entities = await _prixService.GetById(id);
                return Ok(_mapper.Map<Prix,PrixDto>(entities));

              }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrixDto>>> GetAll()
        {
            try
            {
                var entities = await _prixService.GetAll();
                return Ok(_mapper.Map<IEnumerable<Prix>, 
                    IEnumerable<PrixDto>>(entities));
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PrixDto AddPrix)
        {
            try
            {
                if (AddPrix == null)
                {
                    BadRequest();
                }
                var conversion = _mapper.Map<PrixDto, Prix>(AddPrix);
                _prixService.Insert(conversion);
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpPut]
        public async Task<ActionResult> Update(int id,[FromBody] PrixDto updtPrix)
        {
            try
            {

                if (updtPrix == null)
                {
                    BadRequest();
                }

                var conversion = _mapper.Map<PrixDto, Prix>(updtPrix);
                _prixService.Update(id,conversion);
                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrixDto>> Delete([FromBody] PrixDto Deletedto)
        {
            try
            {
                var dto = _mapper.Map<PrixDto, Prix>(Deletedto);
                _prixService.Delete(dto);
                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
    }
}
