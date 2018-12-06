using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace ProcSubstanceEditor
{
    public class SubstanceGraphInstanceData
    {
        /*
        - outputName: diffuse
          alphaSource: source
        - outputName: specular
          alphaSource: specular
        - outputName: normal
          alphaSource: source
        - outputName: bump
          alphaSource: bump
        - outputName: displacement
          alphaSource: displacement
        - outputName: height
          alphaSource: source


    - outputName: baseColor
      alphaSource: baseColor
    - outputName: normal
      alphaSource: normal
    - outputName: specular
      alphaSource: specular
    - outputName: glossiness
      alphaSource: glossiness
    - outputName: roughness
      alphaSource: roughness
    - outputName: metallic
      alphaSource: smoothness
    - outputName: height
      alphaSource: height

         */

        private Dictionary<string, string> _outputAlphaMaps = new Dictionary<string, string>
        {
            {"diffuse", "source"},
            {"specular", "specular"},
            {"normal", "source"},
            {"bump", "bump"},
            {"displacement", "displacement"},
            {"height", "source"},
            {"baseColor","baseColor" },
            {"glossiness","glossiness" },
            {"roughness","roughness" },
            {"metallic","smoothness" },
            // TODO: Need PBR maps
        };

        private string _defaultAlpha = "source";

        public string graphLabel { get; set; }
        public string prototypeName { get; set; }
        public int graphDescIndex { get; set; }
        public int generateAllOutputs { get; set; }
        public int generateMipMaps { get; set; }
        [YamlMember(ScalarStyle = ScalarStyle.DoubleQuoted)]
        public string preset { get; set; } // " <sbspreset pkgurl=\"pkg://bricks_032/bricks_032\" label=\"\" >\n </sbspreset>\n" -- looks important
        public string shaderName { get; set; } = "Standard";
        public string outputNames { get; set; } = "diffuse,normal,height"; // There's probably more in PBR, check TextureAssignments in old format
        public SubstanceTexturePackingList[] texturePackingList { get; set; }
        public SubstanceTextureParameter[] textureParameters { get; set; }
        public SubstanceColorSpace[] colorSpaceList { get; set; }
        // inputTextureMap
        public SubstanceTargetSetting[] targetSettingList { get; set; }
        public AssetReferenceData material { get; set; }
        // generatedTextures

        public SubstanceGraphInstanceData(SubstanceImporterData oldFormat)
        {
            graphLabel = oldFormat.name;
            prototypeName = oldFormat.prototypeName;
            generateAllOutputs = oldFormat.materialInformation.generateAllOutputs;
            generateMipMaps = oldFormat.materialInformation.generateMipMaps;
            preset = " <sbspreset pkgurl=\"pkg://"+prototypeName+"/"+prototypeName+"\" label=\"\" >\\n </sbspreset>\\n";
            shaderName = string.IsNullOrEmpty(oldFormat.shaderName) ? "Standard" : oldFormat.shaderName;

            var channelsInUse = oldFormat.textureParameters.Select(tp => tp.name.Split('_').Last().ToLowerInvariant());

            outputNames = string.Join(",", channelsInUse);
            texturePackingList = channelsInUse.Select(c => new SubstanceTexturePackingList
            {
                alphaSource = _outputAlphaMaps.ContainsKey(c) ? _outputAlphaMaps[c] : _defaultAlpha,
                outputName = c
            }).ToArray();

            textureParameters = oldFormat.textureParameters.Select(t => new SubstanceTextureParameter
            {
                aniso = t.aniso,
                filterMode = t.filterMode,
                textureName = t.name,
                wrapMode = t.wrapMode
            }).ToArray();

            colorSpaceList = channelsInUse.Select(c => new SubstanceColorSpace
            {
                bLinear = c == "diffuse" || c == "specular" ? 0 : 1,
                outputName = c
            }).ToArray();

            targetSettingList = new SubstanceTargetSetting[]
            {
                new SubstanceTargetSetting
                {
                    bGenerateOnLoad = 0,
                    bLockRatio = 1,
                    bHighQuality = 0,
                    label = "Default",
                    textureFormat = 0,
                    textureHeight = 1024,
                    textureWidth = 1024
                }, 
            };

            material = new AssetReferenceData {instanceID = 0};
        }
    }
}