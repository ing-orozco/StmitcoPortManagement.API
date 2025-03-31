using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortManagement.Application.DTOs;
using PortManagement.Application.Interfaces;
using PortManagement.Application.Services;
using PortManagement.Domain.Entities;

[Authorize]
[Route("api/buques")]
[ApiController]
public class BuquesController : ControllerBase
{
    private readonly IBuqueService _buqueService;

    public BuquesController(IBuqueService buqueService)
    {
        _buqueService = buqueService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {

            var buques = await _buqueService.GetAllAsync();
            return Ok(new ResponseDto<IEnumerable<Buques>>
            {
                Code = 200,
                Message = "Lista de buques obtenida correctamente.",
                Data = buques
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseDto<object>
            {
                Code = 500,
                Message = "Error al obtener la lista de buques.",
                Data = ex.Message
            });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var buque = await _buqueService.GetByIdAsync(id);
            if (buque == null)
            {
                return NotFound(new ResponseDto<object>
                {
                    Code = 404,
                    Message = $"No se encontró el buque con ID {id}.",
                    Data = null
                });
            }

            return Ok(new ResponseDto<Buques>
            {
                Code = 200,
                Message = "Buque obtenido correctamente.",
                Data = buque
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseDto<object>
            {
                Code = 500,
                Message = "Error al obtener el buque.",
                Data = ex.Message
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Buques buque)
    {
        if (buque == null)
        {
            return BadRequest(new ResponseDto<object>
            {
                Code = 400,
                Message = "El objeto buque no puede ser nulo.",
                Data = null
            });
        }

        try
        {
            await _buqueService.AddAsync(buque);
            return CreatedAtAction(nameof(GetById), new { id = buque.Id }, new ResponseDto<Buques>
            {
                Code = 201,
                Message = "Buque creado exitosamente.",
                Data = buque
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseDto<object>
            {
                Code = 500,
                Message = "Error al crear el Buque.",
                Data = ex.Message
            });
        }
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Buques buque)
    {
        if (buque == null || id != buque.Id)
        {
            return BadRequest(new ResponseDto<object>
            {
                Code = 400,
                Message = "ID inválido o datos incorrectos.",
                Data = null
            });
        }

        try
        {
            var existeBuque = await _buqueService.GetByIdAsync(id);
            if (existeBuque == null)
            {
                return NotFound(new ResponseDto<object>
                {
                    Code = 404,
                    Message = $"No se encontró el buque con ID {id}.",
                    Data = null
                });
            }

            await _buqueService.UpdateAsync(buque);
            return Ok(new ResponseDto<Buques>
            {
                Code = 200,
                Message = "Buque actualizado correctamente.",
                Data = buque
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseDto<object>
            {
                Code = 500,
                Message = "Error al actualizar el buque.",
                Data = ex.Message
            });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var buque = await _buqueService.GetByIdAsync(id);
            if (buque == null)
            {
                return NotFound(new ResponseDto<object>
                {
                    Code = 404,
                    Message = $"No se encontró el buque con ID {id}.",
                    Data = null
                });
            }

            await _buqueService.DeleteAsync(id);
            return Ok(new ResponseDto<object>
            {
                Code = 200,
                Message = "Buque eliminado correctamente.",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseDto<object>
            {
                Code = 500,
                Message = "Error al eliminar el buque.",
                Data = ex.Message
            });
        }
    }

}
