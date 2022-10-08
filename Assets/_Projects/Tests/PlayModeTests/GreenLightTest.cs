using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;

namespace PlayModeTests
{
    public class GreenLightTest
    {
        [UnityTest]
        public IEnumerator GreenLightTestWithEnumeratorPasses()
        {
            yield return null;

            Assert.Pass();
        }
    }
}