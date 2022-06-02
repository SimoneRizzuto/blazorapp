using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;
using BookStoreApp.API.Repositories;
using BookStoreApp.API.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging.Configuration;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsRepository authorsRepository;
        private readonly IMapper mapper;
        private readonly ILogger<AuthorsController> logger;

        public AuthorsController(IAuthorsRepository authorsRepository, IMapper mapper, ILogger<AuthorsController> logger)
        {
            this.authorsRepository = authorsRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorReadOnlyDto>>> GetAuthors()
        {
            try
            {
                var authors = mapper.Map<IEnumerable<AuthorReadOnlyDto>>(await authorsRepository.GetAllAsync());

                if (authors == null)
                {
                    return NotFound();
                }

                return Ok(authors);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Performing GET in {nameofGetAuthors}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDetailsDto>> GetAuthor(int id)
        {
            try
            {
                var author = authorsRepository.GetAuthorDetailsAsync(id);

                if (author == null)
                {
                    logger.LogWarning("Record not found: {nameof(GetAuthor)} - ID: {id}");
                    return NotFound();
                }
        
                return Ok(author);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Performing GET in {nameofGetAuthors}");
                return StatusCode(500, Messages.Error500Message);
            }
            
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutAuthor(int id, AuthorUpdateDto authorDto)
        {
            if (id != authorDto.Id)
            {
                return BadRequest();
            }

            var author = await authorsRepository.GetAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            mapper.Map(authorDto, author);

            try
            {
                authorsRepository.UpdateAsync(author);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await AuthorExists(id)) 
                {
                    return NotFound();
                }
                else
                {
                    logger.LogError(ex , $"Error performing GET in {nameof(PutAuthor)}");
                    return StatusCode(500, Messages.Error500Message);
                }
            }

            return NoContent();
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<AuthorCreateDto>> PostAuthor(AuthorCreateDto authorDto)
        {
            try
            {
                var author = mapper.Map<Author>(authorDto);

                if (author == null)
                {
                    return Problem("Entity set 'BookStoreDBContext.Authors'  is null.");
                }

                await authorsRepository.AddAsync(author);

                return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error performing POST in {nameof(PostAuthor)}", authorDto);
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var author = await authorsRepository.GetAsync(id);
                if (author == null)
                {
                    logger.LogWarning($"{nameof(Author)} record not found in {nameof(DeleteAuthor)} - ID: {id}");
                    return NotFound();
                }
                await authorsRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error performing DELETE in {nameof(DeleteAuthor)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        private async Task<bool> AuthorExists(int id)
        {
            return await authorsRepository.Exists(id);
        }
    }
}
