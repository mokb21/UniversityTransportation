using System;

namespace UniversityTransportation.Constants
{
    public class ConfigurationConstants
    {
        //public const string ConnectionString = @"Data Source=.;database=UniversityTransportationDB;User Id=sa;Password=sql2018;";
        public const string ConnectionString = @"Server=localhost;Database=UniversityTransportationDB;Trusted_Connection=True;";
        //public const string ConnectionString = @"Data Source=SQL5085.site4now.net;Initial Catalog=DB_A723C7_univtrans;User Id=DB_A723C7_univtrans_admin;Password=univtrans123";

        public const string TokenKey = "UniversityTransportation@YPU!!123456";
        public const string TokenIssuer = "http://localhost:5868";
    }
}
