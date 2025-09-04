namespace DTO
{
    /// <summary>
    /// Modelo de respuesta estándar para todas las operaciones de la API
    /// Proporciona una estructura consistente para las respuestas HTTP
    /// </summary>
    /// <param name="message">Mensaje descriptivo del resultado de la operación</param>
    /// <param name="success">Indica si la operación fue exitosa</param>
    /// <param name="result">Datos resultantes de la operación (puede ser null)</param>
    /// <param name="statusCode">Código de estado HTTP correspondiente</param>
    public class ResponseModel(string message, Boolean success, object? result, int statusCode)
    {
        /// <summary>
        /// Mensaje descriptivo del resultado de la operación
        /// </summary>
        /// <example>Operación completada exitosamente</example>
        public string? message { get; set; } = message;

        /// <summary>
        /// Indica si la operación fue exitosa
        /// </summary>
        /// <example>true</example>
        public Boolean success { get; set; } = success;

        /// <summary>
        /// Datos resultantes de la operación
        /// </summary>
        public object? result { get; set; } = result;

        /// <summary>
        /// Código de estado HTTP correspondiente
        /// </summary>
        /// <example>200</example>
        public int statusCode { get; set; } = statusCode;
    }
}
