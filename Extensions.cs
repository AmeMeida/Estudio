using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Estudio
{
    public static class FormExtensions
    {
        public static T GetChild<T>(this Form form, bool show = true) where T : Form
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
            {
                child.Show();
                child.Focus();
            }
            return child;
        }

        public static T GetChild<T, I>(this Form form, FormModes mode, I value)
            where T : Form, IModalForm<I>
        {
            var child = GetChild<T, I>(form, mode);
            child.Value = value;
            return child;
        }

        public static T GetChild<T, I>(this Form form, FormModes mode) where T : Form, IModalForm<I>
        {
            var forms = form.MdiChildren.OfType<T>().Where(x => x.Mode == mode || (x.Mode == FormModes.Visualizacao && mode == FormModes.Edicao));
            T childForm;

            if (forms.Count() < 1)
            {
                childForm = typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null) as T;
                childForm.Mode = mode;
            }
            else
                childForm = forms.First();

            childForm.MdiParent = form;
            childForm.Show();
            childForm.Focus();

            return childForm;
        }

        public static void ImplementNext(this Form form)
        {
            foreach (var txt in form.GetNestedControls<TextBoxBase>().OrderBy(x => x.TabIndex))
                txt.KeyPress += ControlExtensions.NextControl;
        }
    }

    public static class ControlExtensions
    {
        public static bool VerifyTextBox(this Control control)
        {
            foreach (var txt in control.GetNestedControls<TextBoxBase>().OrderBy(x => x.TabIndex))
                if (txt.EmptyFieldWarn())
                    return true;

            return false;
        }

        public static bool EmptyFieldWarn(this TextBoxBase txt)
        {
            bool isEmpty = txt.IsEmpty();

            if (isEmpty)
            {
                txt.Focus();
                MessageBox.Show("Este campo não pode estar vazio!", "Campo obrigatório.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isEmpty;
        }

        public static void ClearAllText(this Control control)
        {
            foreach (var txt in control.GetNestedControls<TextBoxBase>())
                txt.ResetText();
        }

        public static void SetEnabledAll(this Control control, bool state)
        {
            foreach (var ctrl in control.GetNestedControls())
                ctrl.Enabled = state;

        }

        public static void DisableAll(this Control control) => control.SetEnabledAll(false);

        public static void EnableAll(this Control control) => control.SetEnabledAll(true);

        public static bool IsEmpty(this TextBoxBase txt) 
            => string.IsNullOrWhiteSpace(txt.Text) || (txt is MaskedTextBox mtx && !mtx.MaskCompleted);

        public static void NextControl(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ((char)Keys.Enter))
                return;

            if (sender is TextBoxBase txt && txt.EmptyFieldWarn())
                return;

            ((Control)sender).FindForm().SelectNextControl((Control)sender, true, true, true, true);
        }

        public static IEnumerable<T> GetNestedControls<T>(this Control control) where T : Control
        {
            var controls = control.Controls.Cast<Control>();
            return controls.OfType<T>().Concat(controls.SelectMany(ctrl => GetNestedControls<T>(ctrl)));
        }
        public static IEnumerable<Control> GetNestedControls(this Control control) => control.GetNestedControls<Control>();
    }

    public static class ComboBoxExtensions
    {
        public static bool HasSelectedWarn(this ComboBox cbo)
        {
            bool hasSelected = cbo.SelectedIndex > -1;

            if (!hasSelected)
            {
                MessageBox.Show("Por favor, selecione um item!", "Impossível operar: campo não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo.Focus();
            }
            
            return hasSelected;
        }
    }

    public static class NumericUpDownExtensions
    {
        public static float FloatValue(this NumericUpDown num)
            => float.Parse(num.Value.ToString().Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture);
    }

    public static class UpdatePairExtensions
    {
        public static string ToClause(this (string column, object value) pair) => pair.ToCondition().ToClause();
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

    public static class QueryBuilderExtensions
    {
        public static MySqlCommand ToCommand(this QueryBuilder builder) => builder.ToCommand(DAO_Connection.Connection);
    }

    public static class AccountTypeExtensions
    {
        public static string ToString(this UserType uType) => ((int)uType).ToString();
    }
}
