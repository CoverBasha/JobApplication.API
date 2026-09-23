using JobApplication.Application.DTOs.JobDtos;
using JobApplication.Application.Services;
using MediatR;

namespace JobApplication.Application.Features.Jobs.Commands
{
    public class CloseJobCommand : IRequest<ServiceResponse<JobDto>>
    {
        public Guid UserId { get; set; }
        public Guid JobId { get; set; }
    }
}
