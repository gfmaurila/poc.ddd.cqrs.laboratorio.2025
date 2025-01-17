using Common.Core._08.Response;

namespace API.Exemple.Core._08.Feature.Exemple.Delete;

public class DeleteExempleResponse : BaseResponse
{
    public DeleteExempleResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
