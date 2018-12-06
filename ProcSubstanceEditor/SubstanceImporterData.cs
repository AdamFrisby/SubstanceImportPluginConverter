namespace ProcSubstanceEditor
{
    public class SubstanceImporterData
    {
        public string name { get; set; } // bricks_032
        public string prototypeName { get; set; } // bricks_032
        public string shaderName { get; set; } // BLANK
        public AssetReferenceData shader { get; set; }
        public string shaderKeywords { get; set; }
        public int renderQueue { get; set; }
        public int lightmapFlags { get; set; }
        public SubstanceInput[] inputs { get; set; }
        public SubstanceMaterialInformation materialInformation { get; set; }
        public SubstanceMaterialProperties materialProperties { get; set; }
        public SubstanceTextureParameters[] textureParameters { get; set; }
        public SubstanceTextureAssignment[] textureAssignments { get; set; }
        public SubstanceBuildTargetSettings[] buildTargetSettings { get; set; }
    }
}