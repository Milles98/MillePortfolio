namespace ProjectApi.User
{
    public class UserCredentials
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() // Full read/write access
            {
                UserName = "Mille",
                EmailAddress = "mille.elfver98@gmail.com",
                Password = "Nånting om kungen, ändra!",
                GivenName = "Mille",
                SurName = "Elfver",
                Role = "Admin",
            },
        };
    }

}
