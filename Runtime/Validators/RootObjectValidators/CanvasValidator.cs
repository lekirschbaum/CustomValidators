#if UNITY_EDITOR
using LeKirschbaum.CustomValidators.Runtime.RootObjectValidators;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine;

[assembly: RegisterValidationRule(typeof(CanvasValidator), Name = "Canvas Validator", Description = "Validator for the Canvas component.")]

namespace LeKirschbaum.CustomValidators.Runtime.RootObjectValidators
{
    public class CanvasValidator : RootObjectValidator<Canvas>
    {
        [EnumToggleButtons]
        public ValidatorSeverity NoCanvasCameraSeverity;
        public ValidatorSeverity PixelPerfectSeverity;

        protected override void Validate(ValidationResult result)
        {
            var obj = this.Object;

            if (obj == null)
                return;

            if (obj.renderMode != RenderMode.ScreenSpaceOverlay)
            {
                if (!obj.worldCamera)
                {
                    result.Add(NoCanvasCameraSeverity,
                            "No camera has been added to the Canvas, this can lead to severe performance issues!")
                        .WithFix((FixArgs args) => obj.worldCamera = args.NewCamera);
                }
            }

            if (obj.renderMode != RenderMode.WorldSpace)
            {
                if (obj.pixelPerfect)
                {
                    result.Add(PixelPerfectSeverity,
                            "Pixel Perfect is enabled, disabling it slightly improves performance.")
                        .WithFix(() => obj.pixelPerfect = false);
                }
            }
        }

        private class FixArgs
        {
            public Camera NewCamera;
        }
    }
}
#endif