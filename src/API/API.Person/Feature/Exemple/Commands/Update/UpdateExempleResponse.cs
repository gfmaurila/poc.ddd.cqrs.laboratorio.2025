using Common.Core._08.Response;

namespace API.Person.Feature.Exemple.Commands.Update;

public class UpdateExempleResponse : BaseResponse
{
    public UpdateExempleResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
