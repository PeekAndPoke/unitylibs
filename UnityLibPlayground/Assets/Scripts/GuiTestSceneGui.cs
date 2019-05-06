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

public class TweenedObject
{
    public sbyte _sbyte;
    public byte _byte;
    public short _short;
    public ushort _ushort;
    public int _int;
    public uint _uint;
    public long _long;
    public ulong _ulong;
    public float _float;
    public double _double;
    public float Y;
    public float aaa;
    public float bbb { get; set; }
    public int iii = 444;
    public string str = "asd";

    public TweenedObject ()
    {
        aaa = 111.0f;
        bbb = 333.0f;
    }

    public new string ToString()
    {
        return "_sbyte=" + _sbyte + " _byte=" + _byte + " _short=" + _short + " _ushort=" + _ushort + " _int=" + _int +
               " _uint=" + _uint + " _long=" + _long + " _ulong=" + _ulong + " _float=" + _float +
               "_double=" + _double;
    }
}


public class GuiTestSceneGui : MonoBehaviour
{

    private GameObject _cube;

    private GlobalGui _guiStage;


    private Button _btn1;
    private Box _youtubeBox;
    private VGroup _listView;
    private TextField _searchField;

    private TweenedObject _tweenedObject = new TweenedObject();

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
	        new Button(new Rect(20, 20, 100, 20), "BUTTON")
	            .AddClickHandler(OnButtonInListClicked)
	        );

	    _guiStage.AddChild(
	        _youtubeBox = new Box(new Rect(600, 50, 20, 20), "Youtube Search")
	                    .SetAutoAdjustSize(true)
	                    .AddChild(
	                        _searchField = new TextField(new Rect(0, 30, 400, 20))
	                                           .AddMouseOverHandler(e => Debug.Log("mouse over on SearchField"))
	                                           .AddMouseOutHandler(e => Debug.Log("mouse out on SearchField"))
	                                           .AddLeftMouseDownHandler(e => Debug.Log("Left mouse down on SearchField"))
	                                           .AddLeftMouseUpHandler(e => Debug.Log("Left mouse up on SearchField"))
	                    )

	                    .AddChild(
	                        new Button(new Rect(480, 30, 100, 20), "Search")
	                            .AddClickHandler(OnButton1)
	                            .AddMouseOverHandler(e => Debug.Log("MouseOver search " + e.Target + " " + e.CurrentTarget))
	                            .AddMouseOutHandler(e => Debug.Log("MouseOut search " + e.Target + " " + e.CurrentTarget))
	                    )

	                    .AddChild(
	                        new ScrollView(new Rect(0, 100, 580, 350))
	                            .AddChild(
	                                _listView = new VGroup()
	                                                .AddChild(new Label(new Rect(0, 0, 100, 20), "Text1"))
	                                                .AddChild(new Label(new Rect(0, 30, 100, 20), "Text2"))
	                                                .AddChild(new Label(new Rect(0, 60, 100, 20), "Text3"))
	                                                .AddChild(new Label(new Rect(0, 90, 100, 20), "Text4"))
	                                                .AddChild(new Label(new Rect(0, 120, 100, 20), "Text5"))
	                                                .AddChild(new Label(new Rect(0, 150, 100, 20), "Text6"))
	                                                .AddChild(new Label(new Rect(0, 180, 100, 20), "Text7"))
	                                                .AddChild(new Label(new Rect(0, 210, 100, 20), "Text8"))
	                                                .AddChild(new Label(new Rect(0, 240, 100, 20), "Text9"))
	                                                .SetPadding(20)
	                            )
	                    )
	        );

	    _listView
	        .AddLeftMouseDownHandler(e => Debug.Log("Left mouse down on ListView"))
            .AddLeftMouseUpHandler(e => Debug.Log("Left mouse up on ListView"))
            .AddRightMouseDownHandler(e => Debug.Log("Right mouse down on ListView"))
            .AddRightMouseUpHandler(e => Debug.Log("Right mouse up on ListView"))
            .AddMiddleMouseDownHandler(e => Debug.Log("Middle mouse down on ListView"))
            .AddMiddleMouseUpHandler(e => Debug.Log("Middle mouse up on ListView"))
            ;


        if (_youtubeBox != null)
        {
            _guiStage.AddChild(
                new Button(new Rect(200, 20, 100, 20), "Start Tween")
                    .AddClickHandler((e) =>
                    {
                        var random = new System.Random();
                        var opt = new TweenOps(Ease.OutQuad)
                            .PropTo("X", random.Next(800))
                            .PropTo("Y", random.Next(500))
                            .PropTo("PaddingTop", random.Next(100))
                            ;
                        TweenShark.To(_youtubeBox, 1f + random.Next(2), opt);

                        opt = new TweenOps(Ease.InOutQuad)
                            .PropTo("_sbyte", 100)
                            .PropTo("_byte", 100)
                            .PropTo("_short", 100)
                            .PropTo("_ushort", 100)
                            .PropTo("_int", 100)
                            .PropTo("_uint", 100)
                            .PropTo("_long", 100)
                            .PropTo("_ulong", 100)
                            .PropTo("_float", 100)
                            .PropTo("_double", 100)
                            ;

                        TweenShark.To(_tweenedObject, 10, opt);
                    })
                );

            _youtubeBox.AddClickHandler(onBox1Clicked);
        }

	    _guiStage.AddClickHandler(onStageClick);      
	}

    private void OnButtonInListClicked(ComponentEvent e)
    {
        Debug.Log("on Button in list");

//        _youtubeBox.Tween.MoveXTo(400, iTween.Hash("time", 5, "easetype", iTween.EaseType.easeInCirc));
//        _youtubeBox.Tween.MoveYTo(0, iTween.Hash("time", 5, "easetype", iTween.EaseType.easeInCirc));

//        var fieldInfo = (PropertyInfo) _youtubeBox.GetType().GetProperty("X");
//        fieldInfo.SetValue(_youtubeBox, (object) 400, null);

//        _youtubeBox.Tween.MovePaddingTo(100, iTween.Hash("time", 5));
//        _listView.Tween.MovePaddingTo(100, iTween.Hash("time", 5));

//        _youtubeBox.Tween.MoveToX(200);

//        gameObject.

//        iTween.ValueTo(gameObject, iTween.Hash("from", 0F, "to", 300F, "onUpdate", "OnUpdateFunc"));
    }

    void OnUpdateFunc(float x)
    {
        _youtubeBox.X = x;
    }

    private void onBox1Clicked(ComponentEvent e)
    {
        Debug.Log("Box1 Clicked Target:" + e.Target + " CurrentTarget:" + e.CurrentTarget);
        e.StopPropagation();
    }

    private void OnButton1(ComponentEvent e)
    {
//        SearchYoutube(_searchField.Text);

        Debug.Log("Button1 Target:" + e.Target + " CurrentTarget:" + e.CurrentTarget);
        e.StopPropagation();
    }

//    private YoutubeService _youtubeService;
//
//    private void SearchYoutube(string search)
//    {
//        _youtubeService = new YoutubeService();
//        _youtubeService.Search(OnSearchComplete, _searchField.Text);
//    }
//
//    private void OnSearchComplete(JSONObject jsonObject) {
//
//        _listView.RemoveAllChildren();
//
//        Debug.Log("DUMP");
//        Debug.Log(jsonObject.Dump(2));
//        Debug.Log("apiVersion: " + jsonObject["apiVersion"].AsString);
//
//
//        jsonObject["data"]["items"].ForEachIdx(
//            (idx, obj) => _listView.AddChild(
//                new Box(new Rect(0, 0, 400, 50))
//                    .AddChild(new Image(new Rect(0, 0, 80, 50), new UrlRequest(obj["thumbnail"]["sqDefault"].AsString)))
//                    .AddChild(new Label(new Rect(85, 0, 300, 30), obj["title"].AsString))
//                    .SetData(obj)
//                    .AddClickHandler(onVideoItemClicked)
//                    .SetAutoAdjustSize(true)
//                    .SetPadding(5)
//                    .SetMargin(5)
//            )
//        );
//                
//        Debug.Log(jsonObject["data"]["items"][0].Dump());
//
//        jsonObject["data"]["items"][0].ForEachKey(
//            (idx, obj) => Debug.Log("__" + idx + "__:__" + obj.AsObject)
//        );
//    }
//
//    private void onVideoItemClicked(ComponentEvent e)
//    {
//        var data = e.Target.GetData<JSONObject>();
//
//        var image = (Image) ((IGenericComponentContainer) e.CurrentTarget).Children[0];
//
//        _cube.renderer.material.mainTexture = image.Texture;
//
//        // var videoUrl = data["content"]["1"].AsString;
////        var videoUrl = "http://www.unity3d.com/webplayers/Movie/sample.ogg";
////
////        PlayVideo(videoUrl);
//    }

//    private IEnumerable PlayVideo(string videoUrl) {
//
//        Debug.Log("trying to stream Video: " + videoUrl);
//
//        var www = new WWW(videoUrl);
//
//        var movieTexture = www.movie;
//        while (!movieTexture.isReadyToPlay)
//        {
//            Debug.Log("Progress " + www.progress);
//            yield return www;
//        }
//
//        Debug.Log("ready to play");
//
//        _cube.guiTexture.texture = movieTexture;
//        _cube.audio.clip = movieTexture.audioClip;
//        movieTexture.Play();
//        _cube.audio.Play();
//
//    }

    private void onStageClick(ComponentEvent e)
    {
        Debug.Log("GUIStage Clicked Target:" + e.Target + " CurrentTarget:" + e.CurrentTarget);
    }

    private float _x;

	// Update is called once per frame
	public void OnGUI ()
	{
//        Debug.Log("OnGUI");
        if (_guiStage == null)
        {
//            Debug.Log("creating gui");
            SetupUpGui();
        }

//	    var mat = Matrix4x4.TRS(new Vector3(0, 50, 0), Quaternion.Euler(0, 0, 0), new Vector3(1, 1, 1));
//        var mat2 = Matrix4x4.TRS(new Vector3(_x, 0, 0), Quaternion.Euler(0, 0, 0), new Vector3(1, 1, 1));
//	    GUI.matrix = (mat*mat2) * mat2.inverse;
	    _x += 0.2F;
        _guiStage.Draw();
	}

    public void Update ()
    {
//        _cube.transform.Rotate(Vector3.up, Time.deltaTime * 5);
//        _cube.transform.Rotate(Vector3.right, Time.deltaTime * 3);

//        Debug.Log(_tweenedObject.ToString());

        // if (_youtubeBox != null) _youtubeBox.X += 0.1F;
    }
}
