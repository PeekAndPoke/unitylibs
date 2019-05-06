using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using AddressBookExample.Assets.Scripts.GuiPkg;
using De.Kjg.UnityLib.DI;
using De.Kjg.UnityLib.L10N;
using De.Kjg.UnityLib.L10N.Interfaces;
using De.Kjg.UnityLib.MVC.Commands;
using UnityEngine;

namespace AddressBookExample.Assets.Scripts.Controller
{
    /// <summary>
    /// The startup command bootstraps the application
    /// </summary>
    class StartUpCommand : TypeSafeCommand
    {
        #pragma warning disable 0649    // unterdrückt die Warnung, dass die Felder nie zugeweisen werden
        [Inject] public Gui Gui;
        [Inject] public IL10N L10N;
        #pragma warning restore 0649

        public bool DoExecute()
        {
            Debug.Log("StartUpCommand::DoExecute");
            
            LoadL10NData();
            L10N.SetLanguage(LanguageCode.EN);

            // setup the main application frame
            Gui.SetL10N(L10N);
            Gui.AddChild(new ApplicationFrame());

            return true;
        }

        protected void LoadL10NData()
        {
            var importer = new XliffImporter();
            var xml = new XmlDocument();
            var xliff = Resources.Load("L10N/default.xliff") as TextAsset;
            xml.LoadXml(xliff.text);
            importer.Import(xml, (LocalizedLanguageHolder)L10N);
        }

    }
}
