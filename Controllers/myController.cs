﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab.Models;
using lab.Storage;
using Serilog;

namespace lab.Controllers
{
    //
    [Route("api/[controller]")]
    [ApiController]
    public class myController : ControllerBase
    {
        private IStorage<myData> _memCache;

        public myController(IStorage<myData> memCache)
        {
            _memCache = memCache;
        }

        [HttpGet]
        public ActionResult<IEnumerable<myData>> Get()
        {
            return Ok(_memCache.All);
        }

        [HttpGet("{id}")]
        public ActionResult<myData> Get(Guid id)
        {
            if (!_memCache.Has(id)) return NotFound("No such");

            return Ok(_memCache[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] myData value)
        {
            var validationResult = value.Validate();
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            _memCache.Add(value);
            Log.Information("Adding information about serials");
            Log.Warning("Some warning");
            Log.Error("Here comes an error");
            Log.Information($"This information about serials have been added: {value}");
            return Ok($"{value.ToString()} has been added");
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] myData value)
        {
            if (!_memCache.Has(id)) return NotFound("No such");

            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var previousValue = _memCache[id];
            _memCache[id] = value;

            return Ok($"{previousValue.ToString()} has been updated to {value.ToString()}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_memCache.Has(id)) return NotFound("No such");

            var valueToRemove = _memCache[id];
            _memCache.RemoveAt(id);

            return Ok($"{valueToRemove.ToString()} has been removed");
        }
    }
    //ну правочка для нового коммита

}
