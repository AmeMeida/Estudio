﻿using System.Text;

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

        public static string Concat(params string[] values)
        {
            var text = new StringBuilder(values[0].Check());

            for (int i = 1; i < values.Length; i++)
                text.Append(", " + values[i].Check());

            return text.ToString();
        }

        public static string ConcatWithCommas(string[] values)
        {
            var text = new StringBuilder(values[0].Quote());

            for (int i = 1; i < values.Length; i++)
                text.Append(", " + values[i].Quote());

            return text.ToString();
        }

        public static string ConcatWithPar(string[] values) => "(" + Concat(values) + ")";
        public static string ConcatWithCommaPar(string[] values) => "(" + ConcatWithCommas(values) + ")";

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

        public QueryBuilder VALUES(params string[] values)
        {
            query.Append("VALUES" + ConcatWithCommaPar(values) + " ");
            return this;
        }

        public QueryBuilder FROM(string table)
        {
            query.Append("FROM " + table.Check() + " ");
            return this;
        }

        public QueryBuilder WHERE(string condition)
        {
            WHERE();
            query.Append(condition.Check() + " ");
            return this;
        }

        public QueryBuilder WHERE()
        {
            query.Append("WHERE ");
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

        public override string ToString()
        {
            return query.ToString().Trim() + ";";
        }
    }
}
