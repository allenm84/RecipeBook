using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public static class ViewModelStack
  {
    static Stack<BaseAcceptableViewModel> sViewModels = new Stack<BaseAcceptableViewModel>();
    static SaveFileViewModel sSaveFile;

    public static event EventHandler StackChanged;

    public static BaseAcceptableViewModel Current
    {
      get { return sViewModels.Peek(); }
    }

    internal static SaveFileViewModel SaveFile
    {
      get { return sSaveFile; }
    }

    internal static void Initialize(SaveFileViewModel saveFile)
    {
      sViewModels.Clear();
      sSaveFile = saveFile;
      sViewModels.Push(sSaveFile);
      FireStackChanged();
    }

    internal static void Push(BaseAcceptableViewModel viewModel)
    {
      sViewModels.Push(viewModel);
      FireStackChanged();
      PopWhenCompleted(viewModel);
    }

    private static async void PopWhenCompleted(BaseAcceptableViewModel viewModel)
    {
      await viewModel.Completed;
      Debug.Assert(sViewModels.Pop() == viewModel);
    }

    private static void FireStackChanged()
    {
      var changed = StackChanged;
      if (changed != null)
      {
        changed(null, EventArgs.Empty);
      }
    }
  }
}

public static class ViewModelStack
{
  static Stack<BaseAcceptableViewModel> sViewModels = new Stack<BaseAcceptableViewModel>();
  static BaseTopLevelViewModel sTopLevel;

  public static event EventHandler StackChanged;

  public static BaseAcceptableViewModel Current
  {
    get { return sViewModels.Peek(); }
  }

  internal static BaseTopLevelViewModel SaveFile
  {
    get { return sTopLevel; }
  }

  internal static void Initialize(BaseTopLevelViewModel topLevel)
  {
    // unit tests will re-use the Initialize method! So allow it to be cleared.
    sViewModels.Clear();
    sTopLevel = topLevel;
    sViewModels.Push(sTopLevel);
    FireStackChanged();
  }

  internal static void Push(BaseAcceptableViewModel viewModel)
  {
    sViewModels.Push(viewModel);
    FireStackChanged();
    PopWhenCompleted(viewModel);
  }

  private static async void PopWhenCompleted(BaseAcceptableViewModel viewModel)
  {
    await viewModel.Completed;
    Debug.Assert(sViewModels.Pop() == viewModel);
  }

  private static void FireStackChanged()
  {
    var changed = StackChanged;
    if (changed != null)
    {
      changed(null, EventArgs.Empty);
    }
  }
}
