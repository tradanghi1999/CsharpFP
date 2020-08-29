using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Entities;
namespace SqlClient
{
    public class DbReader
    {
        
        public DbReader(string connString)
        {
            this.connString = connString;
        }
        string connString;
        public IEnumerable<Team> GetTeams()
            => new ConnectionHelper().Connect(connString, 
                c => c.Query<Team>(@"select * from Team"));

        public IEnumerable<Team> GetTeamsv2()
            => new ConnectionHelper().Connectv2(connString, 
                c => c.Query<Team>(@"select * from Team"));
    }
}
