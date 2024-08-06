using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using web_api_curd.BAL;
using web_api_curd.Model;

namespace web_api_curd.DAL
{
    public class User_DALBase : DAL_Helpers
    {
        public  bool API_User_Delete(int parsonID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_DELETE_PERSON");
                sqldb.AddInParameter(cmd, "@ParsonID", SqlDbType.Int, parsonID);
                if (Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
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
                SqlDatabase sqldb = new SqlDatabase(ConnStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_INSERT_PERSON");
                sqldb.AddInParameter(cmd, "@Name", SqlDbType.VarChar, person.Name);
                sqldb.AddInParameter(cmd, "@Email", SqlDbType.VarChar, person.Email);
                sqldb.AddInParameter(cmd, "@Password", SqlDbType.VarChar, person.Password);
                if (Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
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
                SqlDatabase sqldb = new SqlDatabase(ConnStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_UPDATE_PERSON");
                sqldb.AddInParameter(cmd, "@ParsonID", SqlDbType.Int, personID);
                sqldb.AddInParameter(cmd, "@Name", SqlDbType.VarChar, person.Name);
                sqldb.AddInParameter(cmd, "@Email", SqlDbType.VarChar, person.Email);
                sqldb.AddInParameter(cmd, "@Password", SqlDbType.VarChar, person.Password);
                if (Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
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
                SqlDatabase sqldb = new SqlDatabase(ConnStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_PERSON_SelectBYId");
                sqldb.AddInParameter(cmd, "@ParsonID", SqlDbType.Int, parsonID);

                PersonModel parson = new PersonModel();

                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    parson.PersonID = Convert.ToInt16(dr["ParsonID"].ToString());
                    parson.Name = dr["Name"].ToString()!;
                    parson.Email = dr["Email"].ToString()!;
                    parson.Password = dr["Password"].ToString()!;
                }

                return parson;

            }
            catch
            {
                return null;
            }
        }public List<PersonModel> API_User_SelectALL()
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_PERSON_SelectALL");
                List<PersonModel> personList = new List<PersonModel>();

                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        PersonModel person = new PersonModel();
                        person.PersonID = Convert.ToInt16(dr["ParsonID"].ToString());
                        person.Name = dr["Name"].ToString()!;
                        person.Email = dr["Email"].ToString()!;
                        person.Password = dr["Password"].ToString()!;

                        personList.Add(person);
                    }
                }

                return personList;

            }
            catch
            {
                return null;
            }
        }
    }
}
