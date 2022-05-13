using LoginWebForm.DL;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LoginWebForm.Models
{
    public class UserModel
    {
        [Required]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }


        public List<UserModel> GetUser()
        {
            string query = "select * from AspNetUsers";
            List<UserModel> list = new List<UserModel>();
            DataTable dt = Helper.GetDataTable(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserModel obj = new UserModel();
                obj.Id = Convert.ToString(dt.Rows[i]["Id"]);
                obj.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                obj.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                obj.Email = Convert.ToString(dt.Rows[i]["Email"]);
                obj.PasswordHash = Convert.ToString(dt.Rows[i]["PasswordHash"]);
                list.Add(obj);
            }
            return list;
        }
    }
}
