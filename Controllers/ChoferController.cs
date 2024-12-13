using Microsoft.AspNetCore.Mvc;

namespace ExplicacionApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChoferController : ControllerBase
{
    // ChoferRepository repoChofer ;
    private IChoferRepository _repoChofer;
    public ChoferController(IChoferRepository repoChofer)
    {
        _repoChofer = repoChofer;
    }

    [HttpPost("api/crearChofer")]
    public ActionResult crearChofer([FromBody] CreateChoferVM c)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest("No se pudo crear el chofer");
        }
        Chofer chofer = new Chofer(c);
        var resultado = _repoChofer.crearChofer(chofer);

        if (resultado)
        {
            return Created();
        }
        else return BadRequest("No se pudo crear el chofer");
    }
    [HttpGet("api/ListarChoferes")]
    public ActionResult<List<ReadChoferVM>> ListarChoferes()
    {
        List<ReadChoferVM> choferes = ListarChoferVM();
        return Ok(choferes);
    }



    private List<ReadChoferVM> ListarChoferVM()
    {
        List<ReadChoferVM> choferes = new List<ReadChoferVM>();

        foreach (var c in _repoChofer.ListarChoferes())
        {
            ReadChoferVM cvm = new ReadChoferVM(c);
            choferes.Add(cvm);
        }

        return choferes;
    }

    [HttpGet("api/buscarChofer/{id}")]
    public ActionResult<Chofer> BuscarChofer(int id)
    {

        Chofer c = _repoChofer.BuscarChofer(id);
        if (c is not null)
        {
            return Ok(c);
        }
        else return NotFound("No se encontro el recurso");
    }

    [HttpDelete("api/EliminarChofer{id}")]
    public ActionResult EliminarChofer(int id)
    {
        var resultado = _repoChofer.EliminarChofer(id);
        if (!resultado) return BadRequest("No se encontro el chofer");
        return Ok("Se elimino correctamente");
    }

    [HttpPut("api/ModificarChofer/{id}")]
    public ActionResult<Chofer> ModificarChofer([FromBody] UpdateChoferVM cvm, int id)
    {
        Chofer c = new Chofer(cvm);
        Chofer chofer = _repoChofer.ModificarChofer(c, id);
        if (chofer is null) return NotFound();
        return Ok(chofer);
    }


    [HttpPost("api/AsignarCalificacion{id}")]
    public ActionResult<Chofer> AsignarCalificacion(int id, [FromBody] AsignarCalificacionVM calificacionVM)
    {
        Calificacion calificacion = new Calificacion(calificacionVM);
        Chofer chofer = _repoChofer.AsignarCalifiacion(id, calificacion);
        if (chofer is null) return NotFound("No se encontro el recurso");
        return Ok(chofer);

    }

    [HttpGet("api/GetPromedio/{id}")]
    public ActionResult<double> GetPromedio(int id)
    {

        return Ok(_repoChofer.promedioCalificacion(id));
    }

    [HttpGet("api/GetCantidad/{id}")]
    public ActionResult<int> GetCantidad(int id)
    {
        return Ok(_repoChofer.cant_Calificacion(id));
    }


}
