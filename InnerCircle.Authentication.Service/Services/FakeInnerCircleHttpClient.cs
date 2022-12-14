namespace InnerCircle.Authentication.Service.Services
{
    public class FakeInnerCircleHttpClient : IInnerCircleHttpClient
    {
        public Task SendPasswordCreatingLink(string email, string token)
        {
            return Task.CompletedTask;
        }

        public Task SendPasswordResetLink(string email, string token)
        {
            return Task.CompletedTask;
        }

        public async Task<List<string>> GetPrivileges(long accountId)
        {
            return new List<string>
            {
                "CanViewFinanceForPayroll",
                "CanViewAnalytic",
                "CanManageEmployees",
            };
        }
    }
}
