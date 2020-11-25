﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTEC.Core.Models;
using PTEC.Core.Services;
using PTEC.WebApi.Models.Input;
using PTEC.WebApi.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTEC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfiliadosController : ControllerBase
    {
        private readonly IAfiliadoService _afiliadoService;
        public AfiliadosController(IAfiliadoService afiliadoService)
        {
            _afiliadoService = afiliadoService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(AfiliadoOutputDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                Afiliado afiliado = await _afiliadoService.GetAfiliadoByIdAsyc(Guid.Parse(id));
                AfiliadoOutputDto afiliadoOutputDto = new AfiliadoOutputDto();
                afiliadoOutputDto.Id = afiliado.Id;
                afiliadoOutputDto.Nombre = afiliado.Nombre;
                afiliadoOutputDto.Apellido = afiliado.Apellido;
                afiliadoOutputDto.NumeroDocumento = afiliado.NumeroDocumento;
                afiliadoOutputDto.FechaIngreso = afiliado.FechaIngreso;
                afiliadoOutputDto.Telefonos = new List<TelefonoOutputDto>();
                foreach(var tel in afiliado.Telefonos)
                {
                    afiliadoOutputDto.Telefonos.Add(new TelefonoOutputDto() { Numero = tel.Numero });
                }

                return Ok(afiliadoOutputDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AfiliadoOutputDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody]AfiliadoInputDto afiliadoInputDto)
        {
            try
            {
                Afiliado afiliadoNuevo = new Afiliado();
                afiliadoNuevo.Nombre = afiliadoInputDto.Nombre;
                afiliadoNuevo.Apellido = afiliadoInputDto.Apellido;
                afiliadoNuevo.NumeroDocumento = afiliadoInputDto.NumeroDocumento;
                afiliadoNuevo.Telefonos = new List<Telefono>();
                foreach(var item in afiliadoInputDto.Telefonos)
                {
                    afiliadoNuevo.Telefonos.Add(new Telefono() { Numero = item });
                }

                Afiliado afiliado = await _afiliadoService.AgregarAfiliadoAsync(afiliadoNuevo);
                AfiliadoOutputDto afiliadoOutputDto = new AfiliadoOutputDto();
                afiliadoOutputDto.Id = afiliado.Id;
                afiliadoOutputDto.Nombre = afiliado.Nombre;
                afiliadoOutputDto.Apellido = afiliado.Apellido;
                afiliadoOutputDto.NumeroDocumento = afiliado.NumeroDocumento;
                afiliadoOutputDto.FechaIngreso = afiliado.FechaIngreso;
                afiliadoOutputDto.Telefonos = new List<TelefonoOutputDto>();
                foreach (var tel in afiliado.Telefonos)
                {
                    afiliadoOutputDto.Telefonos.Add(new TelefonoOutputDto() { Numero = tel.Numero });
                }

                return Ok(afiliadoOutputDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
