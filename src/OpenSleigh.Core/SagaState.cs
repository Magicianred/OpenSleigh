﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using OpenSleigh.Core.Messaging;

namespace OpenSleigh.Core
{
    //TODO: get rid of Newtonsoft.JSON dependency
    public abstract class SagaState
    {
        [JsonProperty]
        private readonly Dictionary<Guid, IMessage> _processedMessages = new();

        [JsonProperty] private bool _isComplete;
        
        protected SagaState(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public void SetAsProcessed<TM>(TM message) where TM : IMessage
        {
            if (message == null) 
                throw new ArgumentNullException(nameof(message));

            if (this.Id != message.CorrelationId)
                throw new ArgumentException($"invalid message correlation id", nameof(message));
            
            _processedMessages.Add(message.Id, message);
        }

        public bool CheckWasProcessed<TM>(TM message) where TM : IMessage
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            return _processedMessages.ContainsKey(message.Id);
        }

        public bool IsCompleted() => _isComplete;

        public void MarkAsCompleted() => _isComplete = true;
    }
}