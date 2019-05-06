using De.Fipo.TweenSharkPkg;
using De.Fipo.TweenSharkPkg.Options;
using De.Fipo.UnityLib.Gui.Core;
using De.Fipo.UnityLib.Gui.Core.Components;
using De.Fipo.UnityLib.Gui.Core.Containers;
using De.Fipo.UnityLib.Gui.Core.Events;
using UnityEngine;

namespace De.Fipo.UnityLibPlayground.Assets.Scripts.Classes
{
    class GlobalGui : GuiStage
    {
        private static GlobalGui _instance = null;

        enum WasherConfig
        {
            Single,
            Xmas,
            Party,
        }

        // make it a singleton
        private GlobalGui()
        {
        }

        public static GlobalGui GetInstance()
        {
            return _instance ?? (_instance = new GlobalGui());
        }

        public void Initialize()
        {
            AddChild(
                new VGroup()
                    .SetPos(20, 20)
                    .SetSpacing(10)
                    .AddChild(
                        new Box(new Rect(20, 200, 20, 20), "Select Scene")
                            .SetAutoAdjustSize(true)
                            .SetPadding(10)
                            .AddChild(
                                new VGroup()
                                    .SetPos(0, 20)
                                    .SetSpacing(5)
                                    .AddChild(
                                        new Button(new Rect(0, 20, 100, 25), "Barn")
                                            .AddClickHandler(e => LoadScene("BarnScene"))
                                    )
                                    .AddChild(
                                        new Button(new Rect(0, 50, 100, 25), "Church")
                                            .AddClickHandler(e => LoadScene("ChurchScene"))
                                    )
                                    .AddChild(
                                        new Button(new Rect(0, 80, 100, 25), "Kitchen")
                                            .AddClickHandler(e => LoadScene("KitchenScene"))
                                    )
                            )
                    )
                    .AddChild(
                        new Box(new Rect(20, 200, 20, 20), "Dish Washer")
                            .SetAutoAdjustSize(true)
                            .SetPadding(10)
                            .AddChild(
                                new VGroup()
                                    .SetPos(0, 20)
                                    .SetSpacing(5)
                                    .AddChild(
                                        new Button(new Rect(0, 20, 100, 25), "Open / Close")
                                            .AddClickHandler(OpenClose)
                                    )
                                    .AddChild(
                                        new Button(new Rect(0, 20, 100, 25), "Spin me")
                                            .AddClickHandler(SpinWasher)
                                    )
                            )
                    )
                );


            AddChild(
                new VGroup()
                    .SetPos(150, 20)
                    .SetSpacing(10)
                    .AddChild(
                        new Box(new Rect(20, 200, 20, 20), "Select Setup")
                            .SetAutoAdjustSize(true)
                            .SetPadding(10)
                            .AddChild(
                                new VGroup()
                                    .SetPos(0, 20)
                                    .SetSpacing(5)
                                    .AddChild(
                                        new Button(new Rect(0, 20, 100, 25), "Single")
                                            .AddClickHandler(e => LoadDishWasherConfig(WasherConfig.Single))
                                    )
                                    .AddChild(
                                        new Button(new Rect(0, 50, 100, 25), "X-Mas")
                                            .AddClickHandler(e => LoadDishWasherConfig(WasherConfig.Xmas))
                                    )
                                    .AddChild(
                                        new Button(new Rect(0, 80, 100, 25), "Party")
                                            .AddClickHandler(e => LoadDishWasherConfig(WasherConfig.Party))
                                    )
                            )
                    )
                );
        }

        private void LoadScene(string scene)
        {
            Application.LoadLevel(scene);
        }

        private void LoadDishWasherConfig(WasherConfig config)
        {
            switch (config)
            {
                case WasherConfig.Single:
                    break;
                case WasherConfig.Xmas:
                    break;
                case WasherConfig.Party:
                    break;
            }
        }

        private GameObject FindGameObject(string path, GameObject root = null)
        {
            string[] parts = path.Split('/');

            Transform currentTransform;
            int startIdx;

            if (root != null)
            {
                currentTransform = root.transform;
                startIdx = 0;
            }
            else
            {
                root = GameObject.Find(parts[0]);
                if (root != null)
                {
                    currentTransform = root.transform;
                }
                else
                {
                    return null;
                }
                startIdx = 1;
            }

            for (int i = startIdx; i < parts.Length; i++)
            {
                if (currentTransform == null)
                {
                    return null;
                }
                currentTransform = currentTransform.Find(parts[i]);
            }

            return currentTransform.gameObject;
        }

        private GameObject GetDishWasher()
        {
            return FindGameObject("DishWasherContainer/DishWasher");
        }

        private GameObject GetDishWasherKlappe()
        {
            return FindGameObject("DishWasherContainer/DishWasher/Klappe");
        }

        private void SpinWasher(ComponentEvent e)
        {
            var dichWasher = GetDishWasher();

            TweenShark.To(dichWasher.transform, 10,
                new TweenOps(Ease.InOutQuad)
                .UV3CompTo("localEulerAngles", 27000, V3Compnent.Up)
                );
        }

        private void OpenClose(ComponentEvent e)
        {
            var dichWasher = GetDishWasher();
            var klappe = GetDishWasherKlappe();

            if (klappe != null && dichWasher != null)
            {
                Debug.Log("local euler: " + klappe.transform.localEulerAngles);
                Debug.Log("abs euler: " + klappe.transform.eulerAngles);
                Debug.Log("local rotation: " + klappe.transform.localRotation);
                Debug.Log("rotation: " + klappe.transform.rotation);

                if (klappe.transform.localEulerAngles.x <= 10)
                {
                    TweenShark.To(klappe.transform, 2,
                                  new TweenOps(Ease.InOutQuad)
                                      .UV3CompTo("localEulerAngles", -90, V3Compnent.Right)
                        );
                    TweenShark.To(dichWasher.transform, 2,
                                  new TweenOps(Ease.OutQuad)
                                      .UV3CompTo("position", 5, V3Compnent.Up)
                        );
                }
                else
                {
                    TweenShark.To(klappe.transform, 2,
                                  new TweenOps(Ease.InOutQuad)
                                      .UV3CompTo("localEulerAngles", 360, V3Compnent.Right)
                        );
                    TweenShark.To(dichWasher.transform, 2,
                                  new TweenOps(Ease.InQuad)
                                      .UV3CompTo("position", 0, V3Compnent.Up)
                        );
                }
            }
        }
    }
}
