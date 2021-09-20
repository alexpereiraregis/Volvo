# Volvo
<b>Aplicacao Teste Volvo.</b><br>
Aplicação criada em .NET Core 5.0, com banco de Dados Sql Server.

<b> A Arquitetura foi dividida nas seguintes Camadas:</b>  <br> 
1 - Volvo.Api: Camada que contém as Apis principais responsáveis pelas operações de Inclusão, edição, consulta e Exclusão; <br>
2 - Volvo.Aplication: Onde são definidas as Regras de Negócio; <br>
3 - Volvo.Domain: Onde estão as Entidades da aplicação; <br>
4 - Volvo.Infra.Data: Onde é orquestrado o Banco de dados via EntityFramework; <br>
5 - Volvo.Infra.IOC: Orquestração das Injeções de dependência; <br>
6 - Volvo.MVC: Front-End. Interface do Usuário;<br>
7 - Volvo.Test: Onde estão os Testes unitários.

<b>Instruções de Execução:</b><br>
1 - Para Executar a aplicação necessita-se da IDE Visual Studio mínimo 2019; <br>
2 - No Visual Studio, abrir a solução <b> Volvo.sln </b> <br>
3 - Terá de configurar os projetos <b>Volvo.Api</b> e <b>Volvo.MVC</b> para que estes sejam executados assim que for acionado o <b>Start</b>. 
