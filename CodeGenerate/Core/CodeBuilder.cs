using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyJobaid.CodeGenerate.Core
{
    public class CodeBuilder
    {
        //关键字数组
        private static string[] keys = new string[]{"using","namespace","private","public","class"
                                            ,"#region","#endregion","new","string","int","float"
                                            ,"double","void","object","value","return","set","get","abstract","base","bool","override","while"
                                            };
        private static string[] classes = new string[] { "Serializable", "IComparable", "IComparer", "", "DataContract", "DataMember","List" };
        //特殊符号数组
        private static char[] marks = new char[] { ' ', '\n', ';', ':', '{', '}', '[', ']', '/', '<', '>', '(', ')' };

        public static void BuildEntityCode(SQLDBInfo db ,GenterateContext context, System.Windows.Forms.RichTextBox txtCode)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Text;");
            if(context.Wcf)
            {
                sb.Append("using System.Runtime.Serialization;");
            }
            sb.AppendLine();
            if (!string.IsNullOrEmpty(context.NameSpace))
            {
                sb.AppendLine("namespace " + context.NameSpace + ".Entity");
                sb.AppendLine("{");
                count++;
            }
            if (context.Serializable)
            {
                sb.AppendLine(SetSpace(count) + "[Serializable]");
            }
            if (context.Wcf)
            {
                sb.AppendLine(SetSpace(count) + "[DataContract]");
            }          
            sb.AppendLine(SetSpace(count) + "public class " + context.Keyword);
            sb.AppendLine(SetSpace(count) + "{");
            count++;
            foreach (ColumnInfo column in db.GetTableColumns(context.DatabaseName, context.TableName))
            {
                if (context.Wcf)
                {
                    sb.AppendLine(SetSpace(count) + "[DataMember]");
                }
                sb.AppendLine(SetSpace(count) + "public " + GetType(column.ColumnType) + " " + UpperLetter(column.ColumnName) + "{ get; set; }");
                sb.AppendLine("");
            }
            count--;
            sb.AppendLine(SetSpace(count) + "}");
            if (!string.IsNullOrEmpty(context.NameSpace))
            {             
                sb.AppendLine("}");
            }
            txtCode.Text = sb.ToString();
            SetKeyColor(txtCode);
            SetColor(txtCode);
        }


        public static void BuildAbstractCode(SQLDBInfo db, GenterateContext context, System.Windows.Forms.RichTextBox txtCode)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Text;");
            if (!string.IsNullOrEmpty(context.NameSpace))
            {
                sb.AppendLine("using " + context.NameSpace + ".Entity;");
                sb.AppendLine("namespace " + context.NameSpace + ".Provider");
                sb.AppendLine("{");
                count++;
            }
            sb.AppendLine(SetSpace(count) + "public abstract class " + context.Keyword + "Provider : BaseProvider<" + context.Keyword + "> ");
            sb.AppendLine(SetSpace(count) + "{");
            count++;
            sb.AppendLine(SetSpace(count) + "public " + context.Keyword + "Provider()");
            sb.AppendLine(SetSpace(count) + "    : base(\"" + context.Keyword + "Provider\")");
            sb.AppendLine(SetSpace(count) + "{");
            sb.AppendLine(SetSpace(count) + "    TableName = \"" + context.TableName + "\";");
            sb.AppendLine(SetSpace(count) + "}");

            sb.AppendLine("");
            if (context.LoadAll)
            {
                sb.AppendLine(SetSpace(count) + "public abstract List<" + context.Keyword + "> LoadAll();");
            }
            if (context.Count)
            {
                sb.AppendLine(SetSpace(count) + "public abstract int Count(string strKey);");
            }
            if (context.List)
            {
                sb.AppendLine(SetSpace(count) + "public abstract List<" + context.Keyword + "> List(string strKey, int iPageIndex, int iPageSize);");
            }           
            if (context.Create)
            {
                sb.AppendLine(SetSpace(count) + "public abstract bool Create(" + context.Keyword + " model);");
            }
            if (context.Update)
            {
                sb.AppendLine(SetSpace(count) + "public abstract bool Update(" + context.Keyword + " model);");
            }
            if (context.Delete)
            {
                sb.AppendLine(SetSpace(count) + "public abstract bool Delete(int id);");
            }
            if (context.Exists)
            {
                sb.AppendLine(SetSpace(count) + "public abstract bool Exist(string strKey, int id);");
            }
            if (context.Get)
            {
                sb.AppendLine(SetSpace(count) + "public abstract " + context.Keyword + " Get(int iId);");
            }
            if (context.GetChild)
            {
                sb.AppendLine(SetSpace(count) + "public abstract List<" + context.Keyword + "> GetChild(int iParentId);");
            }
            count--;
            sb.AppendLine(SetSpace(count) + "}");
            if (!string.IsNullOrEmpty(context.NameSpace))
            {
                sb.AppendLine("}");
            }
            txtCode.Text = sb.ToString();
            SetKeyColor(txtCode);
            SetColor(txtCode);
        }


        public static void BuildProviderCode(SQLDBInfo db, GenterateContext context, System.Windows.Forms.RichTextBox txtCode)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            List<ColumnInfo> lstColumn = db.GetTableColumns(context.DatabaseName, context.TableName);
            if (lstColumn.Count == 0)
            {
                return;
            }
            ColumnInfo pkColumn = lstColumn.Where(s => s.IsPk == true).First();
            if (pkColumn == null)
            {
                pkColumn = new ColumnInfo();
            }
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Data.SqlClient;");
            sb.AppendLine("using System.Dmq.Data;");
            if (!string.IsNullOrEmpty(context.NameSpace))
            {
                sb.AppendLine("using " + context.NameSpace + ".Entity;");
                sb.AppendLine("namespace " + context.NameSpace + ".SqlProvider");
                sb.AppendLine("{");
                count++;
                sb.AppendLine(SetSpace(count) + "public abstract class " + context.Keyword + "Provider : " + context.NameSpace + ".Provider." + context.Keyword + "Provider");
            }
            else
            {
                sb.AppendLine(SetSpace(count) + "public abstract class " + context.Keyword + "Provider : Provider." + context.Keyword + "Provider");
            }
            sb.AppendLine(SetSpace(count) + "{");
            count++;

            sb.AppendLine("");
            if (context.LoadAll || context.List || context.Get || context.GetChild)
            {
                sb.AppendLine(SetSpace(count) + "public void Fill(" + context.Keyword + " model, IDataReader reader)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                foreach (ColumnInfo column in lstColumn)
                {
                    if (column.ColumnType.ToLower().IndexOf("int") > 0 && column.ColumnType.ToLower() != "money" && column.ColumnType.ToLower() != "smallmoney")
                    {
                        sb.AppendLine(SetSpace(count) + "model." + column.ColumnName + " = int.Parse(reader[\"" + column.ColumnName + "\"].ToString());");
                    }
                    else if (column.ColumnType.ToLower() == "money" || column.ColumnType.ToLower() == "smallmoney")
                    {
                        sb.AppendLine(SetSpace(count) + "model." + column.ColumnName + " = decimal.Parse(reader[\"" + column.ColumnName + "\"].ToString());");
                    }
                    else if (column.ColumnType.ToLower() == "datetime" || column.ColumnType.ToLower() == "smdlldatetime")
                    {
                        sb.AppendLine(SetSpace(count) + "model." + column.ColumnName + " = DateTime.Parse(reader[\"" + column.ColumnName + "\"].ToString());");
                    }
                    else
                    {
                        sb.AppendLine(SetSpace(count) + "model." + column.ColumnName + " = reader[\"" + column.ColumnName + "\"].ToString();");
                    }
                }
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }
            if (context.LoadAll)
            {
                sb.AppendLine(SetSpace(count) + "public override List<" + context.Keyword + "> LoadAll()");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "StringBuilder sb = new StringBuilder();");
                sb.AppendLine(SetSpace(count) + "sb.Append(\"SELECT * FROM \"+ TableName +\"\");");

                sb.AppendLine(SetSpace(count) + "List<" + context.Keyword + "> listModel = new List<" + context.Keyword + ">();");
                sb.AppendLine(SetSpace(count) + "" + context.Keyword + " model = new " + context.Keyword + "();");
                sb.AppendLine(SetSpace(count) + "using (SqlDataReader reader = SQLHelper.ExecuteReader(ConnectionString, CommandType.Text, sb.ToString(), null))");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "while (reader.Read())");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "model = new " + context.Keyword + "();");
                sb.AppendLine(SetSpace(count) + "Fill(model, reader);");
                sb.AppendLine(SetSpace(count) + "listModel.Add(model);");
                count--;
                sb.AppendLine(SetSpace(count) + "}");
                count--;
                sb.AppendLine(SetSpace(count) + "}");
                sb.AppendLine(SetSpace(count) + "return listModel;");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }

            if(context.Count)
            {
                sb.AppendLine(SetSpace(count) + "public override int Count(string strKey)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "StringBuilder sb = new StringBuilder();");
                sb.AppendLine(SetSpace(count) + "sb.Append(\"SELECT COUNT(1) FROM \"+ TableName +\" WHERE 1=1 \");");
                sb.AppendLine(SetSpace(count) + "if(!string.IsNullOrEmpty(strKey))");
                sb.AppendLine(SetSpace(count) + "{");
                sb.AppendLine(SetSpace(count) + "    //input your judgment statement");
                sb.AppendLine(SetSpace(count) + "}");
                sb.AppendLine(SetSpace(count) + "SqlParameter[] ps = new SqlParameter[]{");
                sb.AppendLine(SetSpace(count) + "    new SqlParameter(\"Key\", SqlDbType.NVarChar)");
                sb.AppendLine(SetSpace(count) + "};");
                sb.AppendLine(SetSpace(count) + "ps[0].Value = strKey;");
                sb.AppendLine(SetSpace(count) + "return int.Parse(SQLHelper.ExecuteScalar(ConnectionString, CommandType.Text, sb.ToString(), ps).ToString());");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }

            if (context.List)
            {
                sb.AppendLine(SetSpace(count) + "public override List<" + context.Keyword + "> List(string strKey, int iPageIndex, int iPageSize)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "StringBuilder sb = new StringBuilder();");
                sb.AppendLine(SetSpace(count) + "if(!string.IsNullOrEmpty(strKey))");
                sb.AppendLine(SetSpace(count) + "{");
                sb.AppendLine(SetSpace(count) + "    //input your judgment statement");
                sb.AppendLine(SetSpace(count) + "}");
                sb.AppendLine(SetSpace(count) + "SqlParameter[] ps = SQLHelper.BuildPagerParams(");
                sb.AppendLine(SetSpace(count) + "        TableName,");
                sb.AppendLine(SetSpace(count) + "        \"*\",");
                sb.AppendLine(SetSpace(count) + "        \"Id Asc\",");
                sb.AppendLine(SetSpace(count) + "        iPageIndex,");
                sb.AppendLine(SetSpace(count) + "        iPageSize,");
                sb.AppendLine(SetSpace(count) + "        sb.ToString(),");
                sb.AppendLine(SetSpace(count) + "        \"\"");
                sb.AppendLine(SetSpace(count) + "    );");
                sb.AppendLine(SetSpace(count) + "List<" + context.Keyword + "> listModel = new List<" + context.Keyword + ">();");
                sb.AppendLine(SetSpace(count) + "" + context.Keyword + " model = new " + context.Keyword + "();");
                sb.AppendLine(SetSpace(count) + "using (SqlDataReader reader = SQLHelper.ExecuteReader(ConnectionString, CommandType.StoredProcedure, PagerName, null))");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "while (reader.Read())");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "model = new " + context.Keyword + "();");
                sb.AppendLine(SetSpace(count) + "Fill(model, reader);");
                sb.AppendLine(SetSpace(count) + "listModel.Add(model);");
                count--;
                sb.AppendLine(SetSpace(count) + "}");
                count--;
                sb.AppendLine(SetSpace(count) + "}");
                sb.AppendLine(SetSpace(count) + "return listModel;");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }

            if (context.Create)
            {
                string strInsertColumn = "";
                string strInsertParams = "";
                foreach (ColumnInfo column in lstColumn)
                {
                    if(column.ColumnType.ToLower().IndexOf("identity") < 0 )
                    {
                        strInsertColumn += column.ColumnName + ",";
                        strInsertParams += "@" + column.ColumnName + ",";
                    }
                }
                strInsertColumn = strInsertColumn.Substring(0, strInsertColumn.Length - 1);
                strInsertParams = strInsertParams.Substring(0, strInsertParams.Length - 1);
                sb.AppendLine(SetSpace(count) + "public override bool Create(" + context.Keyword + " model)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "StringBuilder sb = new StringBuilder();");
                sb.AppendLine(SetSpace(count) + "sb.Append(\"INSERT INTO \"+ TableName +\"(" + strInsertColumn + ")\");");
                sb.AppendLine(SetSpace(count) + "sb.Append(\"VALUES(" + strInsertParams + ") \");");
                sb.AppendLine(SetSpace(count) + "SqlParameter[] ps = new SqlParameter[]{"); 
                count++;
                int i = 1;
                foreach (ColumnInfo column in lstColumn.Where(s => s.ColumnType.IndexOf("identity") < 0).ToList())
                {
                    if (column.ColumnType.ToLower() == "int" || column.ColumnType.ToLower() == "smallint" || column.ColumnType.ToLower() == "tinyint")
                    {
                        sb.AppendLine(SetSpace(count) + "new SqlParameter(\"" + column.ColumnName + "\", SqlDbType.Int)" + ((i == lstColumn.Count) ? "" : ",") + "");
                    }
                    else if (column.ColumnType.ToLower() == "float" || column.ColumnType.ToLower() == "decimal")
                    {
                        sb.AppendLine(SetSpace(count) + "new SqlParameter(\"" + column.ColumnName + "\", SqlDbType.Decimal)" + ((i == lstColumn.Count) ? "" : ",") + "");
                    }
                    else
                    {
                        sb.AppendLine(SetSpace(count) + "new SqlParameter(\"" + column.ColumnName + "\", SqlDbType.NVarChar)" + ((i == lstColumn.Count) ? "" : ",") + "");
                    }
                    i++;
                }               
                count--;
                sb.AppendLine(SetSpace(count) + "};");
                i = 0;
                foreach (ColumnInfo column in lstColumn.Where(s => s.ColumnType.IndexOf("identity") < 0).ToList())
                {
                    sb.AppendLine(SetSpace(count) + "ps[" + i + "].Value = model." + column.ColumnName + ";");
                    i++;
                }
                sb.AppendLine(SetSpace(count) + "return SQLHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sb.ToString(), ps) > 0;");               
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }

            if (context.Update)
            {
                int i = 1;
                sb.AppendLine(SetSpace(count) + "public override bool Update(" + context.Keyword + " model)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "StringBuilder sb = new StringBuilder();");
                sb.AppendLine(SetSpace(count) + "sb.Append(\"UPDATE \"+ TableName +\" SET \");");
                foreach (ColumnInfo column in lstColumn.Where(s => s.IsPk == false).ToList())
                {
                    sb.AppendLine(SetSpace(count) + "sb.Append(\"" + column.ColumnName + " = @" + column.ColumnName + "" + ((i == lstColumn.Where(s => s.IsPk == false).ToList().Count) ? "" : ",") + "\");");
                    i++;
                }
                sb.AppendLine(SetSpace(count) + "sb.Append(\" WHERE " + pkColumn.ColumnName + "=@" + pkColumn.ColumnName + "\");");
                sb.AppendLine(SetSpace(count) + "SqlParameter[] ps = new SqlParameter[]{");
                count++;
                foreach (ColumnInfo column in lstColumn)
                {
                    if (column.ColumnType.ToLower() == "int" || column.ColumnType.ToLower() == "smallint" || column.ColumnType.ToLower() == "tinyint")
                    {
                        sb.AppendLine(SetSpace(count) + "new SqlParameter(\"" + column.ColumnName + "\", SqlDbType.Int)" + ((i == lstColumn.Count) ? "" : ",") + "");
                    }
                    else if (column.ColumnType.ToLower() == "float" || column.ColumnType.ToLower() == "decimal")
                    {
                        sb.AppendLine(SetSpace(count) + "new SqlParameter(\"" + column.ColumnName + "\", SqlDbType.Decimal)" + ((i == lstColumn.Count) ? "" : ",") + "");
                    }
                    else
                    {
                        sb.AppendLine(SetSpace(count) + "new SqlParameter(\"" + column.ColumnName + "\", SqlDbType.NVarChar)" + ((i == lstColumn.Count) ? "" : ",") + "");
                    }
                    i++;
                }
                count--;
                sb.AppendLine(SetSpace(count) + "};");
                i = 0;
                foreach (ColumnInfo column in lstColumn)
                {
                    sb.AppendLine(SetSpace(count) + "ps[" + i + "].Value = model." + column.ColumnName + ";");
                    i++;
                }
                sb.AppendLine(SetSpace(count) + "return SQLHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sb.ToString(), ps) > 0;");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }

            if(context.Delete)
            {
                sb.AppendLine(SetSpace(count) + "public override bool Delete(int id)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "StringBuilder sb = new StringBuilder();");
                sb.AppendLine(SetSpace(count) + "sb.Append(\"DELETE FROM \"+ TableName +\" WHERE " + pkColumn.ColumnName + "=@" + pkColumn.ColumnName + "\");");
                sb.AppendLine(SetSpace(count) + "SqlParameter[] ps = new SqlParameter[]{");
                count++;
                sb.AppendLine(SetSpace(count) + "new SqlParameter(\"" + pkColumn.ColumnName + "\", SqlDbType.Int)");
                count--;
                sb.AppendLine(SetSpace(count) + "};");
                sb.AppendLine(SetSpace(count) + "ps[0].Value = id;");
                sb.AppendLine(SetSpace(count) + "return SQLHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sb.ToString(), ps) > 0;");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }

            if (context.Exists)
            {
                sb.AppendLine(SetSpace(count) + "public override bool Exist(string strKey, int id)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "StringBuilder sb = new StringBuilder();");
                sb.AppendLine(SetSpace(count) + "sb.Append(\"SELECT COUNT(1) FROM \"+ TableName +\" WHERE 1=1 \");");
                sb.AppendLine(SetSpace(count) + "if(!string.IsNullOrEmpty(strKey))");
                sb.AppendLine(SetSpace(count) + "{");
                sb.AppendLine(SetSpace(count) + "    //input your judgment statement");
                sb.AppendLine(SetSpace(count) + "}");
                sb.AppendLine(SetSpace(count) + "if(id > 0)");
                sb.AppendLine(SetSpace(count) + "{");
                sb.AppendLine(SetSpace(count) + "    sb.Append(\"AND " + pkColumn.ColumnName + " = @" + pkColumn.ColumnName + "\");");
                sb.AppendLine(SetSpace(count) + "}");
                sb.AppendLine(SetSpace(count) + "SqlParameter[] ps = new SqlParameter[]{");
                sb.AppendLine(SetSpace(count) + "    new SqlParameter(\"Key\", SqlDbType.NVarChar),");
                sb.AppendLine(SetSpace(count) + "    new SqlParameter(\"" + pkColumn.ColumnName + "\", SqlDbType.Int)");
                sb.AppendLine(SetSpace(count) + "};");
                sb.AppendLine(SetSpace(count) + "ps[0].Value = strKey;");
                sb.AppendLine(SetSpace(count) + "ps[1].Value = id;");
                sb.AppendLine(SetSpace(count) + "return int.Parse(SQLHelper.ExecuteScalar(ConnectionString, CommandType.Text, sb.ToString(), ps).ToString()) > 0;");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }

            if(context.Get)
            {
                sb.AppendLine(SetSpace(count) + "public override " + context.Keyword + " Get(int id)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "StringBuilder sb = new StringBuilder();");
                sb.AppendLine(SetSpace(count) + "sb.Append(\"SELECT * FROM \"+ TableName +\" WHERE " + pkColumn.ColumnName + "=@" + pkColumn.ColumnName + "\");");
                sb.AppendLine(SetSpace(count) + "SqlParameter[] ps = new SqlParameter[]{");
                count++;
                sb.AppendLine(SetSpace(count) + "new SqlParameter(\"" + pkColumn.ColumnName + "\", SqlDbType.Int)");
                count--;
                sb.AppendLine(SetSpace(count) + "};");
                sb.AppendLine(SetSpace(count) + "ps[0].Value = id;");
                sb.AppendLine(SetSpace(count) + "" + context.Keyword + " model = null;");
                sb.AppendLine(SetSpace(count) + "using (SqlDataReader reader = SQLHelper.ExecuteReader(ConnectionString, CommandType.Text, sb.ToString(), ps))");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "while (reader.Read())");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "model = new " + context.Keyword + "();");
                sb.AppendLine(SetSpace(count) + "Fill(model, reader);");
                count--;
                sb.AppendLine(SetSpace(count) + "}");
                count--;
                sb.AppendLine(SetSpace(count) + "}");
                sb.AppendLine(SetSpace(count) + "return model;");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }

            if (context.GetChild)
            {
                sb.AppendLine(SetSpace(count) + "public override List<" + context.Keyword + "> GetChild(int iParentId)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "StringBuilder sb = new StringBuilder();");
                sb.AppendLine(SetSpace(count) + "sb.Append(\"SELECT * FROM \"+ TableName +\" WHERE ParentId=@ParentId\");");
                sb.AppendLine(SetSpace(count) + "SqlParameter[] ps = new SqlParameter[]{");
                count++;
                sb.AppendLine(SetSpace(count) + "new SqlParameter(\"ParentId\", SqlDbType.Int)");
                count--;
                sb.AppendLine(SetSpace(count) + "};");
                sb.AppendLine(SetSpace(count) + "ps[0].Value = iParentId;");

                sb.AppendLine(SetSpace(count) + "List<" + context.Keyword + "> listModel = new List<" + context.Keyword + ">();");
                sb.AppendLine(SetSpace(count) + "" + context.Keyword + " model = new " + context.Keyword + "();");
                sb.AppendLine(SetSpace(count) + "using (SqlDataReader reader = SQLHelper.ExecuteReader(ConnectionString, CommandType.Text, sb.ToString(), null))");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "while (reader.Read())");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "model = new " + context.Keyword + "();");
                sb.AppendLine(SetSpace(count) + "Fill(model, reader);");
                sb.AppendLine(SetSpace(count) + "listModel.Add(model);");
                count--;
                sb.AppendLine(SetSpace(count) + "}");
                count--;
                sb.AppendLine(SetSpace(count) + "}");
                sb.AppendLine(SetSpace(count) + "return listModel;");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }

            count--;
            sb.AppendLine(SetSpace(count) + "}");
            if (!string.IsNullOrEmpty(context.NameSpace))
            {
                sb.AppendLine("}");
            }
            txtCode.Text = sb.ToString();
            SetKeyColor(txtCode);
            SetColor(txtCode);
        }


        public static void BuildBusinessCode(SQLDBInfo db, GenterateContext context, System.Windows.Forms.RichTextBox txtCode)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            List<ColumnInfo> lstColumn = db.GetTableColumns(context.DatabaseName, context.TableName);
            if (lstColumn.Count == 0)
            {
                return;
            }

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Dmq;");
            if (!string.IsNullOrEmpty(context.NameSpace))
            {
                sb.AppendLine("using " + context.NameSpace + ".Entity;");
                sb.AppendLine("using " + context.NameSpace + ".Provider;");
                sb.AppendLine("namespace " + context.NameSpace + ".Business");
                sb.AppendLine("{");
                count++;
                
            }
            sb.AppendLine(SetSpace(count) + "public class " + context.Keyword + "Business");
            sb.AppendLine(SetSpace(count) + "{");
            count++;
            sb.AppendLine("");
            sb.AppendLine(SetSpace(count) + "private " + context.Keyword + "Provider _provider = ProviderManager.Instance.CreateProviderInstance<" + context.Keyword + "Provider>(\"" + context.Keyword + "Provider\");");
            sb.AppendLine("");
            if (context.LoadAll)
            {
                sb.AppendLine(SetSpace(count) + "public List<" + context.Keyword + "> LoadAll()");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "return _provider.LoadAll();");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }
        
            if (context.Count)
            {
                sb.AppendLine(SetSpace(count) + "public int Count(string strKey)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "return _provider.Count(strKey);");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }
  
            if (context.List)
            {
                sb.AppendLine(SetSpace(count) + "public List<" + context.Keyword + "> List(string strKey, int iPageIndex, int iPageSize)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "return _provider.List(strKey,iPageIndex,iPageSize);");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }
            if (context.Create || context.Update)
            {
                sb.AppendLine(SetSpace(count) + "public bool Save(" + context.Keyword + " model, out string msg)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "msg = \"数据保存失败！\";");
                sb.AppendLine(SetSpace(count) + "bool bSuccess = false;");
                sb.AppendLine(SetSpace(count) + "if (_provider.Exist(model.Key, model.Id))");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "msg = \"当前数据库应经包含了当前数据！\";");
                sb.AppendLine(SetSpace(count) + "return false;");
                count--;
                sb.AppendLine(SetSpace(count) + "}");

                sb.AppendLine(SetSpace(count) + "if (model.Id == 0)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "bSuccess = _provider.Create(model);");
                count--;
                sb.AppendLine(SetSpace(count) + "}");
                sb.AppendLine(SetSpace(count) + "else");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "bSuccess = _provider.Update(model);");
                count--;
                sb.AppendLine(SetSpace(count) + "}");

                sb.AppendLine(SetSpace(count) + "if (bSuccess)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "msg = \"保存成功！\";");
                count--;
                sb.AppendLine(SetSpace(count) + "}");

                sb.AppendLine(SetSpace(count) + "return bSuccess;");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }
            
            if (context.Delete)
            {
                sb.AppendLine(SetSpace(count) + "public bool Delete(int id, out string strMsg)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "strMsg = \"数据删除失败！\";");
                sb.AppendLine(SetSpace(count) + "" + context.Keyword + " model = _provider.Get(id);");
                sb.AppendLine(SetSpace(count) + "if (model == null)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "strMsg = \"当前数据库不存在当前数据！\";");
                sb.AppendLine(SetSpace(count) + "return false;");
                count--;
                sb.AppendLine(SetSpace(count) + "}");
                sb.AppendLine(SetSpace(count) + "bool bSuccess = _provider.Delete(id);");
                sb.AppendLine(SetSpace(count) + "if (bSuccess)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "strMsg = \"删除成功！\";");
                count--;
                sb.AppendLine(SetSpace(count) + "}");

                sb.AppendLine(SetSpace(count) + "return bSuccess;");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }
                           
            if (context.Get)
            {
                sb.AppendLine(SetSpace(count) + "public " + context.Keyword + " Get(int id)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "return _provider.Get(id);");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }

            if (context.GetChild)
            {
                sb.AppendLine(SetSpace(count) + "public List<" + context.Keyword + "> GetChild(int iParentId)");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "return _provider.GetChild(iParentId);");
                count--;
                sb.AppendLine(SetSpace(count) + "}"); sb.AppendLine("");
            }                                          
            count--;
            sb.AppendLine(SetSpace(count) + "}");
            if (!string.IsNullOrEmpty(context.NameSpace))
            {
                sb.AppendLine("}");
            }
            txtCode.Text = sb.ToString();
            SetKeyColor(txtCode);
            SetColor(txtCode);
        }

        public static void BuildHandlerCode(SQLDBInfo db, GenterateContext context, System.Windows.Forms.RichTextBox txtCode)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            List<ColumnInfo> lstColumn = db.GetTableColumns(context.DatabaseName, context.TableName);
            if (lstColumn.Count == 0)
            {
                return;
            }
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Dmq;");
            sb.AppendLine("using System.Dmq.Web;");
            if (!string.IsNullOrEmpty(context.NameSpace))
            {
                sb.AppendLine("using " + context.NameSpace + ".Entity;");
                sb.AppendLine("using " + context.NameSpace + ".Business;");
                sb.AppendLine("namespace " + context.NameSpace + ".Handler");
                sb.AppendLine("{");
                count++;

            }
            sb.AppendLine(SetSpace(count) + "public class " + context.Keyword + "Handler : PassportHandler");           
            sb.AppendLine(SetSpace(count) + "{");
            count++;
            sb.AppendLine("");
            sb.AppendLine(SetSpace(count) + "public override string OperationAction(System.Web.HttpContext context)");
            sb.AppendLine(SetSpace(count) + "{");
            count++;
            sb.AppendLine(SetSpace(count) + "" + context.Keyword + "Business _business = new " + context.Keyword + "Business();");
            sb.AppendLine(SetSpace(count) + "IList<Object> jsonResult = new List<object>();");
            sb.AppendLine(SetSpace(count) + "IList<Object> jsonItem = new List<object>();");

            if (context.List)
            {
                sb.AppendLine(SetSpace(count) + "AppendAction(\"List\", new ActionEvent(delegate");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "string strKey = WebTool.GetFormValue(\"key\");");
                sb.AppendLine(SetSpace(count) + "int iCount = _business.Count(strKey);");
                sb.AppendLine(SetSpace(count) + "return EasyJson.GetEasyGridJson(_business.List(strKey, CurrentPage, CurrentRows), iCount);");
                count--;
                sb.AppendLine(SetSpace(count) + "}));"); sb.AppendLine("");
            }

            if (context.Create || context.Update)
            {
                sb.AppendLine(SetSpace(count) + "AppendAction(\"Save\", new ActionEvent(delegate");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "" + context.Keyword + " model = new " + context.Keyword + "();");
                foreach (ColumnInfo column in lstColumn)
                {
                    if (column.ColumnName.ToLower() != "datastate")
                    {
                        if (column.ColumnName.ToLower() == "createuser" || column.ColumnName.ToLower() == "lastchangeuser")
                        {
                            sb.AppendLine(SetSpace(count) + "model." + column.ColumnName + " = CurrentUser.UserId;");
                        }
                        else if (column.ColumnType.ToLower().IndexOf("int") > 0 || column.ColumnType.ToLower() == "money" || column.ColumnType.ToLower() == "smallmoney")
                        {
                            sb.AppendLine(SetSpace(count) + "model." + column.ColumnName + " = WebTool.GetFormValue(\"" + column.ColumnName + "\").Convert<int>(0);");
                        }
                        else
                        {
                            sb.AppendLine(SetSpace(count) + "model." + column.ColumnName + " = WebTool.GetFormValue(\"" + column.ColumnName + "\");");
                        }
                    }
                }
                sb.AppendLine(SetSpace(count) + "string strMsg = string.Empty;");
                sb.AppendLine(SetSpace(count) + "return JsonConverter.GetJson(_business.Save(model, out strMsg), strMsg);");
                count--;
                sb.AppendLine(SetSpace(count) + "},ActionEnum.Add, ActionEnum.Edit));"); sb.AppendLine("");
            }

            if (context.Delete)
            {
                sb.AppendLine(SetSpace(count) + "AppendAction(\"Delete\", new ActionEvent(delegate");
                sb.AppendLine(SetSpace(count) + "{");
                count++;               
                sb.AppendLine(SetSpace(count) + "string strMsg = string.Empty;");
                sb.AppendLine(SetSpace(count) + "return JsonConverter.GetJson(_business.Delete(int.Parse(WebTool.GetFormValue(\"id\").Default(\"0\")), out strMsg), strMsg);");
                count--;
                sb.AppendLine(SetSpace(count) + "},ActionEnum.Delete));"); sb.AppendLine("");
            }

            if (context.Get)
            {
                sb.AppendLine(SetSpace(count) + "AppendAction(\"Get\", new ActionEvent(delegate");
                sb.AppendLine(SetSpace(count) + "{");
                count++;
                sb.AppendLine(SetSpace(count) + "return JsonConverter.Parse(_business.Get(int.Parse(WebTool.GetQueryString(\"id\").Default(\"0\"))));");
                count--;
                sb.AppendLine(SetSpace(count) + "}));"); sb.AppendLine("");
            }
            sb.AppendLine(SetSpace(count) + "return base.OperationAction(context);");            
            count--;
            sb.AppendLine(SetSpace(count) + "}");            
            count--;
            sb.AppendLine(SetSpace(count) + "}");
            if (!string.IsNullOrEmpty(context.NameSpace))
            {
                sb.AppendLine("}");
            }
            txtCode.Text = sb.ToString();
            SetKeyColor(txtCode);
            SetColor(txtCode);
        }




        #region generate identation spaces

        private static string SetSpace(int count)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < count; i++)
                str.Append("    ");
            return str.ToString();
        }

        #endregion

        #region change the color for keyword

        private static void SetKeyColor(System.Windows.Forms.RichTextBox txtCode)
        {
            int start = 0;
            int end = 0;
            string text = txtCode.Text;
            List<char> temp = new List<char>();
            bool isMark = false;
            foreach (char x in text.ToCharArray())
            {
                foreach (char mark in marks)
                {
                    if (x == mark)
                    {
                        isMark = true;
                        break;
                    }
                }
                if (isMark)
                {
                    StringBuilder word = new StringBuilder();
                    foreach (char y in temp)
                        word.Append(y.ToString());
                    foreach (string z in keys)
                    {
                        if (word.ToString() == z)
                        {
                            txtCode.Select(start, word.Length);
                            txtCode.SelectionColor = Color.Blue;
                            break;
                        }
                    }
                    foreach (string z in classes)
                    {
                        if (word.ToString() == z)
                        {
                            txtCode.Select(start, word.Length);
                            txtCode.SelectionColor = Color.CadetBlue;
                            break;
                        }
                    }
                    start = ++end;
                    temp.Clear();
                    isMark = false;
                }
                else
                {
                    temp.Add(x);
                    end++;
                }
            }
        }

        /// <summary>
        /// change the color for remark
        /// </summary>
        private static void SetColor(System.Windows.Forms.RichTextBox txtCode)
        {
            string text = txtCode.Text;
            int count = 0;
            while (true)
            {
                int _start = text.IndexOf("///", count) + 3;
                if (_start == 2)
                    break;
                int _end = text.IndexOf('\n', _start);
                count = _end;
                string str = text.Substring(_start, _end - _start);
                str = str.Trim();
                if (str[0] == '<' && str[str.Length - 1] == '>')
                {
                    txtCode.Select(_start - 3, (_end - _start) + 3);
                    txtCode.SelectionColor = Color.Gray;
                }
                else
                {
                    txtCode.Select(_start - 3, 3);
                    txtCode.SelectionColor = Color.Gray;
                    txtCode.Select(_start, (_end - _start) + 3);
                    txtCode.SelectionColor = Color.Green;
                }
            }
        }
        #endregion

        #region according to the data type convert to c# type

        private static string GetType(string typeName)
        {
            switch (typeName.ToLower())
            {
                case "bigint":
                    return "int";
                case "binary":
                    return "byte[]";
                case "bit":
                    return "bool";
                case "char":
                    return "string";
                case "datetime":
                    return "string";
                case "decimal":
                    return "double";
                case "image":
                    return "byte[]";
                case "money":
                    return "float";
                case "nchar":
                    return "string";
                case "ntext":
                    return "string";
                case "numeric":
                    return "double";
                case "nvarchar":
                    return "string";
                case "real":
                    return "double";
                case "smalldatetime":
                    return "string";
                case "smallint":
                    return "int";
                case "smallmoney":
                    return "float";
                case "text":
                    return "string";
                case "tinyint":
                    return "int";
                case "varbinary":
                    return "byte[]";
                case "varchar":
                    return "string";
                case "int identity":
                    return "int";
                default:
                    return typeName.ToLower();
            }
        }
        #endregion

        #region will be first char convert to captital

        private static string UpperLetter(string str)
        {
            if (str.Length > 1)
            {
                string str1 = str.ToUpper();
                return str1[0].ToString() + str.Substring(1, str.Length - 1);
            }
            else
                return str.ToUpper();
        }

        #endregion

    }

}
