using System.Collections.Generic;
using System.Threading.Tasks;
using Objects.BuiltElements.Archicad;
using Speckle.Core.Models;
using Speckle.Newtonsoft.Json;

namespace Archicad.Communication.Commands;

internal sealed class CreateDoor : ICommand<IEnumerable<ApplicationObject>>
{
  [JsonObject(MemberSerialization.OptIn)]
  public sealed class Parameters
  {
    [JsonProperty("subElements")]
    private IEnumerable<ArchicadDoor> Datas { get; }

    public Parameters(IEnumerable<ArchicadDoor> datas)
    {
      Datas = datas;
    }
  }

  [JsonObject(MemberSerialization.OptIn)]
  private sealed class Result
  {
    [JsonProperty("applicationObjects")]
    public IEnumerable<ApplicationObject> ApplicationObjects { get; private set; }
  }

  private IEnumerable<ArchicadDoor> Datas { get; }

  public CreateDoor(IEnumerable<ArchicadDoor> datas)
  {
    Datas = datas;
  }

  public async Task<IEnumerable<ApplicationObject>> Execute()
  {
    var result = await HttpCommandExecutor.Execute<Parameters, Result>("CreateDoor", new Parameters(Datas));
    return result == null ? null : result.ApplicationObjects;
  }
}
