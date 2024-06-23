using Application.Services;
using Domain;
using Moq;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Domain
{
    public class BandaServiceTest
    {

        Mock<IBandaRepository> mockRepository = new Mock<IBandaRepository>();
        private readonly BandaService bandaService;

        public BandaServiceTest() 
        {
            bandaService = new BandaService(mockRepository.Object);
        }
        [Fact]
        public void DeveObterTodaAsBandas()
        {
            var banda = new Banda
            {
                Id = new Guid(),
                Nome = "Banda Dummy",
                Descricao = "descricao Dummy"
            };
            var bandas = new List<Banda>{ banda };
            mockRepository.Setup(r => r.GetBandas()).Returns(bandas) ;

            var expected = bandaService.ObterBandas();

            Assert.Equal(bandas, expected);
        }
        [Fact]
        public void Should_Get_By_Id_Band_Success()
        {
            var idBanda = Guid.NewGuid();
            var banda = new Banda
            {
                Id = idBanda,
                Nome = "Banda Dummy",
                Descricao = "Descricao Dummy"
            };

            mockRepository.Setup(r => r.GetBanda(idBanda)).Returns(banda);

            // Act
            var expected = bandaService.ObterBanda(idBanda);

            // Assert
            Assert.True(expected.Nome != null);
            Assert.Equal(banda.Id, expected.Id);
        }

        [Fact]
        public void Should_Create_Band_Success()
        {
            // Arrange
            var idBanda = Guid.NewGuid();
            var banda = new Banda
            {
                Id = idBanda,
                Nome = "Banda Dummy",
                Descricao = "Descricao Dummy"
            };

            // Act
            bandaService.CriarBanda(banda);

            // Assert
            mockRepository.Verify(r => r.Save(banda), Times.Once);
        }
    }
}
