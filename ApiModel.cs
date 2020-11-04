using Kmd.Logic.Thor.DocumentStore;
using Kmd.Logic.Common.Modules;
using Marten.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Kmd.Logic.Gateway.Apis
{
    [SoftDeleted]
    [UseOptimisticConcurrency]
    [AutoCreateDocumentCollection]
    [DocumentMappable("Api")]
    [SuppressMessage("SonarAnalyzer.CSharp", "S107", Justification = "This is the base data as per ApiContract hence cannot avoid them.")]
    public class ApiModel : IDocument
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public Guid ProviderId { get; private set; }
        public Uri BackendServiceUrl { get; private set; }
        public string ApiVersion { get; private set; }
        public ICollection<Guid> ProductIds { get; private set; }
        public Uri LogoUrl { get; private set; }
        public Uri DocumentationUrl { get; private set; }
        public GatewayVisibility Visibility { get; private set; }

        public Guid? ApiVersionSetId { get; private set; }
        public GatewaySynchronization Synchronization { get; private set; }
        public ApiStatus? Status { get; private set; }
        public bool? IsCurrent { get; private set; }

        public ApiModel(
            Guid id,
            string name,
            string path,
            Guid providerId,
            Uri backendServiceUrl,
            string apiVersion,
            ICollection<Guid> productIds,
            Uri logoUrl,
            Uri documentationUrl,
            GatewayVisibility visibility,
            Guid? apiVersionSetId = null,
            ApiStatus? status = null,
            bool? isCurrent = null,
            GatewaySynchronization synchronization = GatewaySynchronization.Pending)
        {
            Id = id;
            Name = name;
            Path = path;
            ProviderId = providerId;
            BackendServiceUrl = backendServiceUrl;
            ApiVersion = apiVersion;
            ProductIds = productIds ?? new List<Guid>();
            LogoUrl = logoUrl;
            DocumentationUrl = documentationUrl;
            Visibility = visibility;
            ApiVersionSetId = apiVersionSetId;
            Status = status;
            IsCurrent = isCurrent;
            Synchronization = synchronization;
        }

        public void SetSynchronization(GatewaySynchronization newState)
        {
            Synchronization = newState;
        }

        public void UpdateProducts(ICollection<Guid> productIds)
        {
            ProductIds = productIds ?? throw new ArgumentNullException(nameof(productIds));
            Synchronization = GatewaySynchronization.Pending;
        }

        public void UpdateLinks(Uri logoUrl, Uri documentationUrl)
        {
            LogoUrl = logoUrl;
            DocumentationUrl = documentationUrl;
            Synchronization = GatewaySynchronization.Pending;
        }

        public void SetApiVersionSet(Guid apiVersionSetId)
        {
            if (apiVersionSetId == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(apiVersionSetId)} cannot be empty", nameof(apiVersionSetId));
            }

            ApiVersionSetId = apiVersionSetId;
        }

        public void SetApiId(Guid apiId)
        {
            Id = apiId;
        }

        public void ClearCurrentStatus()
        {
            IsCurrent = false;
        }

        public void SetBackendServiceUrlAsNull()
        {
            BackendServiceUrl = null;
        }

        public void SetCurrentStatus()
        {
            IsCurrent = true;
        }

        public void Update(
            string name,
            GatewayVisibility visibility,
            string apiVersion, 
            Uri backendServiceURL,
            ApiStatus status,
            ICollection<Guid> productIds)
        {
            Name = name;
            Visibility = visibility;
            ApiVersion = apiVersion;
            BackendServiceUrl = backendServiceURL;
            ProductIds = productIds;
            Synchronization = GatewaySynchronization.Pending;
            Status = status;
        }
    }
}
