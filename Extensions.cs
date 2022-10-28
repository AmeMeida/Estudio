using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public static class FormExtensions
    {
        public static T GetChild<T>(this Form form, bool show = false) where T : Form
        {
            T child;

            if (form.MdiChildren.OfType<T>().Count() == 0)
            {
                child = typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null) as T;
                child.MdiParent = form;
            } 
            else
            {
                child = form.MdiChildren.OfType<T>().First();
            }

            if (show)
                child.Show();
            return child;
        }

        public static bool VerifyTextBox(this Form form)
        {
            foreach(var txt in form.GetNestedControls().OfType<TextBox>().OrderBy(x => x.TabIndex).ToList())
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Focus();
                    MessageBox.Show("Todos os campos devem ser preenchidos.", "Campo obrigatório.", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }                
            }

            return false;
        }

        public static Control[] GetNestedControls(this Form form)
        {
            var controls = form.Controls.OfType<Control>();

            foreach (var control in controls)
                controls = controls.Union(control.Controls.OfType<Control>());

            return controls.ToArray();
        }
    }

    public static class UpdatePairExtensions
    {
        public static string ToStatement(this (string column, string value) pair) => pair.column.Check() + " = " + pair.value.Quote();
    }

    public static class StringExtensions
    {
        public static string Check(this string str) => !string.IsNullOrEmpty(str) ? str.Trim() : throw new ArgumentNullException(nameof(str) + " não deve estar vazio.");

        public static string Quote(this string str) => "'" + str.Check() + "'";
    }

    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendQuote(this StringBuilder builder, string value) => builder.Append(" '").Append(value).Append("' ");
        public static StringBuilder AppendComma(this StringBuilder builder, string value) => builder.Append(" '").Append(value).Append("', ");
    }

}
