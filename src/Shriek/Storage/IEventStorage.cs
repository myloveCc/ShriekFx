﻿using Shriek.Domains;
using Shriek.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Shriek.Storage.Mementos;

namespace Shriek.Storage
{
    public interface IEventStorage
    {
        IEnumerable<Event> GetEvents(Guid aggregateId);

        void SaveAggregateRoot<TAggregateRoot>(TAggregateRoot aggreagate) where TAggregateRoot : IAggregateRoot, IEventProvider;

        void Save<T>(T @event) where T : Event;
    }
}