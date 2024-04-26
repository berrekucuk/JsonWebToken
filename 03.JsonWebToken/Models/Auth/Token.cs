namespace _03.JsonWebToken.Models.Auth
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime ExpireDate { get; set; } //Anahtarın ne kadar geçerli olacağı süreyi belirtir.
    }
}
