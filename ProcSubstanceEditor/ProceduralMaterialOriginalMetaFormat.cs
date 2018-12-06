using System;
using System.Collections.Generic;
using System.Text;
// ReSharper disable InconsistentNaming

namespace ProcSubstanceEditor
{
    // Aka "SubstanceImporter"
    public class ProceduralMaterialOriginalMetaFormat
    {
        public int serializedVersion { get; set; }
        public List<SubstanceImporterData> materialInstances { get; set; }
    }
}
