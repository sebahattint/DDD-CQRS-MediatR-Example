using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Nest;
using TestProject.Infrastructure.Repositories.Base.Interfaces;

namespace TestProject.Infrastructure.Repositories.Base.Concrete
{
    public class ElasticSearchRepository<TEntity> : IElasticSearchRepository<TEntity> where TEntity : class
    {
        private readonly IConfiguration _configuration;
        private readonly IElasticClient _client;

        public ElasticSearchRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = CreateInstance();
        }
        private ElasticClient CreateInstance()
        {
            var pool = new SingleNodeConnectionPool(new Uri(_configuration["Elastic:Url"]));
            var settings = new ConnectionSettings(pool);
            ////settings.BasicAuthentication
            //var client = new ElasticClient(settings);

            //string host = _configuration.GetSection("ElasticConnectionSettings:ElasticSearchHost").Value;
            //string port = _configuration.GetSection("ElasticConnectionSettings:ElasticSearchPort").Value;
            //string username = _configuration.GetSection("ElasticConnectionSettings:ElasticUsername").Value;
            //string password = _configuration.GetSection("ElasticConnectionSettings:ElasticPassword").Value;

            //var settings = new ConnectionSettings(new Uri(host + ":" + port + "/"));

            //if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            //    settings.BasicAuthentication(username, password);

            return new ElasticClient(settings);
        }

        public async Task<bool> ChekIndex(string indexName)
        {
            var anyy = await _client.Indices.ExistsAsync(indexName);
            if (anyy.Exists)
                return true;

            var response = await _client.Indices.CreateAsync(indexName,
                ci => ci
                    .Index(indexName)
                    .Settings(s => s.NumberOfShards(3).NumberOfReplicas(1))
                    );
            return false;

        }
        public async Task InsertOrUpdateDocument(string indexName, TEntity entity)
        {
            var response = await _client.CreateAsync(entity, q => q.Index(indexName));
            if (response.ApiCall?.HttpStatusCode == 409) 
            {
                await _client.UpdateAsync<TEntity>(entity, a => a.Index(indexName).Doc(entity));
            }
        }

        public async Task RemoveDocument(string indexName, Guid id)
        {
            var response = await _client.DeleteAsync<TEntity>(id, d => d.Index(indexName.ToLower()));
        }

        public async Task InsertDocuments(string indexName, List<TEntity> entity)
        {
            await _client.IndexManyAsync(entity, index: indexName.ToLower());
        }


        public async Task<TEntity> GetDocument(string indexName, Guid id)
        {
            var response = await _client.GetAsync<TEntity>(id, q => q.Index(indexName.ToLower()));

            return response.Source;

        }

        public async Task<List<TEntity>> GetDocuments(string indexName)
        {
            var response = await _client.SearchAsync<TEntity>(q => q.Index(indexName.ToLower()));
            return response.Documents.ToList();
        }

    }
}
