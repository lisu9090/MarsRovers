using MarsRovers.Models;
using MarsRovers.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRovers.UnitTests.Repositories
{
    public class PlateauRepositoryTest
    {
        [Fact]
        public void AddGetModel_ReceivesModel_ReturnsModel()
        {
            var plateauRepository = new PlateauRepository();
            var expectedData = new PlateauModel(1, 2);

            // This test need to combine AddModel and GetModels method because repository doesn't allow for direct access to it's content
            plateauRepository.AddModel(expectedData);
            var dataEnummerator = plateauRepository.GetModels().GetEnumerator();
            dataEnummerator.MoveNext();
            var actualData = dataEnummerator.Current;

            Assert.Equal(expectedData, (PlateauModel)actualData);
        }

        [Fact]
        public void Reset_ClearsRepository_ReturnsEmptyEnummerator()
        {
            var plateauRepository = new PlateauRepository();
            var sampleData = new PlateauModel(1, 2);
            int expectedData = 0;
            var actualData = 0;

            // This test need to combine AddModel and Reset method because repository doesn't allow for direct access to it's content
            plateauRepository.AddModel(sampleData);
            plateauRepository.Reset();

            var dataEnummerator = plateauRepository.GetModels().GetEnumerator();
            while (dataEnummerator.MoveNext())
            {
                actualData++;
            }

            Assert.Equal(expectedData, actualData);
        }
    }
}
