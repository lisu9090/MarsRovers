using MarsRovers.Models;
using MarsRovers.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRovers.UnitTests.Repositories
{
    public class RoversRepositoryTest
    {
        [Fact]
        public void AddGetModel_ReceivesModel_ReturnsModel()
        {
            var roversRepository = new RoversRepository();
            var expectedData = new RoverModel(1, 2, "E");

            // This test need to combine AddModel and GetModels method because repository doesn't allow for direct access to its 
            roversRepository.AddModel(expectedData);
            var dataEnummerator = roversRepository.GetModels().GetEnumerator();
            dataEnummerator.MoveNext();
            var actualData = dataEnummerator.Current;

            Assert.Equal(expectedData, (RoverModel)actualData);
        }

        [Fact]
        public void Reset_ClearsRepository_ReturnsEmptyEnummerator()
        {
            var roversRepository = new RoversRepository();
            var sampleData = new RoverModel(1, 2, "E");
            int expectedData = 0;
            var actualData = 0;

            // This test need to combine AddModel and Reset method because repository doesn't allow for direct access to it's content
            roversRepository.AddModel(sampleData);
            roversRepository.Reset();

            var dataEnummerator = roversRepository.GetModels().GetEnumerator();
            while (dataEnummerator.MoveNext())
            {
                actualData++;
            }

            Assert.Equal(expectedData, actualData);
        }

        [Fact]
        public void UpdateRoverMovementInstructions_ReceivesInstructions_UpdatesLastModel()
        {
            var roversRepository = new RoversRepository();
            var expectedData = "RMMRMMRRMR";

            // This test need to combine AddModel and UpdateRoverMovementInstructions method because repository doesn't allow for direct access to it's content
            roversRepository.AddModel(new RoverModel(1, 2, "E"));
            roversRepository.UpdateRoverMovementInstructions(expectedData);

            var dataEnummerator = roversRepository.GetModels().GetEnumerator();
            dataEnummerator.MoveNext();
            var actualData = ((RoverModel)dataEnummerator.Current).MovementInstructions;

            Assert.Equal(expectedData, actualData);
        }
    }
}
