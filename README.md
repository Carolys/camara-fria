<h1 align="center">
    <img alt="Camara Fria" title="CamaraFria" src="https://github.com/Carolys/camara-fria/blob/main/.github/logo.png" width=40% height=40%/>
</h1>

<p align="center">
  <img alt="Light theme home app" src="https://github.com/Carolys/camara-fria/blob/main/.github/iPhone-8-Plus-Light.png" width="25%">
  <img alt="Dar theme home app" src="https://github.com/Carolys/camara-fria/blob/main/.github/iPhone-8-Plus-Dark.png" width="25%">
</p>

## 📖 Sobre o projeto

A CamaraFria tem o objetivo que auxiliar no manejamento de ambientes que precisam de um controle de temperatura, como câmaras frias de refrigeração de alimentos.

As opções de controle são a luz do ambiente, a temperatura captada através de um sensor de temperatura, e duas leds para indicar se a temperatura do ambiente está acima do máximo que deveria estar ou abaixo. A led verde indica que está até a temperatura ideal ao ambiente, e assim que essa temperatura está acima, a led vermelha acende.

Esse projeto foi um trabalho desenvolvido durante a matéria de **[Tópicos Especiais de Software](https://github.com/Carolys/course-information-systems/tree/master/special-software-topics)** da graduação de Sistemas de Informação, em Outubro de 2020. 


## 🚀 Tecnologias

- [Xamarin](https://docs.microsoft.com/pt-br/xamarin/get-started/what-is-xamarin)
- [Firebase](firebase.google.com/)
- [Node-RED](https://nodered.org)
- [Arduino IDE](https://www.arduino.cc/en/Main/software)

## 🔌 Componentes eletrônicos

- 1 Arduino
- 3 Leds (1 vermelha, 1 verde, 1 amarela) 
- 1 DHT11 (Sensor de temperatura e umidade)

## 🎯 Objetivo do projeto

O objetivo do projeto é trazer dados via aplicação mobile de temperatura do freezer qual o usuário possa ter controle onde estiver. Seja para negócios ou residencial.

A câmara fria tem como seu objetivo trazer acesso em tempo real via aplicativo a temperatura da mesma. Com uma UI(user interface) minimalista e resiliente, pode-se obter a temperatura de uma geladeira e ou freezer. Além disso, existe também uma interface física que pode alegar o estado da temperatura visualmente.

## ⚙️ Funcionamento

É possível realizar a detectação de temperatura e com leds, realizar toda a reação visual, trazendo uma interface de interação visual. Por meio do aplicativo, também pode-se obter acesso aos dados, agora também tendo uma interação digital.

Quando a temperatura sobe, é acionado o led vermelho, demonstrando que a temperatura está alta e, quando baixa, o led verde é acionado mostrando que a temperatura atual é gelada. Para satisfazer a câmara fria, é também acionado um led de lâmpada quando está ativa no ambiente. 

Já o sensor de temperatura, deve estar sempre em contato com a câmara fria pois é por meio deste que irá detectar a temperatura e levar os dados ao hardware (microcontrolador). Através da programação do mesmo, ocorre o tratamento desses dados a fim de satisfazer a aplicação mobile, levando todas as informações necessárias como, qual led ligou, qual temperatura está, se está adequado ou não, se está frio ou quente.

## 🛠️ Modo de operação

Para que aconteça essa detecção de temperatura e toda a proposta previamente abordada, é usado um microcontrolador, no caso deste projeto, o Arduino Uno que, irá receber todos os dados detectados por periféricos a ele conectados e enviar os dados via porta serial para o node-red realizar a análise dos mesmos. Os periféricos anteriormente citados, seriam componentes como sensor de temperatura, responsável por detectar a temperatura da câmara e, leds, responsáveis por trazer a informação visual a quem usa.

Ainda que se chame câmara fria, o medidor de temperatura além de pegar temperaturas mínimas, também pega as máximas. E com o envio desses dados ao microcontrolador Arduino Uno, é possível trabalhar através do software NodeRed toda a obtenção dessa informação e também manipulação da mesma através da criação de dashboards que serão integradas ao aplicativo em questão. Com o auxílio de leds, é possível obter visão sobre o estado da temperatura (quente ou frio) e, também para iluminar o interior da câmara, facilitando seu uso. 

## 💻 Programação

No NodeRed, foi feito um fluxo de nodos que compõem basicamente a base de funcionamento de todo o sistema. Dentro desse fluxo, foram dispostos elementos para conectar arduino e fazer a leitura via porta serial, que faz a conexão com os outros componentes como as leds e o sensor. Também, foram inseridos elementos para a conexão com o firebase, e-mail e uma planilha de dados. 

Primeiramente, os dados do sensor de temperatura provenientes do Arduino são convertidos e modificados para apresentar e gravar esses dados. De acordo com o valor, esses dados são enviados via serial para o Arduino acender as leds e mostrar visualmente ao usuário o estado da temperatura. Outro dado em questão, que é possível a interação do usuário, é o ato de acender ou apagar a luz no ambiente do projeto. Isso foi simulado com uma led amarela.

Na imagem abaixo, é possível ver os atributos com seus respectivos valores sincronizados com o node-red, por meio a url. O atributos foram nomeados da seguinte forma: lâmpada indica o valor da iluminação do ambiente (led amarela), led1 indica o valor da led de indicação do status da temperatura abaixo do limite (led verde), led2 indica o valor da led de indicação do status da temperatura acima do limite (led vermelha), e a temperatura indica o valor proveniente do sensor de temperatura.

<h1 align="center">
    <img alt="Firebase" title="Firebase" src="https://github.com/Carolys/camara-fria/blob/main/arduinoide-and-nodered-archives/firebase.PNG" width=40% height=40%/>
</h1>

Em seguida, é possível visualizar os gráficos e valores obtidos por meio da integração, nas imagens abaixo do resultado dos formulários e planilha.

<h1 align="center">
    <img alt="Forms do Google" title="FormularioGoogle" src="https://github.com/Carolys/camara-fria/blob/main/arduinoide-and-nodered-archives/forms-google.PNG" width=40% height=40%/>
</h1>

Foi desenvolvido um app mobile com Xamarin para o monitoramento dos dados do ambiente  de escolha do usuário conforme citado anteriormente. Esses dados são capturados em tempo real da ferramenta Firebase, assim é possível ter controle sobre os dados de temperatura, e se esse valor superou o valor máximo que o ambiente deve ter ou não. Também, é possível acionar e desligar a luz do local ao clicar no ícone de lamparina na parte superior da interface.

Os dados foram capturados em formato json e convertidos para serem apresentados na tela, assim como na requisição para alterar o valor de acionamento e o desligamento da lâmpada do ambiente em questão.

## 📝 Esquemático de montagem

Na esquemática abaixo, é possível notar como cada componente deve estar conectado para satisfazer seu propósito. Na mesma é ilustrado o arduino como fonte alimentando a placa de prototipação pela saída de 5V, além do GND via Jumpers. 

Realizando ligações pela própria placa de prototipação, é possível distribuir a energia para o sensor de temperatura, assim como atribuir o GND (ground) ao componente. Além das ligações necessárias para ligar o componente sensor, também é necessário conectá-lo ao I/O do Arduino Uno, na imagem abaixo, é ilustrado que o cabo de dados em verde é ligado em uma das pontas na porta 2 (digital 2), uma porta digital, e na outra até o pino que irá liberar os dados no sensor. Conectando também um resistor de 220Ω entre a entrada de 5V e a saída de dados do sensor para garantir integridade aos dados.

Para ligar os leds, expande-se a conexão do GND por  jumpers conectado à resistores de 220Ω no Catodo e,n o Anodo, cabos de conexão direta de dados pelas I/O 12,11 e 10 do Arduino Uno que também irá mandar carga para o mesmo.


<h1 align="center">
    <img alt="Circuito" title="Circuito" src="https://github.com/Carolys/camara-fria/blob/main/arduinoide-and-nodered-archives/circuit.PNG" width=80% height=40%/>
</h1>

## ☋ Flow Node-Red

<h1 align="center">
    <img alt="Flow parte 1" title="FlowParte1" src="https://github.com/Carolys/camara-fria/blob/main/arduinoide-and-nodered-archives/node-red-flow-1.PNG" width=50% height=40%/>
    <img alt="Flow parte 2" title="FlowParte2" src="https://github.com/Carolys/camara-fria/blob/main/arduinoide-and-nodered-archives/node-red-flow-2.PNG" width=50% height=40%/>
</h1>

## ✨ Dashboard do Node-Red

<h1 align="center">
    <img alt="Dashboard Node-Red" title="DashboardNodeRed" src="https://github.com/Carolys/camara-fria/blob/main/arduinoide-and-nodered-archives/dashboard-node-red.PNG" width=20% height=40%/>
</h1>

## 📧 E-mail com dados disparados pelo Node-Red

<h1 align="center">
    <img alt="Email status" title="EmailStatus" src="https://github.com/Carolys/camara-fria/blob/main/arduinoide-and-nodered-archives/email-status.png" width=40% height=40%/>
</h1>

## 🖥 Code utilizado no Arduino IDE

<h1 align="center">
    <img alt="Arduino IDE Code" title="ArduinoIDECode" src="https://github.com/Carolys/camara-fria/blob/main/arduinoide-and-nodered-archives/arduino-ide.PNG" width=40% height=40%/>
</h1>

## 🔌 Split da porta serial

<h1 align="center">
    <img alt="Split Porta Serial" title="SplitPortaSerial" src="https://github.com/Carolys/camara-fria/blob/main/arduinoide-and-nodered-archives/split.PNG" width=60% height=60%/>
</h1>

## 📷 Foto do circuito

<h1 align="center">
    <img alt="Circuito" title="Circuito" src="https://github.com/Carolys/camara-fria/blob/main/arduinoide-and-nodered-archives/image2.png" width=60% height=60%/>
</h1>

---

<p align="center">Orientação do professor Leandro Vasconcelos</p>
<p align="center">Desenvolvido com 💜 por Carolina Yasue, Matheus Stella e Camila Rody</p>
