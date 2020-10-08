using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Firebend.AutoCrud.Mongo.Interfaces;
using Firebend.AutoCrud.Mongo.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Firebend.AutoCrud.Mongo.HostedServices
{
    public class MongoMigrationHostedService : IHostedService
    {
        private readonly IEnumerable<IMongoMigration> _migrations;
        private readonly ILogger _logger;
        private readonly IMongoDefaultDatabaseSelector _databaseSelector;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public MongoMigrationHostedService(IEnumerable<IMongoMigration> migrations,
            ILogger<MongoMigrationHostedService> logger,
            IMongoDefaultDatabaseSelector databaseSelector)
        {
            _migrations = migrations;
            _logger = logger;
            _databaseSelector = databaseSelector;
        }

        private async Task DoMigration(CancellationToken cancellationToken)
        {
            var db = _databaseSelector.GetDefaultDb();
            var collection = db.GetCollection<MongoDbMigrationVersion>($"__{nameof(MongoDbMigrationVersion)}");
            
            var maxVersion = await collection.AsQueryable()
                .Select(x => x.Version)
                .OrderByDescending(x => x)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);
            
            foreach (var migration in _migrations
                .Where(x => x.Version.Version > maxVersion)
                .OrderBy(x => x.Version.Version))
            {
                try
                {
                    await migration.ApplyMigrationAsync(cancellationToken).ConfigureAwait(false);
                    await collection.InsertOneAsync(migration.Version, new InsertOneOptions(), cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex, "Error Applying mongo Migrations {Name}, {Version}",
                        migration.Version.Name,
                        migration.Version.Version);
                    break;
                }
            }
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return DoMigration(_cancellationTokenSource.Token);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource.Cancel();
            
            return Task.CompletedTask;
        }
    }
}