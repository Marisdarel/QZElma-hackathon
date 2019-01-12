namespace QZElma.Server.Localization
{
    /// <summary>
    /// Класс для локализации строк
    /// </summary>
    public class SR
    {
        /// <summary>
        /// Поиск локализованной строки, используется для пометки строки как локализуемой
        /// </summary>
        public static string T(string t)
        {
            return t;
        }

        /// <summary>
        /// Поиск локализованной строки с форматированием, используется для пометки строки как локализуемой
        /// </summary>
        public static string T(string t, params object[] parameters)
        {
            return string.Format(t, parameters);
        }

        /// <summary>
        /// Используется для пометки строки как локализуемой, не переводит ее
        /// </summary>
        public static string M(string t)
        {
            return t;
        }

    }
}
