using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    // Örnek veri listesi (bellekte tutuluyor, kalıcı değil)
    private static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Ali", Email="dddddd" },
        new User { Id = 2, Name = "Ayşe", Email="kjshdjkwhj" }
    };

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Users);
    }

    [HttpPost]
    public IActionResult Post([FromBody] User newUser)
    {
        newUser.Id = Users.Count + 1; // basit id ataması
        Users.Add(newUser);
        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }

}

// Model sınıfı