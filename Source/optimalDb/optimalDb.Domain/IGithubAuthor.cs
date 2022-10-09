namespace optimalDb.Domain;

public interface IGithubAuthor
{
    string Login { get; }
    int Id { get; }
    string Node_id { get; }
    string Avatar_url { get; }
    string Gravatar_id { get; }
    string Url { get; }
    string Html_url { get; }
    string Followers_url { get; }
    string Following_url { get; }
    string Gists_url { get; }
    string Starred_url { get; }
    string Subscriptions_url { get; }
    string Organizations_url { get; }
    string Repos_url { get; }
    string Events_url { get; }
    string Received_events_url { get; }
    string Type { get; }
    bool Site_admin { get; }

}