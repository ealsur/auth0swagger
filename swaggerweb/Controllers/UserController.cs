using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

[Authorize]
public class UserController : Controller
{
    public async Task<IActionResult> List()
    {
	var auth = new Microsoft.Rest.TokenCredentials(User.Claims.First(x=>x.Type == "access_token").Value);
        var api = new Auth0SwaggerSampleAPI(new Uri("http://localhost:5000"), auth); 
        return View(await api.ValuesGetAsync());
    }

}
