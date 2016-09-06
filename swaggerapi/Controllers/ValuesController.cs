using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("values")]
[Produces("application/json")]
public class ValuesController : Controller
{
    private readonly IRepository _repository;
    public ValuesController(IRepository repository){
        _repository = repository;
    }

    /// <summary>
    /// Returns a collection of MyModel items
    /// </summary>
    /// <returns>Returns a collection of MyModel items</returns>
    /// <response code="200">Returns a collection of MyModel items</response>
    [Authorize]
    [HttpGet("")]
    [Produces("application/json", Type = typeof(IEnumerable<MyModel>))]
    [ProducesResponseType(typeof(IEnumerable<MyModel>), 200)]
    public IActionResult GetAll()
    {
        return new ObjectResult(_repository.GetAll());
    } 

    /// <summary>
    /// Returns a specific MyModel item 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Returns specific MyModel item</returns>
    /// <response code="200">Returns specific MyModel item</response>
    /// <response code="404">If the MyModel item is null</response>
    [HttpGet("{id}", Name = "GetModel")]
    [Produces(typeof(MyModel))]
    [ProducesResponseType(typeof(MyModel), 200)]
    [ProducesResponseType(typeof(MyModel), 404)]
    public IActionResult  Get(string id)
    {
        return new ObjectResult(_repository.Get(id));
    } 

    /// <summary>
    /// Creates a MyModel item
    /// </summary>
    /// <param name="item">An item to create</param>
    /// <returns>new created MyModel item</returns>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [Authorize]
    [HttpPost]
    [Produces(typeof(MyModel))]
    [ProducesResponseType(typeof(MyModel), 201)]
    [ProducesResponseType(typeof(MyModel), 400)]
    public IActionResult Create([FromBody] MyModel item)
    {
        if (item == null)
        {
            return BadRequest();
        }
        _repository.Add(item);
        return CreatedAtRoute("GetModel", new { id = item.Id }, item);
    }

    /// <summary>
    /// Updates a specific MyModel item
    /// </summary>
    /// <param name="id">The id of the instance</param>
    /// <param name="item">An instance of MyModel</param>
    /// <returns></returns>
    /// <response code="204">Returns when item was updated</response>
    [Authorize]
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(MyModel), 204)]
    public IActionResult Update(string id, [FromBody] MyModel item)
    {
        _repository.Edit(id, item);
        return NoContent();
    } 

    /// <summary>
    /// Updates a specific MyModel item
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="204">Returns when item was updated</response>
    [Authorize]
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(MyModel), 204)]
    public IActionResult Delete(string id)
    {
        _repository.Delete(id);
        return NoContent();
    } 
}