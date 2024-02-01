using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("projects")]
public class ProjectController : ControllerBase
{
    private readonly ProjectDbContext _projectDbContext;

    public ProjectController(ProjectDbContext projectDbContext)
    {
        _projectDbContext = projectDbContext;
    }

    [HttpGet("")]
    public async Task<ActionResult<Project>> Get()
    {
        var project = await _projectDbContext.Project.ToListAsync();

        if (project.Count == 0)
        {
            return NoContent();
        }
        
        return Ok(project);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> Get(int id)
    {
        var project = await _projectDbContext.Project.FindAsync(id);
        
        if (project == null)
        {
            return NotFound();
        }
        
        return Ok(project);
    }

    [HttpPost("")]
    public async Task<ActionResult<Project>> Create(Project project)
    {
        _projectDbContext.Project.Add(project);
        
        try
        {
            await _projectDbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return BadRequest();
        }
        
        return CreatedAtAction(nameof(Get), new {id = project.Id}, project);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Project project)
    {
        if (id != project.Id)
        {
            return NotFound();
        }

        _projectDbContext.Entry(project).State = EntityState.Modified;
        
        try
        {
            await _projectDbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return BadRequest();
        }

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var project = await _projectDbContext.Project.FindAsync(id);

        if (project == null)
        {
            return NotFound(); 
        }

        _projectDbContext.Project.Remove(project);
        await _projectDbContext.SaveChangesAsync();

        return NoContent();
    }
}