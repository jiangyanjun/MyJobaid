using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyJobaid.CodeGenerate.Core
{
    public class GenterateContext
    {
        public string NameSpace { get; set; }
        public string Keyword { get; set; }
        public string DatabaseName { get; set; }
        public string TableName { get; set; }

        public bool Entity { get; set; }
        public bool Abstract { get; set; }
        public bool Provider { get; set; }
        public bool Business { get; set; }
        public bool Handler { get; set; }

        public bool Serializable { get; set; }
        public bool Wcf { get; set; }

        public bool LoadAll { get; set; }
        public bool List { get; set; }
        public bool Count { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Exists { get; set; }
        public bool Get { get; set; }
        public bool GetChild { get; set; }

        public bool Parameter { get; set; }

    }
}
