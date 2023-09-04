namespace kart.Core.Dto
{
    public class UserConstants
    {
        public static List<UserModel> Users = new()
            {
                    new UserModel(){ Username="sunny",Password="sunny1234",Role="Seller"},
                    new UserModel(){ Username="surya",Password="surya@12345",Role="Customer"}
            };
    }
}
