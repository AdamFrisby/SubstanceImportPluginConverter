using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YamlDotNet.Core;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace ProcSubstanceEditor
{
    // Aka ScriptedImporter
    public class ProceduralMaterialUpgradedMetaFormat
    {
        public Dictionary<int, string> fileIDToRecycleName { get; set; }
        
        
        public AssetReferenceData script { get; set; } = new AssetReferenceData {fileID = 232528478, guid = "43a8bbf65be290d44ba52b94476242b9", type = 3}; // This is the new ScriptableImporter script ID

        public int version { get; set; } = 13;
        public SubstanceGraphInstanceData[] mGraphInstanceData { get; set; }

        public ProceduralMaterialUpgradedMetaFormat(ProceduralMaterialOriginalMetaFormat original)
        {
            mGraphInstanceData = original.materialInstances.Select(orig => new SubstanceGraphInstanceData(orig)).ToArray();
            fileIDToRecycleName = new Dictionary<int, string>();
            foreach (var instanceData in mGraphInstanceData) // There's others, we don't care about them tho.
            {
                fileIDToRecycleName[FileIDUtil.ComputeSubstanceName(instanceData.graphLabel)] = "mat." + instanceData.graphLabel;

                foreach (var parameter in instanceData.textureParameters)
                {
                    fileIDToRecycleName[FileIDUtil.ComputeSubstanceTextureName(parameter.textureName)] =
                        parameter.textureName;
                }
            }
        }
    }
}
