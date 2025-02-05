using Common.Core._08.Response;

namespace API.Exemple.Core._08.Feature.Exemple.Create;


public class CreateExempleResponse : BaseResponse
{
    public CreateExempleResponse(Guid id) => Id = id;

    public Guid Id { get; }
}

