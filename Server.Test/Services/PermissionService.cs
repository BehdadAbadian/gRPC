using Grpc.Core;
using Server.Test.Protos;

namespace Server.Test.Services
{
    public class PermissionService : Permission.PermissionBase
    {
        public override Task<CheckPermissionRespond> Check(CheckPermissionRequest request, ServerCallContext context)
        {
            if (request.Role == "Admin") 
            {
                var respond = new CheckPermissionRespond { Success = true, Message = "Ok" };
                return Task.FromResult(respond);
            }
            else
            {
                var respond = new CheckPermissionRespond { Success = false, Message = "Not Ok" };
                return Task.FromResult(respond);
            }
            
        }
    }
}
