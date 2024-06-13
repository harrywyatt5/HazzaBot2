using Amazon.Lambda.APIGatewayEvents;

namespace HazzaBot;

public class DiscordRequest
{
    private APIGatewayProxyRequest _internal;
    private bool _checkedSecurity;

    public DiscordRequest(APIGatewayProxyRequest request)
    {
        _internal = request;
        _checkedSecurity = false; 
    }

    public bool DoSecurityCheck()
    {
        return false;
    }

    public void ToInteraction()
    {
        
    }
}