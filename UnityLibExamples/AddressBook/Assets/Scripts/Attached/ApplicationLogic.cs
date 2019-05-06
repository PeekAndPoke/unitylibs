using AddressBookExample.Assets.Scripts.GuiPkg;
using De.Kjg.TweenSharkPkg;
using UnityEngine;

namespace AddressBookExample.Assets.Scripts.Attached
{
    public class ApplicationLogic : MonoBehaviour
    {
        // the GUISkin to use
        public GUISkin GuiSkin;
        // the MVC-context
        private AddressBookContext _context;
        // the DI-Module
        private AddressBookModule _mainModule;
        // our gui root element
        private Gui _gui;

        // Use this for initialization
        void Start()
        {
            // make sure that this object always stay in the scene
            DontDestroyOnLoad(this);
            // initialize the tweener (optional)
            TweenSharkUnity3D.Initialize(this);
            // create the gui root element 
            _gui = new Gui(GuiSkin);
            // create our DI-module (there are depency injection will be defined in the method Load())
            _mainModule = new AddressBookModule(_gui, this);
            // create our MVC-context. Here we will map views to their mediators
            _context = new AddressBookContext(_mainModule);
        }

        // Update is called once per frame
        void Update()
        {
            if (_mainModule != null)
            {
                _mainModule.Update();
            }
        }

        // called to handle the gui
        void OnGUI()
        {
            if (_mainModule != null)
            {
                // take care that our gui is drawn
                _mainModule.UpdateGui();
            }
        }
    }
}
