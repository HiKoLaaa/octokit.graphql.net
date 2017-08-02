namespace Octokit.GraphQL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Octokit.GraphQL.Core;
    using Octokit.GraphQL.Core.Builders;

    /// <summary>
    /// Autogenerated return type of DeleteProjectCard
    /// </summary>
    public class DeleteProjectCardPayload : QueryEntity
    {
        public DeleteProjectCardPayload(IQueryProvider provider, Expression expression) : base(provider, expression)
        {
        }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; }

        /// <summary>
        /// The column the deleted card was in.
        /// </summary>
        public ProjectColumn Column => this.CreateProperty(x => x.Column, Octokit.GraphQL.ProjectColumn.Create);

        /// <summary>
        /// The deleted card ID.
        /// </summary>
        public string DeletedCardId { get; }

        internal static DeleteProjectCardPayload Create(IQueryProvider provider, Expression expression)
        {
            return new DeleteProjectCardPayload(provider, expression);
        }
    }
}