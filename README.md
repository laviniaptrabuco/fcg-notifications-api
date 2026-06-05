# FCG Notifications API

Microsserviço responsável por simular o envio de e-mails de notificação da FIAP Cloud Games.

## Responsabilidades

- Consome `UserCreatedEvent` → simula envio de e-mail de boas-vindas (log no console)
- Consome `PaymentProcessedEvent` → simula envio de e-mail de confirmação de compra (log no console)

## Tipo de Projeto

Worker Service (.NET 8) — sem endpoints HTTP, apenas consumers de mensagens.

## Variáveis de Ambiente

| Variável | Descrição | Exemplo |
|---|---|---|
| `RabbitMQ__Host` | Host do RabbitMQ | `rabbitmq` |
| `RabbitMQ__Username` | Usuário RabbitMQ | `guest` |
| `RabbitMQ__Password` | Senha RabbitMQ | `guest` |

## Fluxo de Mensagens

```
UserCreatedEvent       (consumido) → loga "E-mail de boas-vindas enviado"
PaymentProcessedEvent  (consumido) → loga "E-mail de confirmação de compra enviado" (se Approved)
```
