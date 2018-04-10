using SharedGrocery.Common.Config;
using SharedGrocery.Common.Model;
using SharedGrocery.Common.Rest;

namespace SharedGrocery.Tests.TestUtil.Rest
{
    public class TestBaseController : BaseController
    {
        public TestBaseController(ApiConfig apiConfig) : base(apiConfig)
        {
        }

        public UserContext CallGetUserContext()
        {
            return GetUserContext();
        }
    }
}