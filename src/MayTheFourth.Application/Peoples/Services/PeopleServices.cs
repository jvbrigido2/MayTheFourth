﻿using MayTheFourth.Application.Peoples.Interfaces.Services;
using MayTheFourth.Application.Peoples.Queries;
using MayTheFourth.Application.Peoples.Responses;

namespace MayTheFourth.Application.Peoples.Services;

public class PeopleServices(ISender mediator) : IPeopleServices
{
    public async Task<Result<IList<PeopleResponse>>> GetPeoplesAsync(int? skip, int? take, CancellationToken cancellationToken = default)
    {
        var response = await mediator.Send(new GetPeopleQuery(skip ?? 0, take ?? 10), cancellationToken);
        if(response is null) return Result<IList<PeopleResponse>>.Failure(Error.NotFound);
        return Result<IList<PeopleResponse>>.Ok(People.ToResponse(response));
    }

    public async Task<Result<PeopleResponse>> GetPeopleByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var response = await mediator.Send(new GetPeopleByIdQuery(id), cancellationToken);
        if(response is null) return Result<PeopleResponse>.Failure(Error.NotFound);
        return Result<PeopleResponse>.Ok(People.ToResponse(response));
    }

    public async Task<Result<IList<PeopleResponse>>> GetPeopleByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var response = await mediator.Send(new GetPeopleByNameQuery(name), cancellationToken);
        if(response is null) return Result<IList<PeopleResponse>>.Failure(Error.NotFound);
        return Result<IList<PeopleResponse>>.Ok(People.ToResponse(response));
    }

    public async Task<Result<IList<PeopleResponse>>> GetPeopleByGenderAsync(string gender, CancellationToken cancellationToken = default)
    {
        var response = await mediator.Send(new GetPeopleByGenderQuery(gender), cancellationToken);
        if(response is null) return Result<IList<PeopleResponse>>.Failure(Error.NotFound);
        return Result<IList<PeopleResponse>>.Ok(People.ToResponse(response));
    }
}