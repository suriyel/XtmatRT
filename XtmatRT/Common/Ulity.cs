using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using TestStack.White.Mappings;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;

namespace XtmatRT
{
    public static class Ulity
    {
        public static Dictionary<int, Type> AvailableControlType = new Dictionary<int, Type>
            {
              {ControlType.Window.Id,typeof(Window)},
              {ControlType.Button.Id,typeof(Button)},
              {ControlType.Tree.Id,typeof(Tree)},
              {ControlType.CheckBox.Id,typeof(CheckBox)},
              {ControlType.List.Id,typeof(ListBox)},
              {ControlType.RadioButton.Id,typeof(RadioButton)},
              {ControlType.Tab.Id,typeof(Tab)},
              {ControlType.Table.Id,typeof(Table)},
              {ControlType.DataGrid.Id,typeof(ListView)},
              {ControlType.ToolBar.Id,typeof(ToolStrip)},
              {ControlType.MenuBar.Id,typeof(MenuBar)},
              {ControlType.Menu.Id,typeof(MenuBar)},
              {ControlType.Spinner.Id,typeof(Spinner)},
              {ControlType.Pane.Id,typeof(Panel)},
              {ControlType.Text.Id,typeof(Label)},
              {ControlType.ComboBox.Id,typeof(ComboBox)},
              {ControlType.StatusBar.Id,typeof(StatusStrip)},
              {ControlType.Document.Id,typeof(TextBox)}
            };
        public static Dictionary<int,Type> AvailableCustomType=new Dictionary<int, Type>()
            {
              {ControlType.Button.Id,typeof(Button)},
              {ControlType.Tree.Id,typeof(Tree)},
              {ControlType.CheckBox.Id,typeof(CheckBox)},
              {ControlType.List.Id,typeof(ListBox)},
              {ControlType.RadioButton.Id,typeof(RadioButton)},
              {ControlType.Tab.Id,typeof(Tab)},
              {ControlType.Table.Id,typeof(Table)},
              {ControlType.DataGrid.Id,typeof(ListView)},
              {ControlType.ToolBar.Id,typeof(ToolStrip)},
              {ControlType.MenuBar.Id,typeof(MenuBar)},
              {ControlType.Menu.Id,typeof(MenuBar)},
              {ControlType.Spinner.Id,typeof(Spinner)},
              {ControlType.Text.Id,typeof(Label)},
              {ControlType.ComboBox.Id,typeof(ComboBox)},
              {ControlType.StatusBar.Id,typeof(StatusStrip)},
              {ControlType.Document.Id,typeof(TextBox)}
            };
    }
    
}
