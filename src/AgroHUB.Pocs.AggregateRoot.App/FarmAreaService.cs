using System;
using System.Threading.Tasks;
using AggregateRoot.Core.Exceptions;
using AggregateRoot.Domain.Entities;
using AggregateRoot.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace AggregateRoot.App
{
    public class FarmAreaService : IRunner
    {
        private readonly ILogger<FarmAreaService> _logger;
        private readonly IFarmAreaRepository _farmAreaRepository;

        public FarmAreaService(ILogger<FarmAreaService> logger,
            IFarmAreaRepository farmAreaRepository)
        {
            _logger = logger;
            _farmAreaRepository = farmAreaRepository;
        }

        public async Task Run()
        {
            try
            {
                _logger.LogInformation("Adding Area 1...");
                var name = "Area 1";

                var farmArea = new FarmArea(name);
                farmArea.AddCoordinate(-18.154384993302173M, -50.53218483924866M);
                farmArea.AddCoordinate(-18.154670446321067M, -50.53162693977356M);
                farmArea.AddCoordinate(-18.154201487543776M, -50.531712770462036M);
                farmArea.AddCoordinate(-17.842383165920296M, -46.25969409942627M);

                _logger.LogInformation("Validating...");
                var farmAreaExists = await _farmAreaRepository.GetByName(name);
                if (farmAreaExists != null)
                    throw new DomainException("Area already exists");

                farmArea.Validate();

                _farmAreaRepository.Add(farmArea);

                await _farmAreaRepository.UnitOfWork.Commit();

                _logger.LogInformation("Area 1 persisted!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error. {ex.Message}");
            }
        }
    }
}
