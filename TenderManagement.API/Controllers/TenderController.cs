using Microsoft.AspNetCore.Mvc;
using TenderManagement.Business.Repository.IRepository;
using TenderManagement.Models;

namespace TenderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly ITenderRepository _tenderRepository;
        public TenderController(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _tenderRepository.GetAll());
        }

        [HttpGet("{tenderId}")]
        public async Task<IActionResult> Get(Guid tenderId)
        {
            var tender = await _tenderRepository.Get(tenderId);
            if (tender == null)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(tender);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTenderDTO tenderObj)
        {
            var result = await _tenderRepository.Create(tenderObj);
            return Ok(result);
        }

        [HttpPut("{tenderId}")]
        public async Task<IActionResult> Update(Guid tenderId, [FromBody] UpdateTenderDTO tenderObj)
        {
            var result = await _tenderRepository.Update(tenderId, tenderObj);
            return Ok(result);
        }

        [HttpDelete("{tenderId}")]
        public async Task<IActionResult> Delete(Guid tenderId)
        {
            var result = await _tenderRepository.Delete(tenderId);
            return Ok(result);
        }
    }
}
