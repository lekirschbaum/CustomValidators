#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine.UI;
using LeKirschbaum.CustomValidators.RootObjectValidators;
using Sirenix.OdinInspector;

[assembly: RegisterValidationRule(typeof(ImageValidator), Name = "Image Validator", Description = "Validator for the image component.")]

namespace LeKirschbaum.CustomValidators.RootObjectValidators
{
    public class ImageValidator : RootObjectValidator<Image>
    {
        [EnumToggleButtons]
        public ValidatorSeverity RaycastTargetSeverity;
        public ValidatorSeverity UseSpriteMeshSeverity;

        protected override void Validate(ValidationResult result)
        {
            var obj = this.Object;

            if (obj == null)
                return;

            if (obj.raycastTarget)
            {
                result.Add(RaycastTargetSeverity, "Raycast Target is enabled on this image, is this intended? Disabling it slightly improves the performance.")
                    .WithFix(() => obj.raycastTarget = false);
            }

            if (obj.sprite != null && obj.type == Image.Type.Simple)  // Otherwise it would still appear as an error, even when the image type isn't simple.
            {
                if (!obj.useSpriteMesh)
                {
                    result.Add(UseSpriteMeshSeverity,
                            "Use Sprite Mesh not enabled, enable it to decrease the draw call and save performance.")
                        .WithFix(() => obj.useSpriteMesh = true);
                }
            }
        }
    }
}
#endif