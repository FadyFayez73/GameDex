using Core.Features.Games.Queries.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Core.Features.Games.Queries.Commands
{
    public class CreateGameCommandTest
    {
        [Fact]
        public void BasicTest()
        {
            var command = new CreateGameCommand
            {
                Name = "Test Name",
            };

            Assert.True(command.Name == "Test Name");
        }
    }
}
