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
using BookStoreApp.API.Models;
using BookStoreApp.API.Models.Author;
using BookStoreApp.API.Repositories;
using BookStoreApp.API.Static;
using DL.EntityClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging.Configuration;
using SD.LLBLGen.Pro.ORMSupportClasses;
using QueryParameters = BookStoreApp.API.Models.QueryParameters;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly IDataAccessAdapter dataAccessAdapter;
        private readonly IAuthorsRepository authorsRepository;
        private readonly IMapper mapper;
        private readonly ILogger<AuthorsController> logger;

        public AuthorsController(IDataAccessAdapter dataAccessAdapter, IAuthorsRepository authorsRepository, IMapper mapper, ILogger<AuthorsController> logger)
        {
            this.authorsRepository = authorsRepository;
            this.mapper = mapper;
            this.logger = logger;
            this.dataAccessAdapter = dataAccessAdapter;
        }

        // GET: api/Authors/?startindex=0&pagesize=15
        [HttpGet]
        public async Task<ActionResult<VirtualiseResponse<AuthorReadOnlyDto>>> GetAuthors([FromQuery]QueryParameters queryParameters)
        {
            try
            {
                var authorDtos = await authorsRepository.GetAllAsync<AuthorReadOnlyDto>(queryParameters);

                //var authors = mapper.Map<IEnumerable<AuthorReadOnlyDto>>(await authorsRepository.GetAllAsync());

                if (authorDtos == null)
                {
                    return NotFound();
                }

                return Ok(authorDtos);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetAuthors)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/Authors/
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AuthorReadOnlyDto>>> GetAuthors()
        {
            try
            {
                var authors = await authorsRepository.GetAllAsync();
                var authorDtos = mapper.Map<IEnumerable<AuthorReadOnlyDto>>(authors);

                if (authorDtos == null)
                {
                    return NotFound();
                }

                return Ok(authorDtos);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error Performing GET in {nameof(GetAuthors)}");
                return StatusCode(500, Messages.Error500Message);
            }
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDetailsDto>> GetAuthor(int id)
        {
            try
            {
                var author = await authorsRepository.GetAuthorDetailsAsync(id);

                if (author == null)
                {
                    logger.LogWarning("Record not found: {nameof(GetAuthor)} - ID: {id}");
                    return NotFound();
                }
        
                var authorDto = mapper.Map<AuthorDetailsDto>(author);
                return Ok(authorDto);
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
                var author = mapper.Map<AuthorEntity>(authorDto);

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
