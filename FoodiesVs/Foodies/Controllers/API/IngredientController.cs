using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Foodies.Data;
using Foodies.Models;
using Foodies.Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Foodies.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IngredientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public IngredientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Ingredient
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
        {
            return await _unitOfWork.IngredientRepository.GetAll().ToListAsync();
        }

        // GET: api/Ingredient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredient(int id)
        {
            Ingredient ingredient = await _unitOfWork.IngredientRepository.GetById(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return ingredient;
        }

        // PUT: api/Ingredient/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient(int id, Ingredient ingredient)
        {
            if (id != ingredient.IngredientId)
            {
                return BadRequest();
            }
            _unitOfWork.IngredientRepository.Update(ingredient);
            await _unitOfWork.Save();
            return NoContent();
        }

        // POST: api/Ingredient
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ingredient>> PostIngredient(Ingredient ingredient)
        {
            _unitOfWork.IngredientRepository.Create(ingredient);
            await _unitOfWork.Save();

            return CreatedAtAction("GetIngredient", new { id = ingredient.IngredientId }, ingredient);
        }

        // DELETE: api/Ingredient/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ingredient>> DeleteIngredient(int id)
        {
            Ingredient ingredient = await _unitOfWork.IngredientRepository.GetById(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            _unitOfWork.IngredientRepository.Delete(ingredient);
            await _unitOfWork.Save();

            return NoContent();
        }

        private bool IngredientExists(int id)
        {
            if (_unitOfWork.IngredientRepository.GetById(id) != null)
            {
                return true;
            }
            return false;            
        }
    }
}
