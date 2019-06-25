namespace Octokit.GraphQL.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Autogenerated input type of UpdatePullRequest
    /// </summary>
    public class UpdatePullRequestInput
    {
        /// <summary>
        /// The Node ID of the pull request.
        /// </summary>
        public ID PullRequestId { get; set; }

        /// <summary>
        /// The name of the branch you want your changes pulled into. This should be an existing branch
        /// on the current repository.
        /// </summary>
        public string BaseRefName { get; set; }

        /// <summary>
        /// The title of the pull request.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The contents of the pull request.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Indicates whether maintainers can modify the pull request.
        /// </summary>
        public bool? MaintainerCanModify { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        public string ClientMutationId { get; set; }
    }
}