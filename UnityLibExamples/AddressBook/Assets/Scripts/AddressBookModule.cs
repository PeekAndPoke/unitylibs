using AddressBookExample.Assets.Scripts.GuiPkg;
using AddressBookExample.Assets.Scripts.ModelPkg;
using AddressBookExample.Assets.Scripts.Signals;
using De.Kjg.UnityLib.DI;
using De.Kjg.UnityLib.L10N;
using De.Kjg.UnityLib.L10N.Interfaces;
using De.Kjg.UnityLib.MVC.DataBinding;
using UnityEngine;

namespace AddressBookExample.Assets.Scripts
{
    class AddressBookModule : StandardModule
    {
        public Gui Gui;
        public MonoBehaviour Scene;
        public Model Model;
        public InputSignals InputSignals = new InputSignals();
        public ControllerSignals ControllerSignals = new ControllerSignals();
        public IL10N L10N;

        public AddressBookModule(Gui gui, MonoBehaviour scene)
        {
            Gui = gui;
            Scene = scene;
            // create the model by analyzing all members if they have the [CreateBindable] attribute set.
            Model = BindableFactory.CreateObjectRecursive<Model>();
            // initialize the language data holder
            L10N = new LocalizedLanguageHolder();
        }

        public override void Load()
        {
            // Bind IKernel to the instance of our kernel
            Bind<IKernel>().ToInstance(Kernel);
            // bind model to instance            
            Bind<Model>().ToInstance(Model);
            // bind Gui to instance
            Bind<Gui>().ToInstance(Gui);
            // bind l10n
            Bind<IL10N>().ToInstance(L10N);
            
            // bind signals
            Bind<InputSignals>().ToInstance(InputSignals);
            Bind<ControllerSignals>().ToInstance(ControllerSignals);
        }

        public void Update()
        {
        }

        public void UpdateGui()
        {
            Gui.Update();

            if (Event.current.isKey)
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.D) && Event.current.control && Event.current.shift && Event.current.alt)
                    {
                        Gui.SetDebugMode(!Gui.GetDebugMode());
                    }
                }
            }
        }
    }
}