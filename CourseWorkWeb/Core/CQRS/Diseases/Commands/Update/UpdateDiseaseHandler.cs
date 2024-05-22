using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Diseases.Commands.Update
{
    public class UpdateDiseaseHandler(IDiseaseRepository repository) : IRequestHandler<UpdateDiseaseCommand, bool>
    {
        private readonly IDiseaseRepository _repository = repository;
        public async Task<bool> Handle(UpdateDiseaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request.disease);
                await _repository.UpdateDisease(request.disease);
                Log.Information($"{request.disease} was updated successful");
                return true;
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex.Message);
                return false;
            }
        }
    }
}
