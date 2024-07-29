# Global.CarManagement.View

É um microserviço que lida com o dominio de Carros, utilizando uma Web API .NET 8. </br>
O Microserviço <b>Global.CarManagement.View</b> realiza a apresentação das informações dos carros utilizando o <b>Kafka</b> para o processo de mensageria e o Banco de dados <b>MongoDB</b> para persistência dos dados.

Passo a Passo:

1. Execute o <b>docker-compose</b> na raiz deste repositório para que o banco <b>MongoDB</b>, e o broker <b>Kafka</b> sejam criados. 

2. Execute o projeto com o seguinte comando <b>dotnet Global.CarManagement.Created.Consumer.dll</b> ou se preferir acesse a solução pelo <b>Visual Studio</b>.

3. Execute o projeto com o seguinte comando <b>dotnet Global.CarManagement.View.Api.dll</b> ou se preferir acesse a solução pelo <b>Visual Studio</b>.

4. Execute o arquivo index.html na raiz deste repositório para acompanhar a lista dos carros que são cadastrados.
