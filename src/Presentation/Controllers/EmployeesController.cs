﻿using Application.Commands.EmployeeCommands;
using Application.Queries.EmployeeQueries;
using Domain.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Presentation.Controllers;

[Authorize]
[Route("api/companies/{companyId:int}/employees")]
[ApiController]
[ApiExplorerSettings(GroupName = "v1")]
public class EmployeesController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IPublisher _publisher;

    public EmployeesController(ISender sender, IPublisher publisher)
    {
        _sender = sender;
        _publisher = publisher;
    }

    /// <summary>
    /// Get all employees for a company
    /// </summary>
    /// <param name="companyId"></param>
    /// <param name="employeeParameters"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetEmployeesForCompanyAsync(int companyId, [FromQuery] EmployeeParameters employeeParameters)
    {
        var pagedResult = await _sender.Send(new GetEmployeesForCompanyQuery(companyId, employeeParameters, TrackChanges: false));

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

        return Ok(pagedResult.employees);
    }

    /// <summary>
    /// Get an employee for a company
    /// </summary>
    /// <param name="companyId"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}", Name = "GetEmployeeForCompany")]
    public async Task<IActionResult> GetEmployeeForCompanyAsync(int companyId, int id)
    {
        var employee = await _sender.Send(new GetEmployeeForCompanyQuery(companyId, id, TrackChanges: false));

        return Ok(employee);
    }

    /// <summary>
    /// Creates a newly created employee for a company
    /// </summary>
    /// <param name="companyId"></param>
    /// <param name="employeeToCreate"></param>
    /// <returns>A newly created company</returns>
    [HttpPost]
    public async Task<IActionResult> CreateEmployeeForCompany(int companyId, [FromBody] EmployeeForCreationDto employeeToCreate)
    {
        if (employeeToCreate is null)
            return BadRequest("EmployeeForCreationDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var employeeToReturn = await _sender.Send(new CreateEmployeeCommand(companyId, employeeToCreate));

        return CreatedAtRoute("GetEmployeeForCompany", new { companyId, employeeToReturn.Id }, employeeToReturn);
    }

    /// <summary>
    /// Deletes an employee for a company
    /// </summary>
    /// <param name="companyId"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployeeForCompany(int companyId, int id)
    {
        await _publisher.Publish(new DeleteEmployeeCommand(companyId, id, TrackChanges: false));

        return NoContent();
    }

    /// <summary>
    /// Updates an employee for a company
    /// </summary>
    /// <param name="companyId"></param>
    /// <param name="id"></param>
    /// <param name="employeeToUpdate"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateEmployeeForCompany(int companyId, int id, [FromBody] EmployeeForUpdateDto employeeToUpdate)
    {
        if (employeeToUpdate is null)
            return BadRequest("EmployeeForUpdateDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _sender.Send(new UpdateEmployeeCommand(companyId, id, employeeToUpdate, companyTrackChanges: false, employeeTrackChanges: true));

        return NoContent();
    }

    /// <summary>
    /// Partially updates an employee for a company 
    /// </summary>
    /// <param name="companyId"></param>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <returns></returns>
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> PartiallyUpdateEmployeeForCompanyAsync(int companyId, int id,
        [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");

        var result = await _sender.Send(new GetEmployeeForPatchQuery(companyId, id, CompanyTrackChanges: false, EmployeeTrackChanges: true));

        patchDoc.ApplyTo(result.employeeToPatch, ModelState);

        TryValidateModel(result.employeeToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _sender.Send(new UpdateEmployeeCommand(companyId, id, result.employeeToPatch, companyTrackChanges: false, employeeTrackChanges: true));

        return NoContent();
    }
}
