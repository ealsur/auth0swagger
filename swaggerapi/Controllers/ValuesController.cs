using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;

[Route("values")]
public class ValuesController : Controller
{
    private readonly IRepository _repository;
    public ValuesController(IRepository repository){
        _repository = repository;
    }

    [HttpGet("")]
    [Produces(typeof(IEnumerable<MyModel>))]
    [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(IEnumerable<MyModel>))]
    public IActionResult GetAll()
    {
        return new ObjectResult(_repository.GetAll());
    } 

    [HttpGet("{id}", Name = "GetModel")]
    [Produces(typeof(MyModel))]
    [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(MyModel))]
    public IActionResult  Get(string id)
    {
        return new ObjectResult(_repository.Get(id));
    } 

    [HttpPost]
    [Produces(typeof(MyModel))]
    [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(MyModel))]
    public IActionResult Create([FromBody] MyModel item)
    {
        if (item == null)
        {
            return BadRequest();
        }
        _repository.Add(item);
        return CreatedAtRoute("GetModel", new { id = item.Id }, item);
    }

    [HttpPut("{id}")]    
    public IActionResult Update(string id, [FromBody] MyModel item)
    {
        _repository.Edit(id, item);
        return NoContent();
    } 

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _repository.Delete(id);
        return NoContent();
    } 
}