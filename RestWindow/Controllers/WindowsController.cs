using Microsoft.AspNetCore.Mvc;
using RestWindow.Converters;
using RestWindow.DTOs;
using Windowlib;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWindow.Controllers
{
    [Route("api/windows")]
    [ApiController]
    public class WindowsController : ControllerBase
    {
        private readonly IWindowsRepository _repo;
        public WindowsController(IWindowsRepository repo)
        {
            _repo = repo;
        }

        // GET: api/windows
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            List<Window> windows = _repo.GetAll();
            if (windows.Count == 0)
            {
                return NoContent();
            }
            return Ok(windows);
        }

        // GET api/windows/5
        [HttpGet()]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Window? foundWindow = _repo.GetById(id);
            if (foundWindow is null)
            {
                return NotFound();
            }
            return Ok(foundWindow);


        }

        // POST api/<WindowsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] WindowDTO windowFromRequest)
        {
            try
            {
                Window addedWindow = _repo.Add(WindowConverter.DTO2Window(windowFromRequest));

                return Created("api/windows" + addedWindow.Id, addedWindow);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// PUT api/<WindowsController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] string value)
        //{
        //}

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            Window? deletedWindow = _repo.Delete(id);
            if (deletedWindow is null)
            {
                return NotFound();
            }
            return Ok(deletedWindow);
        }
    }
}
