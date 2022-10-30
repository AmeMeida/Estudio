﻿using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Linq;
using System.Net.Http.Headers;
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
                text.Append(", " + (values[i] != "NULL" ? values[i].Quote() : values[i].Check()));

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

        public QueryBuilder UPDATE(string table)
        {
            query = new StringBuilder("UPDATE " + table.Check() + " ");
            return this;
        }

        public QueryBuilder SET(params (string column, string value)[] updatePairs)
        {
            query.Append("SET ");

            if (updatePairs.Length >= 1)
            {
                query.Append(Concat(updatePairs.Select(x => x.ToStatement()).ToArray()));
                query.Append(" ");
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
