namespace API.Models
{
    public class CreateGameRequest
    {
        public string Name { get; set; }
        public IFormFile Cover { get; set; }
    }
}
