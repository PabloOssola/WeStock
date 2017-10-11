using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeStock.DAL.Interfaces
{
    public class ResultSet
    {
        public ArrayList Data
        {
            get;
            internal set;
        }

        public string[] Columns
        {
            get;
            internal set;
        }

        public string Name
        {
            get;
            internal set;
        }

        public ResultSet(string name)
        {
            Data = new ArrayList(50);
            Name = name;
        }
    }

    public class DatabaseQueryResult
    {
        public ArrayList ResultSets
        {
            get;
            internal set;
        }
        public DatabaseQueryResult()
        {
            ResultSets = new ArrayList(1);
        }
    }
}
