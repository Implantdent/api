namespace Api.Dto
{
    /// <summary>
    /// Solicitud de una validación de logueo
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Login del usuario
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Inicializa con valores por defecto
        /// </summary>
        public LoginRequest()
        {
            Login = string.Empty;
            Password = string.Empty;
        }
    }
}
