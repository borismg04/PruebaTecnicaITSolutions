using DTO;

namespace Services
{
    /// <summary>
    /// Servicio base para crear respuestas estándar en la aplicación
    /// Proporciona métodos de utilidad para generar objetos de respuesta consistentes
    /// </summary>
    public class ResponseService
    {
        /// <summary>
        /// Crea un objeto de respuesta estándar con los parámetros especificados
        /// </summary>
        /// <param name="message">Mensaje descriptivo del resultado</param>
        /// <param name="response">Indica si la operación fue exitosa</param>
        /// <param name="info">Datos resultantes de la operación</param>
        /// <param name="statusCode">Código de estado HTTP</param>
        /// <returns>Objeto ResponseModel con la estructura estándar de respuesta</returns>
        public static ResponseModel CreateResult(string message, bool response, object? info, int statusCode)
        {
            return new ResponseModel(message, response, info, statusCode);
        }
    }
}
