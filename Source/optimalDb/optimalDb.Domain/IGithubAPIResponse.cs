

namespace optimalDb.Domain;
public interface IGithubAPIResponse
{
    string Url { get; }
    string Assets_url { get; }
    string Upload_url { get; }
    string Html_url { get; }
    int Id { get; }
    IGithubAuthor Author { get; }
    string Node_id { get; }
    string Tag_name { get; }
    string Target_commitish { get; }
    string Name { get; }
    bool Draft { get; }
    bool Prerelease { get; }
    DateTime Created_at { get; }
    DateTime Published_at { get; }
    IGithubReleaseAsset[] Assets { get; }
    string Tarball_url { get; }
    string Zipball_url { get; }
    string Body { get; }

}