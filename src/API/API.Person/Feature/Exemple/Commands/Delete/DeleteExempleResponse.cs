using Common.Core._08.Response;

namespace API.Person.Feature.Exemple.Commands.Delete;

public class DeleteExempleResponse : BaseResponse
{
    public DeleteExempleResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
