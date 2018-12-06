using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ProcSubstanceEditor
{
    public class SubstanceMetaFileConverter
    {
        public static void ConvertFile(string inputFilename, string outputFilename)
        {
            var deserializer =
                new DeserializerBuilder().IgnoreUnmatchedProperties().Build();

            var serializer = new SerializerBuilder().Build();


            var input = File.ReadAllText(inputFilename);

            var original = deserializer.Deserialize<MetaFileOriginal>(input);

            var upgraded = new MetaFileUpgraded(original);

            var output = serializer.Serialize(upgraded);

            File.WriteAllText(outputFilename, output);
        }
    }
}
