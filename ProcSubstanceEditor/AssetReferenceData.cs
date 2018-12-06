// ReSharper disable InconsistentNaming

namespace ProcSubstanceEditor
{
    public class AssetReferenceData
    {
        // Should contain either this (typically zero)
        public int instanceID { get; set; }

        // or this ...
        public int fileID { get; set; } // 46
        public string guid { get; set; } // e.g. a GUID
        public int type { get; set; } // 0
    }
}
