using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Configuration
{
    public class MongoDbSettings
    {
        public string ConnectionString;
        public string Database;

        #region Const Values

        public const string ConnectionStringValue = nameof(ConnectionString);
        public const string DatabaseValue = nameof(Database);

        #endregion
    }
}
