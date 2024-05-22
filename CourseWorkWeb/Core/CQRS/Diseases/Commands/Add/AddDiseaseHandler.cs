using CourseWorkWeb.DAL.Interfaces;
using MediatR;
using Serilog;

namespace CourseWorkWeb.Core.CQRS.Diseases.Commands.Add
{
    public class AddDiseaseHandler(IDiseaseRepository repository) : IRequestHandler<AddDiseaseCommand, bool>
    {
        private readonly IDiseaseRepository _repository = repository;
        public async Task<bool> Handle(AddDiseaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request.disease);
                await _repository.InsertDisease(request.disease);
                Log.Information($"{request.disease} was added successful!");
                return true;
            }
            catch(ArgumentNullException ex)
            {
                Log.Error(ex.Message);
                return false;
            }
        }
    }
}
