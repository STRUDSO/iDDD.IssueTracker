using System.Collections.Generic;
using SaasOvation.IssueTrack.Domain.Model.Tenants;
using System.Linq;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class Product
    {
        private readonly IList<Issue> _issues;

        public Product(ProductId id, TenantId tenantId, string name, string description,
                       ProductManager productManager, IssueAssigner assigner, IEnumerable<Issue> issues = null)
        {
            Id = id;
            TenantId = tenantId;
            Name = name;
            Description = description;
            ProductManager = productManager;
            IssueAssigner = assigner;
            _issues = (issues ?? Enumerable.Empty<Issue>()).ToList();
        }

        public ProductId Id { get; private set; }
        public TenantId TenantId { get; private set; }
        
        public IssueAssigner IssueAssigner { get; private set; }
        public ProductManager ProductManager { get; private set; }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<Issue> Issues
        {
            get { return _issues; }
        }

        public void ReportDefect(string summary, string description)
        {
            _issues.Add(new Issue(new IssueId(), summary, description, IssueType.Defect));
        }

        public void ReportFeature(string summary, string description)
        {
            _issues.Add(new Issue(new IssueId(), summary, description, IssueType.Feature));
        }

        public double WeightedTotal(SeverityWeights severityWeights)
        {
            return SeverityTotals().Weighted(severityWeights);
        }

        private SeverityTotals SeverityTotals()
        {
            var count = _issues.Where(x => x.Type == IssueType.Defect).ToArray();
            var severityTotals = new SeverityTotals(count.Count(x => x.Priority == IssuePriority.Low),
                                                    count.Count(x => x.Priority == IssuePriority.Medium),
                                                    count.Count(x => x.Priority == IssuePriority.High));
            return severityTotals;
        }
    }
}