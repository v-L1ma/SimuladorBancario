# 💰 Simulador Bancário em C#

Este é um projeto de **Simulador Bancário** desenvolvido em **C#**, com foco em aplicar conceitos de orientação a objetos (POO), controle de fluxo, listas genéricas e manipulação de dados no console. O sistema simula funcionalidades básicas de um banco, como criação de contas, login, transferências, depósitos, saques e visualização de transações.

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET (console application)
- **Paradigma**: Programação Orientada a Objetos

---

## 📌 Funcionalidades

- Criar conta com validação de e-mail único e confirmação de senha
- Login com verificação de credenciais
- Realizar **transferências** entre contas cadastradas
- **Depositar** e **sacar** valores da conta logada
- Visualizar **saldo** e **informações da conta**
- Histórico de **transações** realizadas
- Fluxo controlado via menus interativos no console

---

## 🧩 Estrutura Básica

- `Conta`  
  Representa a conta bancária com métodos como `Depositar`, `Sacar`, `Transferir`, `VerSaldo`, entre outros.

- `Cliente`  
  Armazena informações pessoais do cliente como nome, CPF e endereço.

- `Transacao`  
  Registra cada operação financeira (transferência, depósito, saque) com origem, destino e valor.

- `Program.cs`  
  Responsável por controlar o fluxo principal do sistema: menus, login, criação de contas e ações bancárias.

---

## 🚀 Como Executar o Projeto

1. Clone o repositório:

   ```bash
   git clone https://github.com/v-L1ma/simulador-bancario.git
