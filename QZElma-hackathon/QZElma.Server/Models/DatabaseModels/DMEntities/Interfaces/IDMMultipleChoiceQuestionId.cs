using QZElma.Server.Models.Database.DBEntities;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Идентификатор вопроса с несколькими вариантами ответа
    /// </summary>
    public interface IDMMultipleChoiceQuestionId :
        IDMIdEntity,
        IDMSelectable<DMMultipleChoiceQuestionId, MultipleChoiceQuestion>
    {
    }
}
