using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Xml.Linq;
using CotacaoBcB.Net.Codigos;
using CotacaoBcB.Net.WsBcb;
using CotacaoBcB.Net.Exceptions;

namespace CotacaoBcB.Net
{
    public class CotacaoBcb
    {
        public const string UrlService = "https://www3.bcb.gov.br/wssgs/services/FachadaWSSGS";
        public const string FormatoData = "dd/MM/yyyy";

        private FachadaWSSGSClient _service;
        private CodigosService _codigoService;

        public CotacaoBcb()
        {
            if (InternetAvailability.IsInternetAvailable())
            {
                _service = new FachadaWSSGSClient(new BasicHttpBinding(BasicHttpSecurityMode.Transport), new EndpointAddress(UrlService));
                _codigoService = new CodigosService();
            }
            else
                throw new InternetNotAvailableException();
        }

        /// <summary>
        /// Recupera o último valor de uma determinada série e retorna o resultado em formato XML.
        /// </summary>
        /// <param name="codigoCotacao">long codigoCotacao – Código da série</param>
        /// <returns>Série - Formato XML</returns>
        public XDocument ConsultarUltimoValorXml(long codigoCotacao)
        {
            var retornoWs = _service.getUltimoValorXML(codigoCotacao);
            return XDocument.Parse(retornoWs);
        }
        /// <summary>
        /// Recupera o último valor de uma determinada série e retorna um objeto do tipo WSSerieVO.
        /// </summary>
        /// <param name="codigoCotacao">long codigoCotacao – Código da série</param>
        /// <returns>Objeto contendo o valor</returns>
        public WSSerieVO ConsultarUltimoValor(long codigoCotacao)
        {
            return _service.getUltimoValorVO(codigoCotacao);
        }

        /// <summary>
        /// Recupera o valor de uma série em uma determinada data(dd/MM/aaaa).
        /// </summary>
        /// <param name="codigoCotacao">long codigoCotacao – Código da série</param>
        /// <param name="data">DateTime data - uma data específica para consulta do valor da série</param>
        /// <returns>Valor da Série</returns>
        public decimal ConsultarValorEspecifico(long codigoCotacao, DateTime data)
        {
            return _service.getValor(codigoCotacao, data.ToString("dd/MM/yyyy"));
        }

        /// <summary>
        ///  Recupera o valor de uma série especial em um período.
        /// </summary>
        /// <param name="codigoCotacao">Código da série.</param>
        /// <param name="dataIni">Data de Início do Período</param>
        /// <param name="dataFim">Data de fim do Período</param>
        /// <returns>Valor da Série</returns>
        public decimal ConsultarValorEspecificoPerido(long codigoCotacao, DateTime dataIni, DateTime dataFim)
        {
            return _service.getValorEspecial(codigoCotacao, dataIni.ToString("dd/MM/yyyy"), dataFim.ToString(FormatoData));
        }

        /// <summary>
        /// Recupera os valores de uma ou mais séries dentro de um determinado período.O resultado da consulta é em formato XML.
        /// </summary>
        /// <param name="codigosCotacao">Lista(array) dos códigos das séries</param>
        /// <param name="dataIni">Data de Início do Período</param>
        /// <param name="dataFim">Data de fim do Período</param>
        /// <returns>Resultado da consulta em formato XML</returns>
        public XDocument ConsultarValoresSeriesXml(long[] codigosCotacao, DateTime dataIni, DateTime dataFim)
        {
            var retornoWs = _service.getValoresSeriesXML(codigosCotacao, dataIni.ToString(FormatoData), dataFim.ToString(FormatoData));
            return XDocument.Parse(retornoWs);
        }

        /// <summary>
        /// Recupera os valores de uma ou mais séries dentro de um determinado período e retorna o resultado em forma de Array de objetos do tipo WSSerieVO.
        /// </summary>
        /// <param name="codigosCotacao">Lista(array) dos códigos das séries</param>
        /// <param name="dataIni">Data de Início do Período</param>
        /// <param name="dataFim">Data de fim do Período</param>
        /// <returns> Lista(array) de objeto série.</returns>
        public IEnumerable<WSSerieVO> ConsultarValoresSeries(long[] codigosCotacao, DateTime dataIni, DateTime dataFim)
        {
            return _service.getValoresSeriesVO(codigosCotacao, dataIni.ToString(FormatoData), dataFim.ToString(FormatoData)).ToList();
        }

        public IEnumerable<Serie> ConsultarCodigoCotacao(string nomeSerie)
        {
            return _codigoService.RecuperarSeriePorNome(nomeSerie);
        }
    }
}
