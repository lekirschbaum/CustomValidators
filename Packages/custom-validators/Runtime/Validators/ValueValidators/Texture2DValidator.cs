#if UNITY_EDITOR
using LeKirschbaum.CustomValidators.Runtime.ValueValidators;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine;
using UnityEditor;

[assembly: RegisterValidationRule(typeof(Texture2DValidator), Name = "Texture2D Validator", Description = "Validator for Texture 2D assets.")]

namespace LeKirschbaum.CustomValidators.Runtime.ValueValidators
{
    public class Texture2DValidator : ValueValidator<Texture2D>
    {
        [EnumToggleButtons] public ValidatorSeverity MeshType;

        protected override void Validate(ValidationResult result)
        {
            var obj = this.Value;

            if (obj == null)
                return;

            string assetPath = AssetDatabase.GetAssetPath(obj);
            TextureImporter importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;

            if (importer == null)
                return;

            TextureImporterSettings textureSettings = new TextureImporterSettings();
            importer.ReadTextureSettings(textureSettings);

            if (textureSettings.spriteMeshType != SpriteMeshType.Tight)
            {
                result.Add(MeshType,
                        "Mesh Type of this Texture 2D asset is set to full rect, setting it to tight can improve performance.")
                    .WithFix(() => FixMeshType(importer, textureSettings));
            }
        }

        private void FixMeshType(TextureImporter Importer, TextureImporterSettings TextureSettings)
        {
            TextureSettings.spriteMeshType = SpriteMeshType.Tight;
            Importer.SetTextureSettings(TextureSettings);
            Importer.SaveAndReimport();
        }
    }
}
#endif