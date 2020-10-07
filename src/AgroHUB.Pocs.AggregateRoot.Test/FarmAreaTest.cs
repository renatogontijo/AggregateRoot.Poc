using AggregateRoot.Domain.Entities;
using Xunit;
using System;
using AggregateRoot.Core.Exceptions;

namespace AggregateRoot.Test
{
    public class FarmAreaTest
    {
        [Fact]
        public void FarmArea_AddNewFarmAreaSucceded_ReturnsTrue()
        {
            var farmArea = new FarmArea("Área 1");
            farmArea.AddCoordinate(-18.154384993302173M, -50.53218483924866M);
            farmArea.AddCoordinate(-18.154670446321067M, -50.53162693977356M);
            farmArea.AddCoordinate(-18.154201487543776M, -50.531712770462036M);
            farmArea.AddCoordinate(-17.842383165920296M, -46.25969409942627M);

            try
            {
                farmArea.Validate();
            }
            catch (DomainException ex)
            {
                Assert.True(ex == null, $"Domain exception. {ex.Message}");
            }
        }

        [Fact]
        public void FarmArea_AddNewFarmAreaFail_ReturnsDomainException()
        {
            var farmArea = new FarmArea("Área 1");
            farmArea.AddCoordinate(-18.154384993302173M, -50.53218483924866M);
            farmArea.AddCoordinate(-18.154384993302173M, -50.53218483924866M);
            farmArea.AddCoordinate(-18.154384993302173M, -50.53218483924866M);
            farmArea.AddCoordinate(-18.154384993302173M, -50.53218483924866M);

            var exception = Assert.ThrowsAny<DomainException>(() => farmArea.Validate());
        }
    }
}
