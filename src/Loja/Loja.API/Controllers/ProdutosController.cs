﻿using Loja.Domain.Estoque.Commands.Input;
using Loja.Domain.Estoque.Entities;
using Loja.Domain.Estoque.Handler;
using Loja.Domain.Estoque.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("v1/produtos")]
    public class ProdutosController : Controller
    {
        private readonly ILogger<ProdutosController> _logger;

        public ProdutosController(ILogger<ProdutosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromServices] IProdutoRepository _repo)
        {
            var result = _repo.ObterProdutos();
            return result is null ? (IActionResult)Ok(result) : NoContent();
        }
        
        [HttpPost]
        public IActionResult RegistrarProduto([FromServices] Handler handler, [FromBody] RegistrarProdutoCommand command)
        {
            var result = handler.Handle(command);

            return result.Success ? (IActionResult) Created(nameof(ObterProduto), result) : UnprocessableEntity(result);
        }

        [HttpPut]
        public IActionResult AtualizarProduto([FromServices] Handler handler, [FromBody] AtualizarProdutoCommand command)
        {
            var result = handler.Handle(command);
            return result.Success ? (IActionResult) Ok(result) : UnprocessableEntity(result);
        }

        [HttpDelete]
        public IActionResult AtualizarProduto([FromServices] Handler handler, [FromBody] ApagarProdutoCommand command)
        {
            var result = handler.Handle(command);
            return result.Success ? (IActionResult) Accepted(result) : BadRequest(result);
        }


        [HttpGet("{id}")]
        public IActionResult ObterProduto([FromServices]  IProdutoRepository _repo, long id)
        {
            var result =  _repo.ObterProdutoPorId(id);
            return result is null ? (IActionResult) Ok(result) : NoContent();
        }
    }
}
