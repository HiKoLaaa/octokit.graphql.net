namespace Octokit.GraphQL
{
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// Autogenerated return type of RemoveStar
    /// </summary>
    public class RemoveStarPayload : QueryEntity
    {
        public RemoveStarPayload(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; }

        /// <summary>
        /// The starrable.
        /// </summary>
        public IStarrable Starrable => this.CreateProperty(x => x.Starrable, Octokit.GraphQL.Internal.StubIStarrable.Create);

        internal static RemoveStarPayload Create(IQueryProvider provider, Expression expression)
        {
            return new RemoveStarPayload(provider, expression);
        }
    }
}