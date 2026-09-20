using JobApplication.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplication.Domain.Entities
{
    public class JobCandidateApplication
    {
        public Guid Id { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public DateTime AppliedAt { get; set; }


        ///////////////////////////////////
        //Foriegn keys and navigation props
        ///////////////////////////////////
        [ForeignKey(nameof(Candidate))]
        public Guid CandidateID { get; set; }
        [ForeignKey(nameof(Job))]
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public Candidate Candidate { get; set; }
    }
}
