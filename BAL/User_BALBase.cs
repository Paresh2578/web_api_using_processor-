using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using web_api_curd.DAL;
using web_api_curd.Model;

namespace web_api_curd.BAL
{
    public class User_BALBase
    {
        public  bool API_User_Delete(int parsonID)
        {
            try
            {
                User_DALBase dalUser = new User_DALBase();
                if (dalUser.API_User_Delete(parsonID))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool API_User_Insert(PersonModel person)
        {
            try
            {
                User_DALBase dalUser = new User_DALBase();
                if (dalUser.API_User_Insert(person))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool API_User_Update(int personID,PersonModel person)
        {
            try
            {
                User_DALBase dalUser = new User_DALBase();
                if (dalUser.API_User_Update(personID , person))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public PersonModel API_User_SelectById(int parsonID)
        {
            try
            {
                User_DALBase dalUser = new User_DALBase();
                return dalUser.API_User_SelectById(parsonID);
            }
            catch
            {
                return null;
            }
        } 
        public List<PersonModel> API_User_SelectALL()
        {
            try
            {
                User_DALBase dalUser = new User_DALBase();

                return dalUser.API_User_SelectALL();
                 
            }
            catch
            {
                return null;
            }
        }
    }
}
