using System.Collections.Generic;

namespace ProcSubstanceEditor
{
    public class SubstanceMaterialProperties
    {
        public int serializedVersion { get; set; }
        public List<Dictionary<string, SubstanceTexEnv>> texEnvs { get; set; }
        public List<Dictionary<string, float>> floats { get; set; }
        public List<Dictionary<string, SubstanceColor>> colors { get; set; }
    }
}