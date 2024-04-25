using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;   


public class ControllerCompanion : ControllerBase
{
    private readonly ICompanion _companionManager;

    public ControllerCompanion(ICompanion companionManager)
    {
        _companionManager = companionManager;
    }   

    [HttpGet("/api/carpool/search")]
    public List<Companion> SearchCompanions(string origin, string destination)
    {
        return _companionManager.SearchCompanions(origin, destination);
    }

    [HttpPost("/api/carpool/add")]
    public IActionResult AddCompanion([FromBody] Companion companion)
    {
        _companionManager.AddCompanion(companion);
        return Ok("Попутчик успешно добавлен");
    }


    [HttpDelete("/api/carpool/{id}")]
    public IActionResult DeleteCompanion(int id)
    {
        _companionManager.DeleteCompanion(id);
        return Ok("Попутчик успешно удален");
    }

}