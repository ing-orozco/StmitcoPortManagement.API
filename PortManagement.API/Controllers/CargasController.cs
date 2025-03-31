using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortManagement.Application.Interfaces;
using PortManagement.Domain.Entities;
using PortManagement.Application.DTOs;

namespace PortManagement.API.Controllers
{
    [Authorize]
    [Route("api/cargas")]
    [ApiController]
    public class CargasController : ControllerBase
    {
        private readonly ICargaService _cargaService;

        public CargasController(ICargaService cargaService)
        {
            _cargaService = cargaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cargas = await _cargaService.GetAllAsync();
                return Ok(new ResponseDto<IEnumerable<Cargas>>
                {
                    Code = 200,
                    Message = "Lista de cargas obtenida correctamente.",
                    Data = cargas
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<object>
                {
                    Code = 500,
                    Message = "Error al obtener la lista de cargas.",
                    Data = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var carga = await _cargaService.GetByIdAsync(id);
                if (carga == null)
                {
                    return NotFound(new ResponseDto<object>
                    {
                        Code = 404,
                        Message = $"No se encontró la carga con ID {id}.",
                        Data = null
                    });
                }

                return Ok(new ResponseDto<Cargas>
                {
                    Code = 200,
                    Message = "Carga obtenida correctamente.",
                    Data = carga
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<object>
                {
                    Code = 500,
                    Message = "Error al obtener la carga.",
                    Data = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cargas carga)
        {
            if (carga == null)
            {
                return BadRequest(new ResponseDto<object>
                {
                    Code = 400,
                    Message = "El objeto carga no puede ser nulo.",
                    Data = null
                });
            }

            try
            {
                await _cargaService.AddAsync(carga);
                return CreatedAtAction(nameof(GetById), new { id = carga.Id }, new ResponseDto<Cargas>
                {
                    Code = 201,
                    Message = "Carga creada exitosamente.",
                    Data = carga
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<object>
                {
                    Code = 500,
                    Message = "Error al crear la carga.",
                    Data = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cargas carga)
        {
            if (carga == null || id != carga.Id)
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
                var existeCarga = await _cargaService.GetByIdAsync(id);
                if (existeCarga == null)
                {
                    return NotFound(new ResponseDto<object>
                    {
                        Code = 404,
                        Message = $"No se encontró la carga con ID {id}.",
                        Data = null
                    });
                }

                await _cargaService.UpdateAsync(carga);
                return Ok(new ResponseDto<Cargas>
                {
                    Code = 200,
                    Message = "Carga actualizada correctamente.",
                    Data = carga
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<object>
                {
                    Code = 500,
                    Message = "Error al actualizar la carga.",
                    Data = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var carga = await _cargaService.GetByIdAsync(id);
                if (carga == null)
                {
                    return NotFound(new ResponseDto<object>
                    {
                        Code = 404,
                        Message = $"No se encontró la carga con ID {id}.",
                        Data = null
                    });
                }

                await _cargaService.DeleteAsync(id);
                return Ok(new ResponseDto<object>
                {
                    Code = 200,
                    Message = "Carga eliminada correctamente.",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto<object>
                {
                    Code = 500,
                    Message = "Error al eliminar la carga.",
                    Data = ex.Message
                });
            }
        }
    }
}
