
namespace WorldLineTestSolution.Constants
{
    public static class Constants
    {
        public static List<string> TabNamesFromDocumentation = new List<string>()
            {
                { "Home" },
                { "Support" },
                { "Configuration" },
                { "Advanced" },
                { "Operations" }
            };

        public static List<string> SubTabNamesForConfigurations = new List<string>()
        {
            { "Password" },
            { "Account" },
            { "Payment methods" },
            { "Users" },
            { "Alias" },
            { "Technical information" },
            { "Template" },
            { "Create production account" },
            { "Error logs" }
        };

        public static List<string> SubTabNamesForAdvanced = new List<string>()
        {
            { "Fraud detection" },
            { "Subscription" }
        };

        public static List<string> SubTabNamesForOperations = new List<string>()
        {
            { "Financial history" },
            { "New transaction" },
            { "View transactions" },
            { "Electronic reporting" },
            { "Batch Manager" }
        };
    }
}
