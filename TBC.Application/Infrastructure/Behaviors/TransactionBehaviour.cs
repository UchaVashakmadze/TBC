using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using TBC.Domain.SeedWork;

namespace TBC.Application.Infrastructure.Behaviors
{
    public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TransactionBehaviour<TRequest, TResponse>> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionBehaviour(IUnitOfWork unitOfWork, ILogger<TransactionBehaviour<TRequest, TResponse>> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentException(null, nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentException(null, nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                _logger.LogInformation($"Begin transaction {typeof(TRequest).Name}");

                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var response = await next();

                await _unitOfWork.CommitTransactionAsync(cancellationToken);
                
                _logger.LogInformation($"Committed transaction {typeof(TRequest).Name}");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Rollback transaction executed {typeof(TRequest).Name}; \n {ex}");

                await _unitOfWork.RollbackTransactionAsync(cancellationToken);
                
                throw;
            }
        }
    }
}
