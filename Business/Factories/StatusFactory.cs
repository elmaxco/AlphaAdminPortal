using Business.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Factories;

public class StatusFactory
{
    public static StatusDto? Create(StatusEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        return new StatusDto()
        {
            StatusName = entity.StatusName,
        };

    }
    public static StatusEntity Create(StatusDto dto) => new()
    {
        StatusName = dto.StatusName

    };


    public static StatusUpdateDto Create(Status status) => new()
    {
        Id = status.Id,
        StatusName = status.StatusName

    };

    public static StatusEntity Create(StatusUpdateDto dto) => new()
    {
        Id = dto.Id,
        StatusName = dto.StatusName

    };
}
