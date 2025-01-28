using API.Exemple.Core._08.Infrastructure.Integration.ExternalEmail.Model;
using API.Exemple.Core._08.Infrastructure.Integration.ExternalEmail.Service;
using Common.Core._08.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Exemple.Core._08.Controllers.External.ExternalEmail;

/// <summary>
/// Controlador responsável por demonstrar o consumo de APIs externas.
/// Este exemplo contém endpoints para envio e listagem de mensagens utilizando um serviço externo.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ExternalEmailController : ControllerBase
{
    private readonly IExternalEmailService _emailService;

    /// <summary>
    /// Construtor do controlador. Recebe o serviço de e-mail injetado via DI.
    /// </summary>
    /// <param name="emailService">Serviço para comunicação com a API externa de e-mails.</param>
    public ExternalEmailController(IExternalEmailService emailService)
    {
        _emailService = emailService;
    }

    /// <summary>
    /// Envia uma mensagem utilizando o serviço externo.
    /// </summary>
    /// <param name="request">Dados da mensagem a ser enviada, incluindo autenticação e detalhes do destinatário.</param>
    /// <returns>
    /// Retorna os detalhes do envio em caso de sucesso ou uma mensagem de erro em caso de falha.
    /// </returns>
    /// <response code="200">Envio realizado com sucesso.</response>
    /// <response code="500">Erro ao processar a solicitação.</response>
    [HttpPost()]
    [ProducesResponseType(typeof(ApiResponse<List<CreateSendResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SendEmail([FromBody] CreateSendRequest request)
    {
        try
        {
            // Chama o serviço para enviar a mensagem.
            var response = await _emailService.SendMessageAsync(request);

            // Retorna os detalhes do envio em caso de sucesso.
            return Ok(response);
        }
        catch (Exception ex)
        {
            // Retorna um erro genérico com o status 500.
            return StatusCode(500, new { ex.Message });
        }
    }

    /// <summary>
    /// Lista as mensagens enviadas utilizando o serviço externo.
    /// </summary>
    /// <returns>
    /// Retorna uma lista de mensagens enviadas com seus respectivos detalhes.
    /// </returns>
    /// <response code="200">Listagem realizada com sucesso.</response>
    /// <response code="500">Erro ao processar a solicitação.</response>
    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<List<ListSendResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetListSend()
    {
        try
        {
            // Chama o serviço para obter a lista de mensagens enviadas.
            var result = await _emailService.GetListSendAsync();

            // Retorna a lista de mensagens em caso de sucesso.
            return Ok(result);
        }
        catch (Exception ex)
        {
            // Retorna um erro genérico com o status 500.
            return StatusCode(500, new { ex.Message });
        }
    }
}
