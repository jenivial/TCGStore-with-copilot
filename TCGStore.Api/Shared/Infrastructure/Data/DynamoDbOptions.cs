namespace TCGStore.Api.Shared.Infrastructure.Data;

/// <summary>
/// Configuration options for AWS DynamoDB connection
/// </summary>
public class DynamoDbOptions
{
    /// <summary>
    /// The name of the DynamoDB table
    /// </summary>
    public string TableName { get; set; } = string.Empty;

    /// <summary>
    /// The AWS region where DynamoDB is deployed
    /// </summary>
    public string Region { get; set; } = "us-west-2";
}
