using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Context;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/v1/events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var events = await _eventService.GetAllEventsAsync(true);

                if (events is null) return NoContent();

                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    title = "Unable to process your request.",
                    status = 500,
                    details = ex.Message,
                    timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var @event = await _eventService.GetEventByIdAsync(id, true);

                if (@event is null) return NotFound();

                return Ok(@event);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    title = "Unable to process your request.",
                    status = 500,
                    details = ex.Message,
                    timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                });
            }
        }

        [HttpGet("theme/{theme}")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            try
            {
                var @event = await _eventService.GetAllEventsByThemeAsync(theme, true);

                if (@event is null) return NoContent();

                return Ok(@event);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    title = "Unable to process your request.",
                    status = 500,
                    details = ex.Message,
                    timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event model)
        {
            try
            {
                var @event = await _eventService.AddEvent(model);

                if (@event is null) return BadRequest();

                return StatusCode(201, @event);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    title = "Unable to process your request.",
                    status = 500,
                    details = ex.Message,
                    timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Event model)
        {
            try
            {
                var @event = await _eventService.UpdateEvent(id, model);

                if (@event is null) return BadRequest();

                return Ok(@event);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    title = "Unable to process your request.",
                    status = 500,
                    details = ex.Message,
                    timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var @event = await _eventService.DeleteEvent(id);

                if (@event is null) return NotFound("The resquested event does not exist.");

                return Ok(@event);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    title = "Unable to process your request.",
                    status = 500,
                    details = ex.Message,
                    timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff")
                });
            }
        }
    }
}