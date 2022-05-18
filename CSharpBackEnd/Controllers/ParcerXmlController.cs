using CSharpBackEnd.Helpers;
using CSharpBackEnd.Models;
using CSharpBackEnd.Models.Pagination;
using CSharpBackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpBackEnd.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ParcerXmlController : ControllerBase
    {
        private readonly IParcerXmlService _parcerXmlService;
        public ParcerXmlController(IParcerXmlService parcerXmlService) 
            => _parcerXmlService = parcerXmlService;

        [HttpGet]
        [Route("links")]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO model)
        {
            if (model == null)
                return BadRequest();
            try
            {
                var queryable = _parcerXmlService.GetLinks();

                if (queryable == null)
                    return NotFound();

                await HttpContext.InsertPaginationParametrInResponse(queryable, model.PageSize);
                var resultLinks = await queryable.Paginate(model).ToListAsync();
               
                return Ok(resultLinks);

            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id, [FromQuery] PaginationDTO model)
        {
            if (model == null)
                return BadRequest();
            try
            {
                var queryable = _parcerXmlService.GetParcedLinksById(id);

                if (queryable == null)
                    return NotFound();

                await HttpContext.InsertPaginationParametrInResponse(queryable, model.PageSize);
                var resultLinks = await queryable.Paginate(model).ToListAsync();

                return Ok(resultLinks);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Parce(LinkModel model)
        {
            if (model == null || String.IsNullOrEmpty(model.Link))
                return BadRequest();

            try
            {
                var parceList = await _parcerXmlService.ParceAsync(model.Link);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
