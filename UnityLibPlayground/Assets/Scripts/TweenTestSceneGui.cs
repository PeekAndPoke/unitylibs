using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Reflection;
using De.Fipo.TweenSharkPkg;
using De.Fipo.TweenSharkPkg.Options;
using De.Fipo.UnityLib.Gui;
using De.Fipo.UnityLib.Gui.Core.Components;
using De.Fipo.UnityLib.Gui.Core.Containers;
using De.Fipo.UnityLib.Gui.Core.Containers.Base;
using De.Fipo.UnityLib.Gui.Core.Events;
using De.Fipo.UnityLibPlayground.Assets.Scripts.Classes;
using UnityEngine;
using System.Collections;
using Random = System.Random;


public class TweenTestSceneGui : MonoBehaviour
{

    private GameObject _cube;

    private GlobalGui _guiStage;


    private Button _btn1;
    private Box _youtubeBox;
    private VGroup _listView;
    private TextField _searchField;
    private TextField _progressTextField;
    private TextField _cubeCountTextField;

    private int _cubeCount = 0; 

    private TweenedObject _tweenedObject = new TweenedObject();

    private SelectionGrid _easingSelection;
    private TextField _tweenDuration;

    private Random random = new System.Random();

    private SelectionGrid _tweenerSelection;

    private long _lastTicks = DateTime.Now.Ticks;
    private long _accumulatedTicks = 0;

    private EaseFunction[] _easingFunctions =
        {
            Ease.Linear,
            Ease.Linear,
            Ease.Linear,
            Ease.InQuad,
            Ease.OutQuad,
            Ease.InOutQuad,
            Ease.InCubic,
            Ease.OutCubic,
            Ease.InOutCubic,
            Ease.InQuart,
            Ease.OutQuart,
            Ease.InOutQuart,
            Ease.InQuint,
            Ease.OutQuint,
            Ease.InOutQuint,
            Ease.InSine,
            Ease.OutSine,
            Ease.InOutSine,
            Ease.InExpo,
            Ease.OutExpo,
            Ease.InOutExpo,
            Ease.InCirc,
            Ease.OutCirc,
            Ease.InOutCirc,
            Ease.InBounce,
            Ease.OutBounce,
            Ease.InOutBounce,
        };

    private string[] _easingNames =
        {
			"Linear",
			"Linear",
			"Linear",
			"InQuad",
			"OutQuad",
			"InOutQuad",
			"InCubic",
			"OutCubic",
			"InOutCubic",
			"InQuart",
			"OutQuart",
			"InOutQuart",
			"InQuint",
			"OutQuint",
			"InOutQuint",
			"InSine",
			"OutSine",
			"InOutSine",
			"InExpo",
			"OutExpo",
			"InOutExpo",
			"InCirc",
			"OutCirc",
			"InOutCirc",
			"InBounce",
			"OutBounce",
			"InOutBounce",
        };



    public void Awake ()
    {
        Application.targetFrameRate = -1;
    }

	// Use this for initialization
	public void Start ()
	{

	    // get the cube game object
	    _cube = GameObject.Find("Cube");

        SetupUpGui();
	}

    private float GetTweenDuration()
    {
        try
        {
            return Convert.ToSingle(_tweenDuration.Text);
        }
        catch
        {
        }
        return 0;
    }

    private EaseFunction GetSelectedEasingFunction()
    {
        return _easingFunctions[_easingSelection.Selected];
    }

    private void SpinCubeAroundX()
    {
        TweenShark.To(_cube.transform, 10, new TweenOps(GetSelectedEasingFunction())
            .UV3CompBy("localEulerAngles", 600, V3Compnent.Right)
            .OnUpdate(t => Debug.Log("x: " +_cube.transform.localEulerAngles.x))
            );
    }
    private void SpinCubeAroundY()
    {
        TweenShark.To(_cube, 10, new TweenOps(GetSelectedEasingFunction())
            .URotateTo(1200, V3Compnent.Up)
            );
    }
    private void SpinCubeAroundZ()
    {
        TweenShark.To(_cube, 10, new TweenOps(GetSelectedEasingFunction())
            .URotateTo(1200, V3Compnent.Forward)
            .OnStart(t => Debug.Log("OnStart Progress = " + t.Progress))
            .OnUpdate(t => _progressTextField.Text = "Progress: " + t.Progress)
            .OnComplete(t => Debug.Log("OnComplete Progress = " + t.Progress))
            );
    }

    private void BringCubeTo(GameObject go, float forward, float right, float up, bool autoResume)
    {
        if (_tweenerSelection.Selected == 1)
        {
            iTween.Init(go);
            iTween.MoveTo(go, iTween.Hash(
                "x", right,
                "y", up,
                "z", forward,
                "Time", GetTweenDuration(),
                "onComplete", (Action<object>) ((obj) =>
                              {
                                  if (autoResume)
                                  {
                                      BringCubeTo(go, (random.Next(700) - 350)/100.0f, (random.Next(700) - 350)/100.0f,
                                                  (random.Next(500) - 250)/100.0f, true)
                                      ;
                                  }
                              }) 
                )
            );
        }
        else
        {
            var ts = TweenShark.To(go, GetTweenDuration(), new TweenOps(GetSelectedEasingFunction())
//            var ts = TweenShark.To(go, GetTweenDuration(), new TweenOps(EaseEx.InElastic, new object[] {0.1f, 0.5f})
                .UMoveTo(new Vector3(right, up, forward))
//                .UColorTo(new Color(random.Next(100) / 100.0f, random.Next(100) / 100.0f, random.Next(100) / 100.0f, random.Next(100) / 100.0f))
                
                .OnComplete((obj) =>
                {
                    if (autoResume)
                    {
                        BringCubeTo(go, (random.Next(700) - 350) / 100.0f, (random.Next(700) - 350) / 100.0f,
                                    (random.Next(500) - 250) / 100.0f, true)
                        ;
                    }
                })
            );
        }
    }

    private void TweenMaterial()
    {
        TweenShark.To(_cube, GetTweenDuration(), new TweenOps(GetSelectedEasingFunction())
                                                     .UFadeMaterials(new Material[]
                                                                         {
                                                                             _cube.renderer.materials[1],
                                                                             _cube.renderer.materials[2]
                                                                         })
            );
    }

    private void BringCubeVertical(float up)
    {
        TweenShark.To(_cube.transform, GetTweenDuration(), new TweenOps(GetSelectedEasingFunction())
            .UV3CompBy("position", up, V3Compnent.Up)
            );
    }

    private void StartTheMaddness()
    {
        int i;
        for (i = 0; i < 100; i++)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            cube.renderer.material.shader = Shader.Find("Transparent/Diffuse");

            BringCubeTo(cube, (random.Next(700) - 350) / 100.0f, (random.Next(700) - 350) / 100.0f, (random.Next(500) - 250) / 100.0f, true);
        }

        _cubeCount += i;
    }

    private void SetupUpGui() {
        // Initialize the loaders
        GuiModule.Initialize(this);
//        NetModule.Initialize(this);

        TweenSharkUnity3D.Initialize(this);

        _guiStage = GlobalGui.GetInstance();

        _guiStage.AddChild(
            new VGroup()
                .SetPos(10, 10)
                .SetPadding(5)
                .SetSpacing(5)
                .AddChild(
                    new Box(new Rect(20, 50, 300, 300), "TweenShark")
                        .SetAutoAdjustSize(true)
                        .AddChild(
                            new VGroup()
                                .SetPos(0, 20)
                                .SetPadding(5)
                                .AddChild(
                                    new Button(new Rect(5, 20, 100, 25), "SpinCube-X")
                                        .AddClickHandler((e) => SpinCubeAroundX())
                                )
                                .AddChild(
                                    new Button(new Rect(5, 20, 100, 25), "SpinCube-Y")
                                        .AddClickHandler((e) => SpinCubeAroundY())
                                )
                                .AddChild(
                                    new Button(new Rect(5, 20, 100, 25), "SpinCube-Z")
                                        .AddClickHandler((e) => SpinCubeAroundZ())
                                )
                        )
                        .AddChild(
                            // first column
                        new VGroup()
                            .SetPos(120, 20)
                            .SetPadding(5)
                            .AddChild(
                                new Button(new Rect(5, 20, 40, 25), "\\")
                                    .AddClickHandler(e => BringCubeTo(_cube, 3, -3, 0, false))
                            )
                            .AddChild(
                                new Button(new Rect(5, 20, 40, 25), "-")
                                    .AddClickHandler(e => BringCubeTo(_cube, 0, -3, 0, false))
                            )
                            .AddChild(
                                new Button(new Rect(5, 20, 40, 25), "/")
                                    .AddClickHandler(e => BringCubeTo(_cube, -3, -3, 0, false))
                            )
                        )
                        .AddChild(
                            // second column
                        new VGroup()
                            .SetPos(160, 20)
                            .SetPadding(5)
                            .AddChild(
                                new Button(new Rect(5, 20, 40, 25), "|")
                                    .AddClickHandler((e) => BringCubeTo(_cube, 3, 0, 0, false))
                            )
                            .AddChild(
                                new Button(new Rect(5, 20, 40, 25), "+")
                                    .AddClickHandler((e) => BringCubeTo(_cube, 0, 0, 0, false))
                            )
                            .AddChild(
                                new Button(new Rect(5, 20, 40, 25), "|")
                                    .AddClickHandler((e) => BringCubeTo(_cube, -3, 0, 0, false))
                            )
                        )
                        .AddChild(
                            // third column
                        new VGroup()
                            .SetPos(200, 20)
                            .SetPadding(5)
                            .AddChild(
                                new Button(new Rect(5, 20, 40, 25), "/")
                                    .AddClickHandler((e) => BringCubeTo(_cube, 3, 3, 0, false))
                            )
                            .AddChild(
                                new Button(new Rect(5, 20, 40, 25), "-")
                                    .AddClickHandler((e) => BringCubeTo(_cube, 0, 3, 0, false))
                            )
                            .AddChild(
                                new Button(new Rect(5, 20, 40, 25), "\\")
                                    .AddClickHandler((e) => BringCubeTo(_cube, -3, 3, 0, false))
                            )
                        )
                        .AddChild(
                            // 4th column
                        new VGroup()
                            .SetPos(250, 20)
                            .SetPadding(5)
                            .AddChild(
                                new Button(new Rect(5, 20, 40, 25), "/\\")
                                    .AddClickHandler((e) => BringCubeVertical(0.5f))
                            )
                            .AddChild(
                                new Button(new Rect(5, 20, 40, 25), "-")
                                    .AddClickHandler((e) => BringCubeVertical(0))
                            )
                            .AddChild(
                                new Button(new Rect(5, 20, 40, 25), "\\/")
                                    .AddClickHandler((e) => BringCubeVertical(-0.5f))
                            )
                        )
                )
                .AddChild(
                        _progressTextField = new TextField(new Rect(0, 0, 300, 20), "")
                )
                .AddChild(
                    new Box(new Rect(20, 85, 300, 200), "Madness")
                    .SetAutoAdjustSize(true)
                    .SetPadding(5)
                    .AddChild(
                        new Button(new Rect(0, 20, 290, 30), "Action!")
                        .AddClickHandler(e => StartTheMaddness())
                    )
                    .AddChild(
                        _cubeCountTextField = new TextField(new Rect(0,60,290, 20), "")
                    )
                    .AddChild(
                        _tweenerSelection = new SelectionGrid(new Rect(0,90,290,25), new string[] { "TweenShark", "iTween"}, 2)
                    )
                )
                .AddChild(
                    new Box(new Rect(20, 50, 350, 300), "Easing")
                    .SetAutoAdjustSize(true)
                    .SetPadding(5)
                    .AddChild(
                        new Label(new Rect(0,20,140,18), "Tween Duration in sec")
                    )
                    .AddChild(
                        _tweenDuration = new TextField(new Rect(150,20,100,20), "5")
                    )
                    .AddChild(
                        _easingSelection = new SelectionGrid(new Rect(0, 50, 300, 200), _easingNames, 3).SetSelection(5)
                    )
                )
                .AddChild(
                    new Box(new Rect(20, 50, 350, 300), "Material")
                    .SetAutoAdjustSize(true)
                    .SetPadding(5)
                    .AddChild(
                        new Button(new Rect(0, 25, 100, 25), "Tween Mat")
                        .AddClickHandler(e => TweenMaterial())
                    )
                )

            );
	}


   // Update is called once per frame
	public void OnGUI ()
	{
        if (_guiStage == null)
        {
            SetupUpGui();
        }

        _guiStage.Draw();
	}

    public void Update ()
    {
        var currentTicks = DateTime.Now.Ticks;
        var deltaTicks = currentTicks - _lastTicks;
        float fps = (10000.0f * 1000.0f) / (currentTicks - _lastTicks);
        _lastTicks = currentTicks;

        _accumulatedTicks += deltaTicks;

        if (_accumulatedTicks > 10000 * 1000 / 10)
        {
            _accumulatedTicks = 0;
            _cubeCountTextField.Text = "Cubes: " + (_cubeCount + 1) + " fps: " + fps;
        }
    }
}
