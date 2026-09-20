namespace JobApplication.Domain.Entities
{
    public class Candidate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CVUrl { get; set; }
    }
}
