using System;
using System.Collections.Generic;
using System.Text;

namespace ProcSubstanceEditor
{
    public class MetaFileUpgraded
    {
        public string guid { get; set; }
        public int fileFormatVersion { get; set; } = 2;
        public ProceduralMaterialUpgradedMetaFormat ScriptedImporter { get; set; }

        public MetaFileUpgraded(MetaFileOriginal original)
        {
            guid = original.guid;
            ScriptedImporter = new ProceduralMaterialUpgradedMetaFormat(original.SubstanceImporter);
        }
    }
}
