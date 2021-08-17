using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Alerts.Models.Common;
using Alerts.Queries;
using Alerts.Repository.Contracts.System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alerts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IConfigurationsRepository _repo;
        private readonly IMediator _mediator;

        public ConfigurationsController(IConfigurationsRepository repo, IMediator mediator)
        {
            _repo = repo;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Configuration>>>> Get()
        {
            var query = new GetAllConfigurationsQuery();
            var response = await _mediator.Send(query);
            if (!response.Success || response.Data == null || response.Data.Count == 0)
            {
                return NotFound();
            }
            return Ok(response);
        }

        // GET: api/configurations/:id
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<ServiceResponse<Configuration>>> GetOneAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest();
            var query = new GetConfigurationQuery(id);
            var response = await _mediator.Send(query);
            return response.Success ? (ActionResult) Ok(response) : NotFound();
        }

        // POST: api/configurations
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Configuration>>> Post([FromBody] Configuration config)
        {
            if (config == null) return BadRequest();
            var response = await _repo.PostEntity(config);
            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        // PUT: api/configurations/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<Configuration>>> Put(string id, [FromBody] Configuration config)
        {
            if (string.IsNullOrWhiteSpace(id) || config == null) return BadRequest();
            var response = await _repo.PutEntity(id, config);
            if (!response.Success)
            {
                return NotFound();
            }
            return Ok(response);
        }

        // DELETE: api/configurations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest();
            bool response = await _repo.DeleteEntity(id);
            if(response == false)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}