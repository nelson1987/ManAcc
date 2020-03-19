using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class TributoTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Tributos tributos = new Tributos();
            tributos.ContribuicaoSocial = -471612.19M;
            tributos.ImpostoDeRenda = -784020.32M;
            tributos.ContribuicaoSocialDiferido = 0.00M;
            tributos.ImpostoDeRendaDiferido = 0.00M;
            tributos.Pis = 41174.57M;
            tributos.Cofins = 253381.96M;

            //Assert.AreEqual(resultadoMensal.ResultadoLiquido, ResultadoLiquido);


            Assert.Pass();

            //=(DRE!C$123+DRE!C$129)
        }
    }
    public class Tributos
    {
        public decimal Pis { get; set; }
        public decimal Cofins { get; set; }
        public decimal ImpostoDeRenda { get; set; }
        public decimal ImpostoDeRendaDiferido { get; set; }
        public decimal ContribuicaoSocial { get; set; }
        public decimal ContribuicaoSocialDiferido { get; set; }
        public decimal PisCofins { get { return Pis + Cofins; } }
        public decimal IrECs
        {
            get
            {
                return ImpostoDeRenda + ImpostoDeRendaDiferido + ContribuicaoSocial + ContribuicaoSocialDiferido;
            }
        }
        public decimal ResultadoFinal
        {
            get
            {
                return PisCofins + IrECs;
            }
        }
    }

}