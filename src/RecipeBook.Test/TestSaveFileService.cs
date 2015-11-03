using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class TestSaveFileService : ISaveFileService
  {
    private SaveFile model;

    public TestSaveFileService()
    {
      model = DefaultSaveFile.GetDefault();
    }

    SaveFile ISaveFileService.ReadSaveFile()
    {
      return model;
    }

    void ISaveFileService.WriteSaveFile(SaveFile saveFile)
    {
      model = saveFile;
    }
  }
}
