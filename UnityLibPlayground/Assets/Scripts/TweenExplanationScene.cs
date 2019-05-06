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


public class TweenExplanationScene : MonoBehaviour
{

    private GameObject _cube;

    private GlobalGui _guiStage;

    private Button _btn;
	private Button _btn2;

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



    private void SetupUpGui() {
        // Initialize the loaders
        GuiModule.Initialize(this);
//        NetModule.Initialize(this);

        TweenSharkUnity3D.Initialize(this);

        _guiStage = GlobalGui.GetInstance();

        _guiStage.AddChild(
            _btn = new Button(new Rect(10, 10, 100, 25), "Click Me1")
                .AddClickHandler(e => TweenButton())
                .AddMouseOverHandler(e => Debug.Log("Over"))
                .AddMouseOutHandler(e => Debug.Log("Out"))
            );
		_guiStage.AddChild(
            _btn2 = new Button(new Rect(100, 200, 100, 25), "Klick mich!")
                .AddClickHandler(e => TweenButton2())
                .AddMouseOverHandler(e => Debug.Log("Over"))
                .AddMouseOutHandler(e => Debug.Log("Out"))
            );
    }

    private void TweenButton()
    {
        TweenShark.To(_btn, 5, new TweenOps(Ease.InOutQuart)
            .Prop(new PropertyOps("X", 500, false).Ease(Ease.Linear))
            .Prop(new PropertyOps("Y", 500, false).Ease(Ease.OutQuint))
        );
    }
	
	private void TweenButton2()
	{
        TweenShark.To(_btn2, 5, new TweenOps(Ease.InOutQuart)
            .Prop(new PropertyOps("Y", 500, false).Ease(Ease.Linear))
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
}
