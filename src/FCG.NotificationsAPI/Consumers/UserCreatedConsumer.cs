using FCG.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FCG.NotificationsAPI.Consumers;

public class UserCreatedConsumer : IConsumer<UserCreatedEvent>
{
    private readonly ILogger<UserCreatedConsumer> _logger;

    public UserCreatedConsumer(ILogger<UserCreatedConsumer> logger) => _logger = logger;

    public Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        var evt = context.Message;

        _logger.LogInformation(
            "[EMAIL SIMULADO] Boas-vindas enviado para: {Email} | Usuário: {Name} (Id: {UserId})",
            evt.Email, evt.Name, evt.UserId);

        _logger.LogInformation(
            "[EMAIL SIMULADO] Assunto: Bem-vindo à FIAP Cloud Games, {Name}! | " +
            "Mensagem: Sua conta foi criada com sucesso. Aproveite nossa biblioteca de jogos!",
            evt.Name);

        return Task.CompletedTask;
    }
}
