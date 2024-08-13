Feature: Buscar CEP no site dos correios
  Como um usuário
  Eu quero buscar um CEP no site dos correios
  Para que eu possa saber o endereço de uma pessoa

  @mytag1
  Scenario: Realizar busca de CEP no site dos correios
  Given Eu acessei o site dos correios
  When eu seleciono a opção buscar CEP ou endereço
  And eu digito um cep invalido
  And eu aguardo a resolução do captcha
  And eu clico no botão buscar
  Then eu devo visualizar a mensagem de erro de cep invalido
  When eu clico no botão nova busca
  And eu digito um cep válido
  And eu aguardo a resolução do captcha novamente
  And eu clico no botão buscar novamente
  Then eu devo visualizar o endereço correspondente ao CEP "Rua Quinze de Novembro, São Paulo/SP"
  When eu volto para a pagina inicial
  And eu insiro o código de rastreio
  And eu realizo a busca
  And eu aguardo a resolução do captcha para a tela de rastreio
  And eu clico no botão consultar
  Then eu devo visualizar a mensagem de objeto não encontrado
