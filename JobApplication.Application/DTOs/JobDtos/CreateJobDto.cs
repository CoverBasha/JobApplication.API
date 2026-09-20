namespace JobApplication.Application.DTOs.JobDtos
{
    public class CreateJobDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
