using Pulumi;
using Pulumi.Azure.Core;
using Pulumi.Azure.Storage;

class MyStack : Stack
{
    public MyStack()
    {
        // Create an Azure Resource Group
        var resourceGroup = new ResourceGroup("pulumi-test-rg", new ResourceGroupArgs
        {
            Name = "pulumi-test-rg"
        });

        // Create an Azure Storage Account
        var storageAccount = new Account("tpulumitest", new AccountArgs
        {
            Name = "tpulumitest",
            ResourceGroupName = resourceGroup.Name,
            AccountReplicationType = "LRS",
            AccountTier = "Standard"
        });
        
        // Export the connection string for the storage account
        this.ConnectionString = storageAccount.PrimaryConnectionString;
    }

    [Output]
    public Output<string> ConnectionString { get; set; }
}
