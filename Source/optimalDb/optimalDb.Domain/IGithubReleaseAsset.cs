namespace optimalDb.Domain;

public interface IGithubReleaseAsset
{
    string Url { get; }
    int Id { get; }
    string Node_id { get; }
    string Name { get; }
    string Label { get; }
    IGithubReleaseUploader Uploader { get; }
    string Content_type { get; }
    string State { get; }
    int Size { get; }
    int Download_count { get; }
    DateTime Created_at { get; }
    DateTime Updated_at { get; }
    string Browser_download_url { get; }

}