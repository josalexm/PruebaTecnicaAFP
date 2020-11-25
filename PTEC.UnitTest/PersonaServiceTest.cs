using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PTEC.Core.Models;
using PTEC.Core.Repositories;
using PTEC.Core.Services;
using PTEC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTEC.UnitTest
{
    [TestClass]
    public class PersonaServiceTest
    {
        Mock<IAfiliadoRepository> _afiliadoRepository = new Mock<IAfiliadoRepository>();

        [TestMethod]
        public async Task NumeroDocumentoRepetido_RetornaExcepcion()
        {
            // Arrange
            IAfiliadoService _afiliadoService = GetAfiliadoService();
            Afiliado afiliado = new Afiliado();

            // Act
            //var e = Assert.ThrowsAsync<ArgumentException>(async () => await _afiliadoService.AgregarAfiliadoAsync(afiliado);
            
            // Assert
            //Assert.AreEqual(ArgumentException, e);
        }

        private IAfiliadoService GetAfiliadoService()
        {
            return new AfiliadoService(_afiliadoRepository.Object);
        }
    }
}
