using API.Exemple.Core._08.Infrastructure.Integration.ExternalEmail.Service;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.External.ExternalEmail.Get;

public class GetPaginateEmailQueryHandler : IRequestHandler<GetPaginateEmailQuery, ApiResult<GetPaginateEmailQueryResult>>
{
    private readonly IExternalEmailService _emailService;

    public GetPaginateEmailQueryHandler(IExternalEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task<ApiResult<GetPaginateEmailQueryResult>> Handle(GetPaginateEmailQuery request, CancellationToken cancellationToken)
    {
        // Recupera os registros e o total
        var registros = await _emailService.GetPaginatedItemsAsync(request);
        var totalRegistros = await _emailService.GetTotalCountAsync();

        // Calcula a quantidade de páginas
        var quantidadePaginas = request.CalculateTotalPages(totalRegistros);

        // Cria a resposta
        var response = new GetPaginateEmailQueryResult(
            total: totalRegistros,
            items: registros,
            quantidadePaginas: quantidadePaginas
        );

        return ApiResult<GetPaginateEmailQueryResult>.CreateSuccess(response, "Registros recuperados com sucesso.");
    }
}


