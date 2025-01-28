﻿using API.Exemple.Core._08.Infrastructure.Integration.ExternalEmail.Model;
using Refit;

namespace API.Exemple.Core._08.Infrastructure.Integration.ExternalEmail.Api;

public interface IExternalEmailApi
{
    [Post("/api/createsend")]
    Task<ApiResponse<CreateSendResponse>> SendMessageAsync([Body] CreateSendRequest request);

    [Get("/api/listsend")]
    Task<ApiResponse<List<ListSendResponse>>> GetListSendAsync();
}

