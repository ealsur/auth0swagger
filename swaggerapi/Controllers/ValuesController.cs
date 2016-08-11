using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

[Route("values")]
public class ValuesController : Controller
{
    [HttpGet("public")]
    public IEnumerable<MyModel> Ping()
    {

        return new List<MyModel>(){
            
        };

    } 
}