using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Estudio
{
    public class QueryBuilder
    {
        private StringBuilder query;
        public StringBuilder Query
        {
            get
            {
                if (query == null)
                    query = new StringBuilder();
                return query;
            }
        }

        public static string FormatValue(object value, bool addQuotes = false, SQLOp op = SQLOp.EQ)
        {
            string valString;

            if (value == null)
                return "NULL";
            else if (value is string @string)
                valString = @string.Replace("'", "''");
            else if (value is float || value is double || value is decimal)
                valString = value.ToString().Replace(",", ".");
            else
                valString = value.ToString();

            valString = op.Format(valString);
            return addQuotes ? valString.Quote() : valString.Check();
        }

        public static string Concat(params object[] values)
        {
            var text = new StringBuilder(FormatValue(values.First()));

            for (int i = 1; i < values.Length; i++)
                text.Append(", " + FormatValue(values[i]));

            return text.ToString();
        }

        public static string ConcatWithCommas(params object[] values)
        {
            var text = new StringBuilder(FormatValue(values.First(), true));

            for (int i = 1; i < values.Length; i++)
                text.Append(", " + FormatValue(values[i], true));

            return text.ToString();
        }

        public static string ConcatWithPar(params object[] values) => "(" + Concat(values) + ")";
        public static string ConcatWithCommaPar(params object[] values) => "(" + ConcatWithCommas(values) + ")";

        public QueryBuilder SELECT(params string[] columns) {
            query = new StringBuilder("SELECT ");

            if (columns.Length == 0)
                query.Append("*");
            else
                query.Append(Concat(columns));

            query.Append(" ");
            return this;
        }

        public QueryBuilder INSERT()
        {
            query = new StringBuilder("INSERT ");
            return this;
        }

        public QueryBuilder DELETE()
        {
            query = new StringBuilder("DELETE ");
            return this;
        }

        public QueryBuilder UPDATE(string table)
        {
            query = new StringBuilder("UPDATE " + table.Check() + " ");
            return this;
        }

        public QueryBuilder SET(params (string column, object value)[] updatePairs)
        {
            query.Append("SET ");

            if (updatePairs.Length >= 1)
            {
                foreach (var pair in updatePairs.Take(updatePairs.Length - 1))
                    query.Append(UpdatePairExtensions.ToClause(pair) + ", ");
                query.Append(UpdatePairExtensions.ToClause(updatePairs.Last()) + " ");
            }

            return this;
        }

        public QueryBuilder INTO(string table)
        {
            query.Append("INTO " + table.Check());
            return this;
        }

        public QueryBuilder COLUMNS(params string[] columns)
        {
            query.Append(ConcatWithPar(columns) + " ");
            return this;
        }

        public QueryBuilder VALUES(params object[] values)
        {
            query.Append("VALUES" + ConcatWithCommaPar(values) + " ");
            return this;
        }

        public QueryBuilder FROM(string table)
        {
            query.Append("FROM " + table.Check() + " ");
            return this;
        }

        public QueryBuilder WHERE(string condition = null)
        {
            query.Append("WHERE ");
            if (condition != null)
                query.Append(condition.Check() + " ");
            return this;
        }

        public QueryBuilder AND(string condition)
        {
            query.Append("AND " + condition.Check() + " ");
            return this;
        }

        public QueryBuilder OR(string condition)
        {
            query.Append("OR " + condition.Check() + " ");
            return this;
        }

        public QueryBuilder LIMIT(uint limit = 1)
        {
            query.Append("LIMIT " + limit + " ");
            return this;
        }

        public override string ToString() => query.ToString().Trim() + ";";
        public MySqlCommand ToCommand(MySqlConnection con) => new MySqlCommand(ToString(), con);
        public QueryBuilder LogQuery()
        {
            if (Params.ShowSQL)
                Console.WriteLine(ToString());
            return this;
        }

        public QueryBuilder DisplayQuery()
        {
            if (Params.DisplaySQL)
            {
                var result = MessageBox.Show(ToString(), "Query SQL:", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                switch (result) 
                {
                    case DialogResult.Yes:
                        Clipboard.SetText(ToString());
                        break;

                    case DialogResult.Cancel:
                        throw new Exception("Encerrar o programa!");
                }
            }

            return this;
        }
    }
}
