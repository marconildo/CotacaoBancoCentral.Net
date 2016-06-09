using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using CotacaoBcB.Net.Properties;

namespace CotacaoBcB.Net.Codigos
{
    public class CodigosService
    {
        public IEnumerable<Serie> RecuperarSeriePorNome(string nomeSerie)
        {
            if (string.IsNullOrEmpty(nomeSerie))
                throw new ArgumentNullException(nameof(nomeSerie));

            var docXml = XDocument.Parse(Resources.codigosCotacao);

            if (docXml.Root != null)
            {
                var result = (from item in docXml.Root.Elements()
                    let xDescricao = item.Element("Descricao")
                    where
                        xDescricao != null && xDescricao.Value.ToLowerInvariant().Contains(nomeSerie.ToLowerInvariant())
                    let xCodigo = item.Element("Codigo")
                    where xCodigo != null
                    select new Serie
                    {
                        Codigo = Convert.ToInt64(xCodigo.Value),
                        Descricao = xDescricao.Value
                    }).ToList();


                return result;
            }

            return null;
        }
    }
}
