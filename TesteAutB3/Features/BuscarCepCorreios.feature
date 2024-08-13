Feature: BuscarCepCorreios

Como um usuário
  Eu quero buscar um CEP no site dos correios

@tag1
Scenario: Realizar uma busca de CEP inválido
Given Eu acessei o site dos correios
When eu seleciono a opção buscar CEP ou endereço
And eu digito um cep invalido
And eu aguardo a resolução do captcha
And eu clico no botão buscar
Then eu devo visualizar a mensagem de erro de cep invalido

@tag2
Scenario: Realizar uma busca de CEP válido
Given Eu acessei o site dos correios
When eu seleciono a opção buscar CEP ou endereço
And eu digito um cep válido
And eu aguardo a resolução do captcha
And eu clico no botão buscar
Then eu devo visualizar o endereço correspondente ao CEP "Rua Quinze de Novembro, São Paulo/SP"

@tag3
Scenario: Realizar uma busca de um objeto inserindo um codigo
Given Eu acessei o site dos correios
When eu insiro o código de rastreio
And eu realizo a busca
And eu aguardo a resolução do captcha
And eu clico no botão consultar
Then eu devo visualizar a mensagem de objeto não encontrado