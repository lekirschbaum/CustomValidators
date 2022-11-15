#if UNITY_EDITOR
using LeKirschbaum.CustomValidators.Runtime.RootObjectValidators;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine;
using Sirenix.OdinInspector;

[assembly: RegisterValidationRule(typeof(AnimationValidator), Name = "Animation Validator", Description = "Validator for the Animation component.")]

namespace LeKirschbaum.CustomValidators.Runtime.RootObjectValidators
{
    public class AnimationValidator : RootObjectValidator<Animation>
    {
        [EnumToggleButtons]
        public ValidatorSeverity AnimationSeverity;

        protected override void Validate(ValidationResult result)
        {
            var obj = this.Object;

            if (obj == null)
                return;

            if (obj.transform.parent == null)
                return;

            if (obj.transform.GetComponentInParent<Canvas>())
            {
                if (obj.enabled)
                {
                    //result.Add(AnimationSeverity,
                    //    "Animating UI with the Unity Animator costs a lot of performance, due to dirtying the canvas. Use a tweener like <a href=\"http://dotween.demigiant.com/index.php\">Dotween</a>.");

                    result.Add(AnimationSeverity,
                            "Animating UI with the Unity Animator costs a lot of performance, due to dirtying the canvas. Use a tweener like Dotween.")
                        .WithFix(() => CustomFix(obj));
                }
            }
        }

        private void CustomFix(Animation animation)
        {
            animation.enabled = false;   // Hopefully a future fix, where the component can be deleted without any issues.

            Application.OpenURL("http://dotween.demigiant.com/index.php");
        }
    }
}
#endif