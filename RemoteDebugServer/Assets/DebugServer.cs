using De.Kjg.Diversity.Unity.Debug.Remote;
using De.Kjg.Diversity.Unity.Debug.Remote.Server;
using De.Kjg.Diversity.Unity.Modules;
using De.Kjg.TweenSharkPkg;
using UnityEngine;
using System.Collections;

public class DebugServer : MonoBehaviour
{
    public GUISkin GuiSkin;

    private UnityModuleRegistry _unityModules;


	// Use this for initialization
	public void Start () {
        _unityModules = new UnityModuleRegistry();
        _unityModules.Register(new DebugServerModule(GuiSkin));
	    
	}
	
	// Update is called once per frame
	public void Update () {
	
	}
}
