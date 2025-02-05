using API.Exemple.Core._08.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple.Core._08.Feature.Exemple.GetPaginate;

public class GetPaginateExempleQueryHandler : IRequestHandler<GetPaginateExempleQuery, ApiResult<GetPaginateExempleQueryResult>>
{
    private readonly IExempleRepository _repo;

    public GetPaginateExempleQueryHandler(IExempleRepository repo)
    {
        _repo = repo;
    }

    public async Task<ApiResult<GetPaginateExempleQueryResult>> Handle(GetPaginateExempleQuery request, CancellationToken cancellationToken)
    {
        // Recupera os registros e o total
        var registros = await _repo.GetPaginatedItemsAsync(request);
        var totalRegistros = await _repo.GetTotalCountAsync(request);

        // Calcula a quantidade de páginas
        var quantidadePaginas = request.CalculateTotalPages(totalRegistros);

        // Cria a resposta
        var response = new GetPaginateExempleQueryResult(
            total: totalRegistros,
            items: registros,
            filtro: request.FiltroFirstName,
            quantidadePaginas: quantidadePaginas
        );

        return ApiResult<GetPaginateExempleQueryResult>.CreateSuccess(response, "Registros recuperados com sucesso.");
    }
}


