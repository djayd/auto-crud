using Firebend.AutoCrud.Core.Abstractions.Builders;
using Firebend.AutoCrud.Core.Configurators;
using Firebend.AutoCrud.Core.Interfaces.Models;

namespace Firebend.AutoCrud.DomainEvents.MassTransit.Extensions
{
    public static class DomainEventConfiguratorExtensions
    {
        public static DomainEventsConfigurator<TBuilder, TKey, TEntity> WithMassTransit<TBuilder, TKey, TEntity>(
            this DomainEventsConfigurator<TBuilder, TKey, TEntity> source)
            where TBuilder : EntityCrudBuilder<TKey, TEntity>
            where TKey : struct
            where TEntity : class, IEntity<TKey>
        {
            source.WithDomainEventPublisher<MassTransitDomainEventPublisher>();
            
            return source;
        }
    }
}