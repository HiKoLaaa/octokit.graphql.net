namespace Octokit.GraphQL
{
    using System;
    using System.Linq;

    /// <summary>
    /// Autogenerated input type of DismissPullRequestReview
    /// </summary>
    public class DismissPullRequestReviewInput
    {
        public string ClientMutationId { get; set; }

        public string PullRequestReviewId { get; set; }

        public string Message { get; set; }
    }
}