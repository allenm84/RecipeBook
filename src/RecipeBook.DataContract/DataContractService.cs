using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class DataContractService : ISaveFileService
  {
    private readonly DataContractFile<SaveFile> dcf;

    public DataContractService(string filepath)
    {
      dcf = new DataContractFile<SaveFile>(filepath);
    }

    SaveFile ISaveFileService.ReadSaveFile()
    {
      SaveFile file;
      dcf.TryRead(out file);
      return file ?? DefaultSaveFile.GetDefault();
    }

    void ISaveFileService.WriteSaveFile(SaveFile saveFile)
    {
      dcf.TryWrite(saveFile);
    }
  }
}
