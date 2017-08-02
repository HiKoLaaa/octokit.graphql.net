namespace Octokit.GraphQL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// Autogenerated return type of MoveProjectColumn
    /// </summary>
    public class MoveProjectColumnPayload : QueryEntity
    {
        public MoveProjectColumnPayload(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; }

        /// <summary>
        /// The new edge of the moved column.
        /// </summary>
        public ProjectColumnEdge ColumnEdge => this.CreateProperty(x => x.ColumnEdge, Octokit.GraphQL.ProjectColumnEdge.Create);

        internal static MoveProjectColumnPayload Create(IQueryProvider provider, Expression expression)
        {
            return new MoveProjectColumnPayload(provider, expression);
        }
    }
}