namespace ProcSubstanceEditor
{
    public class SubstanceMaterialInformation
    {
        public int serializedVersion { get; set; }
        public Vec2Pair offset { get; set; }
        public Vec2Pair scale { get; set; }
        public int generateMipMaps { get; set; }
        public int generateAllOutputs { get; set; }
        public int animationUpdateRate { get; set; }
    }
}