# Cotação Banco Central.Net

Projeto .Net que utiliza o WS do Banco Central para consultar Cotações de Diversos índices e moedas.

A CotacaoBcb.Net é uma biblioteca desenvolvida buscando fornecer ao desenvolvedor uma fácil integração das funcionalidades disponibilizadas através do WS do Banco Central ao seu sistema.

## WebService do Banco Central

WS: https://www3.bcb.gov.br/wssgs/services/FachadaWSSGS

## Utilização

No seu console de instalação de pacotes, rode o comando

	Install-Package CotacaoBcb.Net 
	
## Exemplo

```c#
public void ConsultarValor()
{
   CotacaoBcb ws = new CotacaoBcb();   
	//INPC
   var cotacao = ws.ConsultarUltimoValor(188);
   
   decimal valorIndice = cotacao.ultimoValor.svalor;
}


public void ConsultarCodigo()
{
	CotacaoBcb ws = new CotacaoBcb();
	var indices = ws.ConsultarCodigoCotacao("igp-m");
	
	foreach(var indice in indices)
	{
		...
	}
}

```