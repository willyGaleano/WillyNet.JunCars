using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WillyNet.JunCars.Core.Application.DTOs;
using WillyNet.JunCars.Core.Application.Interfaces.Repository;
using WillyNet.JunCars.Core.Application.Wrappers;
using WillyNet.JunCars.Core.Domain.Entities;

namespace WillyNet.JunCars.Core.Application.Features.Cars.Queries
{
    public class GetAllCarQuery : IRequest<Response<IEnumerable<CarDto>>>
    {
    }

    public class GetAllCarHandler : IRequestHandler<GetAllCarQuery, Response<IEnumerable<CarDto>>>
    {
        private readonly IRepository<Car> _repository;
        private readonly IMapper _mapper;

        public GetAllCarHandler(IRepository<Car> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<CarDto>>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            var cars = await _repository.GetAllAsync();
            var carsDto = _mapper.Map<IEnumerable<CarDto>>(cars);
            return new Response<IEnumerable<CarDto>>(carsDto, "Consulta exitosa");
        }
    }
}
