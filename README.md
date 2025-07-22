# App de Apontamento de Produção

![Logo do Projeto](https://i.imgur.com/gK6ZzJg.png) 

## 📖 Sobre o Projeto

Este é um protótipo funcional de um aplicativo multiplataforma, desenvolvido em **.NET MAUI**, para o registro e gerenciamento de produção de equipes de campo. A solução foi projetada para digitalizar e otimizar o processo de apontamento, substituindo planilhas e anotações manuais por uma interface móvel, moderna e intuitiva.

O projeto demonstra a criação de uma aplicação corporativa robusta, desde a autenticação de usuário até o registro detalhado de atividades, com uma interface de usuário limpa e profissional.

---

## ✨ Funcionalidades Atuais

* **Autenticação Segura:** Tela de login com validação de credenciais predefinidas (`user: Admin`, `pass: admin`).
* **Controle de Ponto:** Uma tela dedicada para o registro de ponto do colaborador, com relógio em tempo real.
* **Navegação por Abas:** Interface principal com um menu de navegação inferior (`TabBar`) para acesso rápido às principais seções do app.
* **Gestão de Apontamentos:**
    * Criação de novos registros de produção (serviço, equipe, recursos).
    * Lista de apontamentos existentes com status visual (Ex: "Em Andamento", "Pendente").
* **Registro de Produção em Campo:**
    * Funcionalidade para capturar foto do local de trabalho usando a câmera do dispositivo.
    * Captura de coordenadas GPS para georreferenciamento.
    * Registro de pausas para refeição.
* **Interface Moderna:** Design limpo e profissional, com uso de cards, ícones (Font Awesome) e uma paleta de cores consistente.

---

## 🛠️ Tecnologias Utilizadas

* **Framework:** .NET MAUI (.NET 8)
* **Linguagem:** C#
* **Interface:** XAML
* **Arquitetura:** MVVM (Model-View-ViewModel)
* **Ícones:** Font Awesome

---

## 🚀 Como Executar

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/seu-usuario/seu-repositorio.git](https://github.com/seu-usuario/seu-repositorio.git)
    ```
2.  **Abra no Visual Studio:**
    * Abra o arquivo da solução (`.sln`) no Visual Studio 2022 (ou superior).
    * Certifique-se de que a carga de trabalho do .NET MAUI está instalada.
3.  **Restaure as dependências:**
    * Clique com o botão direito na solução e selecione "Restaurar Pacotes do NuGet".
4.  **Execute o projeto:**
    * Selecione um emulador Android ou um dispositivo físico conectado.
    * Pressione F5 ou clique no botão "Iniciar" para compilar e executar o aplicativo.

---

## 🗺️ Próximos Passos (Roadmap)

Este protótipo é a base para uma solução completa. As próximas melhorias planejadas incluem:

* [ ] **Integração com API:** Substituir os dados mocados (`MockDataService`) por chamadas a uma API RESTful real para persistência dos dados.
* [ ] **Funcionalidade Offline:** Implementar um banco de dados local (SQLite) para permitir que o aplicativo funcione sem conexão com a internet, sincronizando os dados quando a conexão for restabelecida.
* [ ] **Completar as Seções:** Desenvolver as telas de "Registros de Almoço" e "Perfil do Usuário".
* [ ] **Fluxo de Validação:** Criar a interface para que gestores e engenheiros possam validar ou reprovar os apontamentos enviados.
* [ ] **Cálculos Avançados:** Implementar a lógica para cálculo automático de horas extras com base na jornada de trabalho.
* [ ] **Notificações Push:** Adicionar alertas para pendências de validação e outras comunicações importantes.

