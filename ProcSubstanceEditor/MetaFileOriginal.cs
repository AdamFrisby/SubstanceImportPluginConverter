using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace ProcSubstanceEditor
{
    public class MetaFileOriginal
    {
        public int fileFormatVersion { get; set; } = 2;
        public long timeCreated { get; set; }
        public string guid { get; set; }
        public string licenseType { get; set; }
        public ProceduralMaterialOriginalMetaFormat SubstanceImporter { get; set; }
    }
}
