using Client.Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Client.Test.Protos.Permission;

namespace Client.Test.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PermissionController : ControllerBase
{
    private readonly PermissionClient _permissionClient;

    public PermissionController(PermissionClient permissionClient)
    {
        _permissionClient = permissionClient;
    }

    [HttpPost]
    public async Task<IActionResult> Check(PermissionDto model)
    {
        var result = await _permissionClient.CheckAsync(
            new Protos.CheckPermissionRequest { Id = model.Id, Role = model.Role
            });
        if (result.Success) {
            return Ok(result.Message);
        }else return BadRequest(result.Message);
    }
}