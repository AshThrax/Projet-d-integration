using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.DTO.representation;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentationController : ControllerBase
    {
        private readonly IRepresentationRepository _representationService;
        private readonly IMapper _mapper;
        public RepresentationController(IRepresentationRepository representationService, IMapper mapper) 
        { 
            _representationService = representationService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepresentationDto>>> GetAll() 
        {
            try
            {
                var entities = await _representationService.GetAll();
                return Ok(_mapper.Map<IEnumerable<Representation>,IEnumerable<RepresentationDto>>(entities));

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RepresentationDto>> GetById([FromBody] int id)
        {
            try
            {
                var entities = await _representationService.GetById(id);
                return Ok(_mapper.Map<Representation, RepresentationDto >(entities));
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
           
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RepresentationDto entity)
        {
            try
            {
                   if (entity == null)
                   { 
                        BadRequest();
                   }
                    var conversion = _mapper.Map<RepresentationDto,Representation>(entity);
                   _representationService.Insert(conversion);
                   return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
           
        }
        [HttpPut]
        public async Task<ActionResult> Update(int updtId,[FromBody] RepresentationDto entity)
        {
            try
            {
                if (entity == null)
                {
                    BadRequest();
                }
                var conversion = _mapper.Map<RepresentationDto, Representation>(entity);
                _representationService.Update(updtId, conversion);
                return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromBody] RepresentationDto entity)
        {
            try
            {
                var conversion = _mapper.Map<RepresentationDto, Representation>(entity);
                _representationService.Delete(conversion);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
          
        }
    }
}
