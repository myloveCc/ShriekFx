﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shriek.Messages
{
    public interface IMessageProcessor : IDisposable
    {
        void Subscriber(Action<Message> handle);

        void Send<TMessage>(TMessage message) where TMessage : Message;
    }
}