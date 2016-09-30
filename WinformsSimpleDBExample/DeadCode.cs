using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsSimpleDBExample
{
    class DeadCode
    {
    }
}

//protected void LoadDictionaryFromObject()
//{
//    if (this.Tag == null)
//        return;

//    //iterate object properties
//    foreach (PropertyInfo pi in this.Tag.GetType().GetProperties())
//    {
//        DictObjectValues.Add(pi.Name.ToLower(), pi.GetValue(this.Tag));
//    }
//}

//protected void UpdateObjectFromDictionary()
//{
//    if (this.Tag == null)
//        return;

//    //iterate object properties
//    foreach (PropertyInfo pi in this.Tag.GetType().GetProperties())
//        if (DictObjectValues.ContainsKey(pi.Name.ToLower()))
//        {
//            pi.SetValue(this.Tag, DictObjectValues[pi.Name.ToLower()]);
//            DictPropertyTypes.Add(pi.Name.ToLower(), pi.PropertyType);
//        }
//}

//protected void LoadDictionaryFromControls()
//{
//    if (DictObjectValues.Count == 0)
//        return;

//    foreach (Control ctl in this.Controls)
//    {
//        string controlName = ctl.Name.Substring(3).ToLower();

//        if (DictObjectValues.ContainsKey(controlName))
//        {
//            switch (ctl.GetType().Name)
//            {
//                case "TextBox":
//                    DictObjectValues[controlName] = (ctl as TextBox).Text;
//                    break;

//                case "CheckBox":
//                    DictObjectValues[controlName] = (ctl as CheckBox).Checked;
//                    break;

//                case "ComboBox":
//                    //int id;

//                    //if (DictObjectValues[controlName] != null)
//                    //    if (Int32.TryParse(DictObjectValues[controlName].ToString(), out id))
//                    //        Util.SetComboBoxValue(cbo, id);
//                    //    else
//                    //        cbo.Text = value.ToString();
//                    break;

//                default:
//                    break;
//            }
//        }
//    }
//}

//protected void LoadControlsFromDictionary()
//{
//    if (DictObjectValues.Count == 0)
//        return;

//    foreach (Control ctl in this.Controls)
//    {
//        string controlName = ctl.Name.Substring(3).ToLower();

//        if (DictObjectValues.ContainsKey(controlName))
//        {
//            switch (ctl.GetType().Name)
//            {
//                case "TextBox":
//                    (ctl as TextBox).Text = DictObjectValues[controlName].ToString();
//                    break;

//                case "CheckBox":
//                    (ctl as CheckBox).Checked = (bool)DictObjectValues[controlName];
//                    break;

//                case "ComboBox":
//                    //int id;

//                    //if (DictObjectValues[controlName] != null)
//                    //    if (Int32.TryParse(DictObjectValues[controlName].ToString(), out id))
//                    //        Util.SetComboBoxValue(cbo, id);
//                    //    else
//                    //        cbo.Text = value.ToString();
//                    break;

//                default:
//                    break;
//            }
//        }
//    }
//}

/////////////////more////////////////////

//private void SetComboBoxValue(ComboBox cbo, Int32 id)
//{
//    foreach (ListItem li in cbo.Items)
//    {
//        if (li.ID == id)
//        {
//            cbo.SelectedIndex = cbo.FindStringExact(li.Text);
//            break;
//        }
//    }
//}



