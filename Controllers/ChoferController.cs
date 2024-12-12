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
    [HttpGet]
    public ActionResult<List<Chofer>> ListarChoferes(){
        
        if (repoChofer.ListarChoferes().Count>0)
        {
            return Ok(repoChofer.ListarChoferes());
        }
        else return NoContent();
    }


    [HttpGet("{id}")]
    public ActionResult<Chofer> BuscarChofer(int id){
        
        Chofer c = repoChofer.BuscarChofer(id);
        if (c is not null)
        {
            return Ok(c);  
        }
        else return NotFound("No se encontro el recurso");
    }
    
    [HttpDelete("{id}")]
    public ActionResult EliminarChofer(int id){
        
        var resultado = repoChofer.EliminarChofer(id);
        if(!resultado) return BadRequest("No se encontro el chofer") ;
        return Ok("Se elimino correctamente");
    }
    [HttpPut("{id}")]
    public ActionResult<Chofer> ModificarChofer([FromBody] Chofer c, int id){
        Chofer chofer = repoChofer.ModificarChofer(c , id);
        if (chofer is null) return NotFound();
        return Ok(chofer);
    
        
    }

}
