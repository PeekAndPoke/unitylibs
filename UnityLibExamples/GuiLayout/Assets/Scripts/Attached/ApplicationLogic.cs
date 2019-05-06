using De.Kjg.TweenSharkPkg;
using De.Kjg.UnityLib.Gui;
using De.Kjg.UnityLib.Unity.GuiBridge;
using UnityEngine;

namespace GuiLayout.Assets.Scripts.Attached
{
    public class ApplicationLogic : MonoBehaviour
    {
        public GUISkin GuiSkin;
        public Texture2D Image1;
        public GUIStyle ImageButton1;

        private GuiStage _stage;

        private static ApplicationLogic _instance;
        private UnityGuiRenderer _renderer;
        private UnityHardware _hardware;

        public ApplicationLogic()
        {
            _instance = this;
        }

        public static ApplicationLogic Instance 
        {
            get
            {
                return _instance;
            }
        }

        // Use this for initialization
        void Start()
        {
            TweenSharkUnity3D.Initialize(this);

            // make sure that this object always stay in the scene
            DontDestroyOnLoad(this);

            _renderer = new UnityGuiRenderer(GuiSkin.ToSkin());
            _hardware = new UnityHardware();

            _stage = new GuiStage();
            _stage.AddChild(new GuiMain());
            _stage.SetDebugMode(true);
        }

        // Update is called once per frame
        void Update()
        {
        }

        // called to handle the gui
        void OnGUI()
        {
            if (_stage != null)
            {
                // take care that our gui is drawn
                _stage.Render(_renderer, _hardware, Event.current.type == EventType.Layout);
            }
        }
    }
}
