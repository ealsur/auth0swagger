using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

[Authorize]
public class UserController : Controller
{
    private readonly IAuth0SwaggerSampleAPI _api;
    public UserController(){
        
    }

    
    public async Task<IActionResult> List()
    {
        var auth = new Microsoft.Rest.TokenCredentials(User.Claims.First(x=>x.Type == "id_token").Value);
        var api = new Auth0SwaggerSampleAPI(new Uri("http://localhost:5000"), auth); 
        return View(await api.ValuesGetAsync());
    }

}
