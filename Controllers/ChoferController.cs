using Microsoft.AspNetCore.Mvc;

namespace ExplicacionApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChoferController : ControllerBase
{
    ChoferRepository repoChofer ;
    public ChoferController()
    {
        repoChofer = new ChoferRepository();
    }

    [HttpPost]
    public ActionResult crearChofer([FromBody] Chofer c ){
        
        var resultado = repoChofer.crearChofer(c);

        if (resultado)
        {
            return Created();
        }
        else return BadRequest("No se pudo crear el chofer");

    }
    
}
