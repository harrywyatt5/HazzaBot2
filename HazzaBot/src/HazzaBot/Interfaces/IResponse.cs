using Amazon.Lambda.APIGatewayEvents;

namespace HazzaBot.Interfaces;

public interface IResponse
{
    public Task<APIGatewayProxyResponse> CreateResponse();
}