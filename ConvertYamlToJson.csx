#r ".\packages\Newtonsoft.Json.10.0.3\lib\net45\Newtonsoft.Json.dll"
#r ".\packages\YamlDotNet.5.2.1\lib\net45\YamlDotNet.dll"
using Newtonsoft.Json;
using System.IO;
using YamlDotNet.Serialization;

static string ConvertYamlToJson(string yaml)
{
  return JsonConvert.SerializeObject(new Deserializer().Deserialize(yaml, typeof(object)), Formatting.Indented);
}

static string ReadTextFile(string fileName)
{
  using (var source = File.OpenRead(fileName))
  using (var reader = new StreamReader(source))
  {
    return reader.ReadToEnd();
  }
}

static void WriteTextFile(string fileName, string content)
{
  using (var destination = File.OpenWrite(fileName))
  using (var writer = new StreamWriter(destination))
  {
    writer.Write(content);
  }
}

public static void ReadAndWriteFiles(string sourceFileName)
{
  WriteTextFile($"{Path.GetFileNameWithoutExtension(sourceFileName)}.json", ConvertYamlToJson(ReadTextFile(sourceFileName)));
}

ReadAndWriteFiles(Environment.GetCommandLineArgs().Last());
