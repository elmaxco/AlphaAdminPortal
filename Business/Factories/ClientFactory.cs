using Business.Dtos;
using Business.Models;
using Data.Entities;


namespace Business.Factories;

public static class ClientFactory
{
    public static ClientDto? Create(ClientEntity entity)
    {
        if (entity == null)
        
            throw new ArgumentNullException(nameof(entity));
        

        return new ClientDto()
        {
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Phone = entity.Phone,
            Address = entity.Address,
            DateOfBirth = entity.DateOfBirth
        };
    }

    public static ClientEntity Create(ClientDto dtos) => new()
    {
        FirstName = dtos.FirstName,
        LastName = dtos.LastName,
        Email = dtos.Email,
        Phone = dtos.Phone,
        Address = dtos.Address,
        DateOfBirth = dtos.DateOfBirth

    };
    public static ClientEntity Create(ClientUpdateDto dto) => new()
    {
        Id = dto.Id,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Email = dto.Email,
        Phone = dto.Phone,
        Address = dto.Address,
        DateOfBirth = dto.DateOfBirth

    };


    public static ClientUpdateDto Create(Client client) => new()
    {
        Id = client.Id,
        FirstName = client.FirstName,
        LastName = client.LastName,
        Email = client.Email,
        Phone = client.Phone,
        Address = client.Address,
        DateOfBirth = client.DateOfBirth
    };


    
}
