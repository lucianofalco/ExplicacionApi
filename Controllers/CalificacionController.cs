using Microsoft.AspNetCore.Mvc;

namespace ExplicacionApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CalificacionController : ControllerBase
{
    CalifiacionRepository _repocalif ;
    public CalificacionController()
    {
        _repocalif = new CalifiacionRepository();
    }

    [HttpPost]
    public ActionResult crearCalificacion([FromBody] Calificacion calificacion ){
        
        var resultado = _repocalif.crearCalifiacion(calificacion);
        if (resultado)
        {
            return Created();
        }
        else return BadRequest("No se pudo crear la califiacion");
        
    }
    
}
