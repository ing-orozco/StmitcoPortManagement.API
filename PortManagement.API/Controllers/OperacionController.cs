using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortManagement.Application.Interfaces;
using PortManagement.Domain.Entities;
using PortManagement.Application.DTOs;

namespace PortManagement.API.Controllers
{
    [Authorize]
    [Route("api/operaciones")]
    [ApiController]
    public class OperacionController : ControllerBase
    {
        private readonly IOperacionService _operacionService;

        public OperacionController(IOperacionService operacionService)
        {
            _operacionService = operacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var operaciones = await _operacionService.GetAllAsync();
                return Ok(new ResponseDto<IEnumerable<Operaciones>>
                {
                    Code = 200,
                    Message = "Lista de operaciones obtenida correctamente.",
                    Data = operaciones
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<object>
                {
                    Code = 500,
                    Message = "Error al obtener la lista de operaciones.",
                    Data = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var operacion = await _operacionService.GetByIdAsync(id);
                if (operacion == null)
                {
                    return NotFound(new ResponseDto<object>
                    {
                        Code = 404,
                        Message = $"No se encontró la operación con ID {id}.",
                        Data = null
                    });
                }

                return Ok(new ResponseDto<Operaciones>
                {
                    Code = 200,
                    Message = "Operación obtenida correctamente.",
                    Data = operacion
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<object>
                {
                    Code = 500,
                    Message = "Error al obtener la operación.",
                    Data = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Operaciones operacion)
        {
            if (operacion == null)
            {
                return BadRequest(new ResponseDto<object>
                {
                    Code = 400,
                    Message = "El objeto operación no puede ser nulo.",
                    Data = null
                });
            }

            try
            {
                await _operacionService.AddAsync(operacion);
                return CreatedAtAction(nameof(GetById), new { id = operacion.Id }, new ResponseDto<Operaciones>
                {
                    Code = 201,
                    Message = "Operación creada exitosamente.",
                    Data = operacion
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<object>
                {
                    Code = 500,
                    Message = "Error al crear la operación.",
                    Data = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Operaciones operacion)
        {
            if (operacion == null || id != operacion.Id)
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
                var existeOperacion = await _operacionService.GetByIdAsync(id);
                if (existeOperacion == null)
                {
                    return NotFound(new ResponseDto<object>
                    {
                        Code = 404,
                        Message = $"No se encontró la operación con ID {id}.",
                        Data = null
                    });
                }

                await _operacionService.UpdateAsync(operacion);
                return Ok(new ResponseDto<Operaciones>
                {
                    Code = 200,
                    Message = "Operación actualizada correctamente.",
                    Data = operacion
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<object>
                {
                    Code = 500,
                    Message = "Error al actualizar la operación.",
                    Data = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var operacion = await _operacionService.GetByIdAsync(id);
                if (operacion == null)
                {
                    return NotFound(new ResponseDto<object>
                    {
                        Code = 404,
                        Message = $"No se encontró la operación con ID {id}.",
                        Data = null
                    });
                }

                await _operacionService.DeleteAsync(id);
                return Ok(new ResponseDto<object>
                {
                    Code = 200,
                    Message = "Operación eliminada correctamente.",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<object>
                {
                    Code = 500,
                    Message = "Error al eliminar la operación.",
                    Data = ex.Message
                });
            }
        }
    }
}
