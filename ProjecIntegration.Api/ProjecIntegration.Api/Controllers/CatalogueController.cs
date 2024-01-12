using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.Application.DTO.catalogue;
using ProjecIntegration.Api.Application.DTO.representation;

namespace ProjecIntegration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        private readonly ICatalogueRepository _catalogueService;
        private readonly IMapper _mapper;
        public CatalogueController(ICatalogueRepository catalogueService,IMapper mapper) 
        {
            _catalogueService = catalogueService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogueDto>> GetbyId([FromBody] int id)
        {
            try
            {
                var entities = await _catalogueService.GetById(id);
                return Ok(entities);
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogueDto>>> GetAll()
        {
            try 
            {
                var entities = await _catalogueService.GetAll();
                return  Ok(entities);   
            }
            catch(Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CatalogueDto catalogue)
        {
            try 
            {
                if(catalogue == null)
                    throw new ArgumentNullException(nameof(catalogue));
                else
                {
                    var convertion = _mapper.Map<CatalogueDto, Catalogue>(catalogue);
                    _catalogueService.Insert(convertion);
                    return Ok();
                
                }
                
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CatalogueDto>> Update(int updtId, [FromBody] CatalogueDto Updtcatalogue)
        {
            try 
            { 
                if (Updtcatalogue == null)
                {
                    BadRequest();
                }
                var convertion = _mapper.Map<CatalogueDto, Catalogue>(Updtcatalogue);
                _catalogueService.Update(updtId,convertion);
                
                return Ok(_mapper.Map<Catalogue,CatalogueDto?>(await _catalogueService.GetById(updtId)));
            
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }

        [HttpPost("{id}/add-representation")]
        public async Task<ActionResult> AddRepresentation(int Catid, [FromBody] RepresentationDto Addrepresentation)
        {
            try 
            {

                if (Addrepresentation == null)
                {
                    BadRequest();
                }
                var conversion= _mapper.Map<RepresentationDto, Representation>(Addrepresentation);
                _catalogueService.AddRepresentation(Catid,conversion);
                return Ok();
                
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpDelete("{id}/delete-representation")]
        public async Task<ActionResult> DeleteRepresentation(int Catid, int representationid)
        {
            try 
            {
                _catalogueService.DeleteRepresentation(Catid, representationid);
                return Ok();
                
            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromBody]int id)
        {
            try 
            {
                var enti=await _catalogueService.GetById(id);
                _catalogueService.Delete(enti);
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(500, "");
            }
        }
    }
}
