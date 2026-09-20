using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplication.Domain.Entities
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsClosed { get; set; }
        public DateTime? ClosedAt { get; set; }

        ///////////////////////////////////
        ///Foriegn keys and navigation props
        ///////////////////////////////////

        [ForeignKey(nameof(Recruiter))]
        public Guid RecruiterId { get; set; }
        public Recruiter Recruiter { get; set; }

    }
}
