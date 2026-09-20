namespace JobApplication.Domain.Entities
{
    public class Recruiter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
