using System;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application
{
    public class EventService : IEventService
    {
        IGeneralRepository _generalRepository;
        IEventRepository _eventRepository;
        public EventService(IGeneralRepository generalRepository, IEventRepository eventRepository)
        {
            _generalRepository = generalRepository;
            _eventRepository = eventRepository;
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            var events = await _eventRepository.GetAllEventsAsync(includeSpeakers);

            if (events is null) return null;

            return events;
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            var events = await _eventRepository.GetAllEventsByThemeAsync(theme, includeSpeakers);

            if (events is null) return null;

            return events;
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            var @event = await _eventRepository.GetEventByIdAsync(eventId, includeSpeakers);

            if (@event is null) return null;

            return @event;
        }

        public async Task<Event> AddEvent(Event model)
        {
            _generalRepository.Add<Event>(model);

            if (!await _generalRepository.SaveChangesAsync()) return null;

            return model;
        }

        public async Task<Event> UpdateEvent(int eventId, Event model)
        {
            var @event = await _eventRepository.GetEventByIdAsync(eventId, false);

            if (@event is null) return null;

            model.Id = eventId;
            _generalRepository.Update(model);

            if (!await _generalRepository.SaveChangesAsync()) return null;

            return model;
        }

        public async Task<Event> DeleteEvent(int eventId)
        {
            var @event = await _eventRepository.GetEventByIdAsync(eventId, false);

            if (@event is null) return null;

            await _eventRepository.DeleteEventById(@event.Id);

            return @event;
        }
    }
}