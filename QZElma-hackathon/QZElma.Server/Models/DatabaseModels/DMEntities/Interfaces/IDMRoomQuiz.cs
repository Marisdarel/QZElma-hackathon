using QZElma.Server.Models.Database.DBEntities;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Викторина комнаты проведения викторины
    /// </summary>
    public interface IDMRoomQuiz :
        IDMIdEntity,
        IDMSelectable<DMRoomQuiz, Room>
        IDMUpdatable<Room>
    {
        /// <summary>
        /// Викторина
        /// </summary>
        DMQuiz Quiz { get; set; }
    }
}
