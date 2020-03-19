using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
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
            tributos.Pis = -41174.57M;
            tributos.Cofins = -253381.96M;

            ResultadoMensal resultadoMensal = new ResultadoMensal(tributos);
            resultadoMensal.Comercial = 4488064.56M;
            resultadoMensal.Tesouraria = 123936.78M;
            resultadoMensal.Câmbio = -27741.15M;
            resultadoMensal.Asset = 2279.83M;
            resultadoMensal.OutrosCustos = -860685.50M;

            var ResultadoTotal = 3725854.52M;
            Assert.AreEqual(resultadoMensal.ResultadoTotal, ResultadoTotal);

            var ResultadoLiquido = 2175665.48M;
            Assert.AreEqual(resultadoMensal.ResultadoLiquido, ResultadoLiquido);

            //Assert.AreEqual(tributos.ResultadoFinal, resultadoMensal.Tributos.ResultadoFinal);
            //=SOMASES(CUSTOS!D$2:D$17;CUSTOS!$B$2:$B$17;$B$63;CUSTOS!$C$2:$C$17;$B66)

            Assert.Pass();
        }
    }

    public class ResultadoMensal
    {
        public ResultadoMensal(Tributos tributos)
        {
            Tributos = tributos;
        }

        public decimal Comercial { get; set; }
        public decimal Tesouraria { get; set; }
        public decimal Câmbio { get; set; }
        public decimal Asset { get; set; }
        public decimal OutrosCustos { get; set; }
        public Tributos Tributos { get; set; }
        public decimal ResultadoTotal
        {
            get
            {
                return Comercial
                + Tesouraria + Câmbio
                + Asset + OutrosCustos;
            }
        }
        public decimal ResultadoLiquido
        {
            get
            {
                return ResultadoTotal + Tributos.ResultadoFinal;
            }
        }
    }
}