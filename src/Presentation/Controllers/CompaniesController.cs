using Application.Commands.Companies;
using Application.Notifications;
using Application.Queries.Companies;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiExplorerSettings(GroupName = "v1", IgnoreApi = true)]
[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IPublisher _publisher;

    public CompaniesController(ISender sender, IPublisher publisher)
    {
        _sender = sender;
        _publisher = publisher;
    }

    /// <summary>
    /// Gets the list of all companies
    /// </summary>
    /// <returns>The companies list</returns>
    [HttpGet(Name = "GetCompanies")]
    public async Task<IActionResult> GetCompaniesAsync()
    {
        var companies = await _sender.Send(new GetCompaniesQuery(TrackChanges: false));

        return Ok(companies);
    }

    /// <summary>
    /// Get a company by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}", Name = "CompanyById")]
    public async Task<IActionResult> GetCompanyAsync(int id)
    {
        var company = await _sender.Send(new GetCompanyQuery(id, TrackChanges: false));

        return Ok(company);
    }

    /// <summary>
    /// Gets a collection of companies by their ids
    /// </summary>
    /// <remarks>Replace {companyIds} with a comma-delimited series of ints. 
    /// Swagger does not do this very well, so try testing in Postman.</remarks>
    /// <param name="ids"></param>
    /// <returns></returns>
    [HttpGet("collection/{ids}", Name = "CompanyCollection")]
    public async Task<IActionResult> GetCompanyCollectionAsync(string ids)
    {
        var companies = await _sender.Send(new GetCompaniesByIdsQuery(ids, TrackChanges: false));

        return Ok(companies);
    }


    /// <summary>
    /// Creates a newly created company
    /// </summary>
    /// <param name="companyToCreate"></param>
    /// <returns>A newly created company</returns>
    [HttpPost(Name = "CreateCompany")]
    public async Task<IActionResult> CreateCompanyAsync([FromBody] CompanyForCreationDto companyToCreate)
    {
        var company = await _sender.Send(new CreateCompanyCommand(companyToCreate));

        return CreatedAtRoute("CompanyById", new { companyId = company.Id }, company);
    }

    /// <summary>
    /// Creates new companies from a collection
    /// </summary>
    /// <param name="companyCollection"></param>
    /// <returns></returns>
    [HttpPost("collection")]
    public async Task<IActionResult> CreateCompanyCollectionAsync
        ([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
    {
        (IEnumerable<CompanyDto> companies, string ids) = await _sender.Send(new CreateCompanyCollectionCommand(companyCollection));

        return CreatedAtRoute("CompanyCollection", new { ids }, companies);
    }

    /// <summary>
    /// Updates an existing company
    /// </summary>
    /// <param name="id"></param>
    /// <param name="companyForUpdateDto"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCompanyAsync(int id, CompanyForUpdateDto companyForUpdateDto)
    {
        if (companyForUpdateDto is null)
            return BadRequest("CompanyForUpdateDto object is null");

        await _sender.Send(new UpdateCompanyCommand(id, companyForUpdateDto, TrackChanges: true));

        return NoContent();
    }

    /// <summary>
    /// Deletes an existing company
    /// </summary>
    /// <param name="companyId"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCompanyAsync(int companyId)
    {
        await _publisher.Publish(new CompanyDeletedNotification(companyId, TrackChanges: false));

        return NoContent();
    }

    /// <summary>
    /// Partially updates an existing company
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <returns></returns>
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> PartiallyUpdateCompanyAsync(int id, [FromBody] JsonPatchDocument<CompanyForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        (CompanyForUpdateDto companyToPatch, _) = await _sender.Send(new GetCompanyForPatchQuery(id, TrackChanges: false));

        patchDoc.ApplyTo(companyToPatch, ModelState);

        TryValidateModel(companyToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _sender.Send(new UpdateCompanyCommand(id, companyToPatch, TrackChanges: false));

        return NoContent();
    }

    /// <summary>
    /// Get available HTTP Verbs
    /// </summary>
    /// <returns></returns>
    [HttpOptions]
    public IActionResult GetOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, PATCH, DELETE");
        return Ok();
    }

}
