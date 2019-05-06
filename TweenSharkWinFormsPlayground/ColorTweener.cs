using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using De.Kjg.TweenSharkPkg.Tweening.PropertyTweens.Base;

namespace TweenSharkWinFormsPlayground
{
    class ColorTweener : GenericTweener<Color>
    {
        private Color _color = new Color();

        public override void CalculateAndSetValue(float deltaTime)
        {
            _color = Color.FromArgb(
                (int) Ease(deltaTime, StartValue.A, TargetValue.A - StartValue.A),
                (int) Ease(deltaTime, StartValue.R, TargetValue.R - StartValue.R),
                (int) Ease(deltaTime, StartValue.G, TargetValue.G - StartValue.G),
                (int) Ease(deltaTime, StartValue.B, TargetValue.B - StartValue.B)
            );

            SetValue(_color);
        }

        protected override Color AddValues(Color val1, Color val2)
        {
            return Color.FromArgb(val1.A + val2.A, val1.R + val2.R, val1.G + val2.G, val1.B + val2.B);
        }
    }
}
