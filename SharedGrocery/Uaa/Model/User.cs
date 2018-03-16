using SharedGrocery.Common.Model;
using SharedGrocery.Models;

namespace SharedGrocery.Uaa.Model
{
    public class User : AbstractEntity
    {
        public string Token { get; set; }
        public TokenType TokenType { get; set; }
    }
}