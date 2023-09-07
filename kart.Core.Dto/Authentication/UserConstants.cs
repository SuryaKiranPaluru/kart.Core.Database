namespace kart.Core.Dto
{
    public class UserConstants
    {
        public static List<UserModel> Users = new()
            {
                    new UserModel(){ Username="seller1",Password="seller11234",Role="Seller",UserId = 1501},

                    new UserModel(){ Username="seller",Password="seller21234",Role="Seller",UserId = 1502},

                    new UserModel(){ Username="surya",Password="surya@12345",Role="Customer", UserId = 1503},

                    new UserModel(){ Username="koti",Password="koti@12345",Role="Customer", UserId = 1504},

                    new UserModel(){ Username="qazi",Password="qazi@12345",Role="Customer", UserId = 1505}
            };
    }
}
