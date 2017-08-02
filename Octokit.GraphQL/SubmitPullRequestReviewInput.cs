namespace Octokit.GraphQL
{
    using System;
    using System.Linq;

    /// <summary>
    /// Autogenerated input type of SubmitPullRequestReview
    /// </summary>
    public class SubmitPullRequestReviewInput
    {
        public string ClientMutationId { get; set; }

        public string PullRequestReviewId { get; set; }

        public PullRequestReviewEvent Event { get; set; }

        public string Body { get; set; }
    }
}