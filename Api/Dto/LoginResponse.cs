namespace Api.Dto
{
    /// <summary>
    /// Respuesta de una validación de logueo
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Si la autenticación fue válida o no
        /// </summary>
        public bool Valid { get; set; }

        /// <summary>
        /// Token JWT generado para el usuario
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Inicializa con valores por defecto
        /// </summary>
        public LoginResponse()
        {
            Valid = false;
            Token = string.Empty;
        }
    }
}
