using Common.Core._08.Response;

namespace API.Exemple.Core._08.Feature.Exemple.Update;

public class UpdateExempleResponse : BaseResponse
{
    public UpdateExempleResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
