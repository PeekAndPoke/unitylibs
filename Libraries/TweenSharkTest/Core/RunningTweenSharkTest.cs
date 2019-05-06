using De.Kjg.TweenSharkPkg;
using De.Kjg.TweenSharkPkg.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TweenSharkTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "RunningTweenSharkTest" und soll
    ///alle RunningTweenSharkTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class RunningTweenSharkTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Testkontext auf, der Informationen
        ///über und Funktionalität für den aktuellen Testlauf bietet, oder legt diesen fest.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Zusätzliche Testattribute
        // 
        //Sie können beim Verfassen Ihrer Tests die folgenden zusätzlichen Attribute verwenden:
        //
        //Mit ClassInitialize führen Sie Code aus, bevor Sie den ersten Test in der Klasse ausführen.
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Mit ClassCleanup führen Sie Code aus, nachdem alle Tests in einer Klasse ausgeführt wurden.
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Ein Test für "GetTweenShark"
        ///</summary>
        [TestMethod()]
        public void GetTweenSharkTest()
        {
            TweenShark tweenShark = null; // TODO: Passenden Wert initialisieren
            RunningTweenShark target = new RunningTweenShark(tweenShark); // TODO: Passenden Wert initialisieren
            TweenShark expected = null; // TODO: Passenden Wert initialisieren
            TweenShark actual;
            actual = target.GetTweenShark();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "RunningTweenShark-Konstruktor"
        ///</summary>
        [TestMethod()]
        public void RunningTweenSharkConstructorTest()
        {
            TweenShark tweenShark = null; // TODO: Passenden Wert initialisieren
            RunningTweenShark target = new RunningTweenShark(tweenShark);
            Assert.Inconclusive("TODO: Code zum Überprüfen des Ziels implementieren");
        }

        /// <summary>
        ///Ein Test für "Add"
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            TweenShark tweenShark = null; // TODO: Passenden Wert initialisieren
            RunningTweenShark target = new RunningTweenShark(tweenShark); // TODO: Passenden Wert initialisieren
            ITweenSharkTweener tweener = null; // TODO: Passenden Wert initialisieren
            target.Add(tweener);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "EmitOnComplete"
        ///</summary>
        [TestMethod()]
        public void EmitOnCompleteTest()
        {
            TweenShark tweenShark = null; // TODO: Passenden Wert initialisieren
            RunningTweenShark target = new RunningTweenShark(tweenShark); // TODO: Passenden Wert initialisieren
            target.EmitOnComplete();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "EmitOnStart"
        ///</summary>
        [TestMethod()]
        public void EmitOnStartTest()
        {
            TweenShark tweenShark = null; // TODO: Passenden Wert initialisieren
            RunningTweenShark target = new RunningTweenShark(tweenShark); // TODO: Passenden Wert initialisieren
            target.EmitOnStart();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "EmitOnUpdate"
        ///</summary>
        [TestMethod()]
        public void EmitOnUpdateTest()
        {
            TweenShark tweenShark = null; // TODO: Passenden Wert initialisieren
            RunningTweenShark target = new RunningTweenShark(tweenShark); // TODO: Passenden Wert initialisieren
            target.EmitOnUpdate();
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "Remove"
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            TweenShark tweenShark = null; // TODO: Passenden Wert initialisieren
            RunningTweenShark target = new RunningTweenShark(tweenShark); // TODO: Passenden Wert initialisieren
            ITweenSharkTweener tweener = null; // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.Remove(tweener);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Tick"
        ///</summary>
        [TestMethod()]
        public void TickTest()
        {
            TweenShark tweenShark = null; // TODO: Passenden Wert initialisieren
            RunningTweenShark target = new RunningTweenShark(tweenShark); // TODO: Passenden Wert initialisieren
            long currentTicks = 0; // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.Tick(currentTicks);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "Progress"
        ///</summary>
        [TestMethod()]
        public void ProgressTest()
        {
            TweenShark tweenShark = null; // TODO: Passenden Wert initialisieren
            RunningTweenShark target = new RunningTweenShark(tweenShark); // TODO: Passenden Wert initialisieren
            float actual;
            actual = target.Progress;
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }
    }
}
