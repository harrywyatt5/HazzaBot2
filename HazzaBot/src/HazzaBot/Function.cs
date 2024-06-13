using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using HazzaBot.Exceptions;
using HazzaBot.Interfaces;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace HazzaBot;

public class Function
{
    private async Task<APIGatewayProxyResponse> _mainHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        return null;
    }
    
    private async Task<APIGatewayProxyResponse> _handleException(APIGatewayProxyRequest request, ILambdaContext context)
    {
        try
        {
            return await _mainHandler(request, context);
        }
        catch (ThrowableResponse e)
        {
            return await e.CreateResponseFromThrowable()
                .CreateResponse();
        }
        catch (Exception e)
        {
            // Display the error for debugging purposes
            context.Logger.LogLine(e.Message);
            
            return await ThrowableResponse
                .CreateGenericExceptionResponse(e.Message)
                .CreateResponse();
        }
    }
    
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        var response = await _handleException(request, context);
        
        // Put application/json in the headers
        response.Headers.Add("Content-Type", "application/json");
        
        return response;
    }
}