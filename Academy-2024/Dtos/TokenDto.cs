namespace Academy_2024.Dtos
{
    public class TokenDto
    {
        public string Token { get; set; } = null!;

        public DateTimeOffset Expires { get; set; }
    }
}
