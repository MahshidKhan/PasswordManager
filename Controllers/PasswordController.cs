using Microsoft.AspNetCore.Mvc;
using PasswordManagerAPI.Interfaces;
using PasswordManagerAPI.DTOs;

namespace PasswordManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;

        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        // GET: api/password
        [HttpGet]
        public async Task<IActionResult> GetAllPasswords()
        {
            try
            {
                var passwords = await _passwordService.GetAllPasswordsAsync();
                return Ok(passwords);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        // GET: api/password/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPasswordById(int id)
        {
            try
            {
                var password = await _passwordService.GetPasswordByIdAsync(id);
                if (password == null)
                    return NotFound(new { message = $"Password with ID {id} not found" });

                return Ok(password);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        // GET: api/password/5/decrypted
        [HttpGet("{id}/decrypted")]
        public async Task<IActionResult> GetPasswordWithDecrypted(int id)
        {
            try
            {
                var password = await _passwordService.GetPasswordWithDecryptedAsync(id);
                if (password == null)
                    return NotFound(new { message = $"Password with ID {id} not found" });

                return Ok(password);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to decrypt password", error = ex.Message });
            }
        }

        // POST: api/password
        [HttpPost]
        public async Task<IActionResult> CreatePassword([FromBody] PasswordCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var password = await _passwordService.AddPasswordAsync(request);
                return CreatedAtAction(nameof(GetPasswordById), new { id = password.Id }, password);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to create password", error = ex.Message });
            }
        }

        // PUT: api/password/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePassword(int id, [FromBody] PasswordUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var password = await _passwordService.UpdatePasswordAsync(id, request);
                if (password == null)
                    return NotFound(new { message = $"Password with ID {id} not found" });

                return Ok(password);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to update password", error = ex.Message });
            }
        }

        // DELETE: api/password/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassword(int id)
        {
            try
            {
                var success = await _passwordService.DeletePasswordAsync(id);
                if (!success)
                    return NotFound(new { message = $"Password with ID {id} not found" });

                return Ok(new { message = "Password deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to delete password", error = ex.Message });
            }
        }
    }
}