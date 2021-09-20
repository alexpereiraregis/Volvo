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
3 - Terá de configurar os projetos <b>Volvo.Api</b> e <b>Volvo.MVC</b> para que estes sejam executados assim que for acionado o <b>Start</b>. Para isso, seguir as instruções da imagem abaixo:<br>
    3.1 - Com o clique direito sobre a solution 'Volvo', escolher no Menu a opção <b>Set Startup Projects</b>:<br>
![image](https://user-images.githubusercontent.com/14164810/133961783-976f7206-81f8-4d9d-98f0-da1c1d8d4405.png)<br><br>
    3.2 - Será Aberto uma tela Property Pages. Nesta tela, escolher na esquerda, o submenu <b>Startup Project</b> do menu principal <b>Common Properties</b>;<br>
    3.3 - Será aberto do lado direito outras opções. Escolher <b>Multiple startup projects</b> e escolher para os projetos <b>Volvo.Api</b> e <b>Volvo.MVC</b> a Action <b>Start</b>. Clica em OK para confirmar; <br>
![image](https://user-images.githubusercontent.com/14164810/133962450-c174ee61-5ae0-442b-a25b-b5b91583561b.png)<br><br>
4 - Após <b>Start</b>, na ortem será executado o proejto <b>Volvo.Api</b> (Swagger) e logo em seguida o projeto <b>Volvo.MVC</b>.
![image](https://user-images.githubusercontent.com/14164810/133962732-aac96531-e1cc-4883-83e2-957c1090eb25.png)<br>
![image](https://user-images.githubusercontent.com/14164810/133962779-ccaaeed5-9a46-4b41-9eb5-7453a9329678.png)


