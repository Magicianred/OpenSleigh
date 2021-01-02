using System;
using OpenSleigh.Core;

namespace OpenSleigh.Transport.RabbitMQ.Tests.Unit
{
    public record DummyMessage(Guid Id, Guid CorrelationId) : ICommand
    {
        public static DummyMessage New() => new DummyMessage(Guid.NewGuid(), Guid.NewGuid());
    }
}