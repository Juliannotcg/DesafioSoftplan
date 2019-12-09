using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxaJuros.Api.AutoMapper;

namespace CalculaJuros.Test.AutoMapper
{
    [TestClass]
    public class Mapping
    {
        [TestMethod]
        public void Testando_Mapeamento()
        {
            MapperConfiguration config = AutoMapperConfiguration.RegisterMappings();
            config.AssertConfigurationIsValid();
        }
    }
}
