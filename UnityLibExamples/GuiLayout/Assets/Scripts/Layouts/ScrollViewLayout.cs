using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.UnityLib.Gui.Elements.Basic;
using De.Kjg.UnityLib.Gui.Elements.Container;
using UnityEngine;

namespace GuiLayout.Assets.Scripts.Layouts
{
    class ScrollViewLayout : GenericScrollView<ScrollViewLayout>
    {
        public ScrollViewLayout() : base(300, 400)
        {
            SetPadding(15, 15, 15, 15);

            VBox vbox;

            AddChild(
                vbox = new VBox()
                    .AddChild(
                        new Label(400, 22, "Scrollview with a vbox in it")
                    )
                );

            for (var i = 0; i < 5000; i++)
            {
                var a = i;
                vbox.AddChild(
                    new Button(100, 22, "Button " + i)
                    .OnClick(e => Debug.Log("button " + a))
                    );
            }

        }
    }
}
