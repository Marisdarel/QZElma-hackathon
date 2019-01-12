namespace QZElma.Server.Models.Database.DBEntities.Interfaces
{
    /// <summary>
    /// Варианта ответа
    /// </summary>
    public interface IAnswerOption :
        IDBIdEntity
    {
        /// <summary>
        /// Текст варианта ответа
        /// </summary>
        string Text { get; set; }
    }
}
