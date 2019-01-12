using DotNetCore.CAP;
using System;


namespace QZElma.Server.Models.Attributes
{
    /// <summary>
    /// Атрибут для подписки на сообщения.
    /// </summary>
    public class EventSubscribtion : CapSubscribeAttribute
    {
        public EventSubscribtion(Type type)
            : base(type.ToString())
        { }
    }
}
