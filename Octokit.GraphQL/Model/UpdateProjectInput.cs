namespace Octokit.GraphQL.Model
{
    using System.Linq;

    /// <summary>
    /// Autogenerated input type of UpdateProject
    /// </summary>
    public class UpdateProjectInput
    {
        public string ClientMutationId { get; set; }

        public string ProjectId { get; set; }

        public string Name { get; set; }

        public string Body { get; set; }

        public ProjectState? State { get; set; }

        public bool? Public { get; set; }
    }
}