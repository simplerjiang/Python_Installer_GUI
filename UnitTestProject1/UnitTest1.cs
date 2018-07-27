using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PythonInstaller_GUI;
using System.Diagnostics;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_GetModelsName()
        {
            string result = Form3.GetModelsName("Python      (1,2,3)");
            Debug.WriteLine(result);
        }
    }
}
