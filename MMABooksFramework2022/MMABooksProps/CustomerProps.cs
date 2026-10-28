using MMABooksTools;
using System;


using DBDataReader = MySql.Data.MySqlClient.MySqlDataReader;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace MMABooksProps
{
    [Serializable()]

    public class CustomerProps : IBaseProps 
    {
        #region Auto-implemented Properties 
        //this is from the table from mysqlWork bench
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public int CustomerID { get; set; } = 0;
        public string Name { get; set; } = "";
        public string State { get; set; } = "";
        public string ZipCode { get; set; } = "";

        /// <summary>
        /// ConcurrencyID. Don't manipulate directly.
        /// </summary>
        public int ConcurrencyID { get; set; } = 0;
        #endregion
        public object Clone()
        {
            CustomerProps p = new CustomerProps();
            p.Address = this.Address;
            p.City = this.City;
            p.CustomerID = this.CustomerID;
            p.Name = this.Name;
            p.State = this.State;
            p.ZipCode = this.ZipCode;
            p.ConcurrencyID = this.ConcurrencyID;
            return p;
        }

        // this is always the same ... so I should have made IBaseProps and abstract class
        public string GetState()
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(this);
            return jsonString;
        }

        public void SetState(string jsonString)
        {
            CustomerProps p = JsonSerializer.Deserialize<CustomerProps>(jsonString);
            this.Address = p.Address;
            this.City = p.City;
            this.CustomerID = p.CustomerID;
            this.Name = p.Name;
            this.State = p.State;
            this.ZipCode = p.ZipCode;
            this.ConcurrencyID = p.ConcurrencyID;
        }

        public void SetState(DBDataReader dr)
        {
            this.Address = (string)dr["Address"];
            this.City = (string)dr["City"];
            this.CustomerID = (Int32)dr["CustomerID"];
            this.Name = (string)dr["Name"];
            this.State = ((string)dr["State"]).Trim();
            this.ZipCode = ((string)dr["ZipCode"]).Trim();
            this.ConcurrencyID = (Int32)dr["ConcurrencyID"];
        }
    }
}
