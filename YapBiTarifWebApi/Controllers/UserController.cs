﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YapBiTarifWebApi.Helpers;
using YapBiTarifWebApi.Models;

namespace YapBiTarifWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> Get()
        {
            return await _context.UserModels.ToListAsync();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(UserModel),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(long id) {
            var user = await _context.UserModels.FindAsync(id);
            return user == null ? NotFound() : Ok(user);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(UserModel user, int accountTypeId)
        {
            var accountType = await _context.AccountTypeModels.FindAsync(accountTypeId);

            if (accountType == null) return BadRequest();
            else
            {
                user.AccountType = accountType;
            }


            await _context.UserModels.AddAsync(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }


        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, UserModel user)
        {
            if (id != user.Id) return BadRequest();

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var userToDelete = await _context.UserModels.FindAsync(id);
            if (userToDelete == null) return NotFound();


            _context.UserModels.Remove(userToDelete);
            await _context.SaveChangesAsync();


            return NoContent();

        }


    }
}