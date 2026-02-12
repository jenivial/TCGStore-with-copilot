namespace TCGStore.Api.Shared.Infrastructure.Data;

/// <summary>
/// Configuration options for AWS DynamoDB connection
/// </summary>
public class AwsOptions
{
    /// <summary>
    /// The AWS region where DynamoDB is deployed
    /// </summary>
    public string Region { get; set; } = "us-west-2";
}
