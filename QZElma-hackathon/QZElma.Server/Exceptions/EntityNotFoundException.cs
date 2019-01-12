using QZElma.Server.Localization;
using System;


namespace QZElma.Server.Exceptions
{
    /// <summary>
    /// Исключение, которое вызывается если сущность не была найдена в базе данных или в индексе.
    /// </summary>
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
            : base()
        { }

        public EntityNotFoundException(string message)
            : base(message)
        { }

        public EntityNotFoundException(string message, Exception inner)
            : base(message, inner)
        { }

        protected EntityNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="type">Тип сущности</param>
        /// <param name="id">Id сущности</param>
        public EntityNotFoundException(Type type, Guid id)
            : base(SR.T("Сущность типа {0} c Id = {1} не найдена!", type, id))
        { }
    }
}
