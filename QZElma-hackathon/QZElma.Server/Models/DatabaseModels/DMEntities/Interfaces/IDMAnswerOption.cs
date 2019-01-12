namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Варианта ответа
    /// </summary>
    public interface IDMAnswerOption :
        IDMIdEntity
    {
        /// <summary>
        /// Текст варианта ответа
        /// </summary>
        string Text { get; set; }
    }
}
