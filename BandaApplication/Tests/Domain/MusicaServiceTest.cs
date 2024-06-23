using Application.Services;
using Domain;
using Moq;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Domain
{

    public class MusicaServiceTest
    {
        [Fact]
        public void DeveCriarumaMusicaComSucesso()
        {
            Mock<IMusicaRepository> mockRepository = new Mock<IMusicaRepository>();
            IMusicaService musicaService = new MusicaService(mockRepository.Object);
            Guid id = Guid.NewGuid();

            var musica = new Musica
            {
                Id = id,
                Nome = "Musica Dummy",
                Duracao = 120
            };

            mockRepository.Setup(r => r.GetMusica(id)).Returns(musica);

            Assert.NotNull(musica);

            Assert.True(musica.Nome.Any());
        }
    }

}


