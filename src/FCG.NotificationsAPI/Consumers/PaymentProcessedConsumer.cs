using FCG.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FCG.NotificationsAPI.Consumers;

public class PaymentProcessedConsumer : IConsumer<PaymentProcessedEvent>
{
    private readonly ILogger<PaymentProcessedConsumer> _logger;

    public PaymentProcessedConsumer(ILogger<PaymentProcessedConsumer> logger) => _logger = logger;

    public Task Consume(ConsumeContext<PaymentProcessedEvent> context)
    {
        var evt = context.Message;

        if (evt.Status == "Approved")
        {
            _logger.LogInformation(
                "[EMAIL SIMULADO] Confirmação de compra enviado para UserId: {UserId} | " +
                "OrderId: {OrderId} | GameId: {GameId}",
                evt.UserId, evt.OrderId, evt.GameId);

            _logger.LogInformation(
                "[EMAIL SIMULADO] Assunto: Compra confirmada! | " +
                "Mensagem: Sua compra do jogo {GameId} foi aprovada. Bom jogo!",
                evt.GameId);
        }
        else
        {
            _logger.LogInformation(
                "[EMAIL SIMULADO] Notificação de falha de pagamento para UserId: {UserId} | " +
                "OrderId: {OrderId} | Status: {Status}",
                evt.UserId, evt.OrderId, evt.Status);
        }

        return Task.CompletedTask;
    }
}
