using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace RecipeBook
{
  public class ControlCommandBinder : IDisposable
  {
    private Control control;
    private ICommand command;
    private IConfirmCommand confirmCommand;

    public ControlCommandBinder(Control control, ICommand command, IConfirmCommand confirmCommand)
    {
      this.control = control;
      this.command = command;
      this.confirmCommand = confirmCommand;

      ReadCommandAsync();

      command.CanExecuteChanged += command_CanExecuteChanged;
      control.Click += control_Click;
      control.Disposed += control_Disposed;
    }

    ~ControlCommandBinder()
    {
      Dispose(false);
      Debug.Fail("CommandBinder was not disposed!");
    }

    private void control_Disposed(object sender, EventArgs e)
    {
      Dispose(true);
    }

    private void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (command != null)
        {
          command.CanExecuteChanged -= command_CanExecuteChanged;
          command = null;
        }

        if (control != null)
        {
          control.Click -= control_Click;
          control.Disposed -= control_Disposed;
          control = null;
        }

        GC.SuppressFinalize(this);
      }
    }

    private async void ReadCommandAsync()
    {
      await Task.Yield();
      ReadCommand();
    }

    private void ReadCommand()
    {
      control.Enabled = command.CanExecute(this);
    }

    private void command_CanExecuteChanged(object sender, EventArgs e)
    {
      ReadCommand();
    }

    private void control_Click(object sender, EventArgs e)
    {
      if (confirmCommand != null && !confirmCommand.Confirm())
      {
        // don't execute the command if it isn't confirmed
        return;
      }

      command.Execute(this);
    }

    void IDisposable.Dispose()
    {
      Dispose(true);
    }
  }
}
