using SharedGrocery.Common.Model;
using SharedGrocery.Models;

namespace SharedGrocery.Uaa.Model
{
    public class User : AbstractEntity
    {
        public string TokenId { get; set; }
        public TokenType TokenType { get; set; }
    }
}