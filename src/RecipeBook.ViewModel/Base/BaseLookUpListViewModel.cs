﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public abstract class BaseLookUpListViewModel<T> : BaseEditableListViewModel<T>
    where T : BaseIDViewModel
  {
    private readonly Dictionary<string, T> mLookUp = new Dictionary<string, T>();

    internal T this[string id]
    {
      get
      {
        T viewModel;
        if (!mLookUp.TryGetValue(id, out viewModel))
        {
          viewModel = default(T);
        }
        return viewModel;
      }
    }

    protected override void OnListCleared()
    {
      base.OnListCleared();
      mLookUp.Clear();
    }

    protected override void OnViewModelAdded(T viewModel)
    {
      base.OnViewModelAdded(viewModel);
      mLookUp[viewModel.ID] = viewModel;
    }

    protected override void OnViewModelRemoved(T viewModel)
    {
      base.OnViewModelRemoved(viewModel);
      mLookUp.Remove(viewModel.ID);
    }
  }
}
