using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Diseases.Commands.Delete
{
    public class DeleteDiseaseHandler(IDiseaseRepository repository) : IRequestHandler<DeleteDiseaseCommand, bool>
    {
        private readonly IDiseaseRepository _repository = repository;
        public async Task<bool> Handle(DeleteDiseaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteDisease(request.Id);
                Log.Information($"Disease with Id: {request.Id} was deleted");
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return false;
            }
        }
    }
}
