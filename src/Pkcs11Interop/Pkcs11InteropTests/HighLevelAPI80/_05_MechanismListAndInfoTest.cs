/*
 *  Copyright 2012-2017 The Pkcs11Interop Project
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

/*
 *  Written for the Pkcs11Interop project by:
 *  Jaroslav IMRICH <jimrich@jimrich.sk>
 */

using System.Collections.Generic;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI80;
using NUnit.Framework;

namespace Net.Pkcs11Interop.Tests.HighLevelAPI80
{
    /// <summary>
    /// GetMechanismList and GetMechanismInfo tests.
    /// </summary>
    [TestFixture()]
    public class _05_MechanismListAndInfoTest
    {
        /// <summary>
        /// Basic GetMechanismList and GetMechanismInfo test.
        /// </summary>
        [Test()]
        public void _01_BasicMechanismListAndInfoTest()
        {
            Helpers.CheckPlatform();

            using (Pkcs11 pkcs11 = new Pkcs11(Settings.Pkcs11LibraryPath, Settings.AppType))
            {
                // Find first slot with token present
                Slot slot = Helpers.GetUsableSlot(pkcs11);

                // Get supported mechanisms
                List<CKM> mechanisms = slot.GetMechanismList();

                Assert.IsTrue(mechanisms.Count > 0);

                // Analyze first supported mechanism
                MechanismInfo mechanismInfo = slot.GetMechanismInfo(mechanisms[0]);

                // Do something interesting with mechanism info
                Assert.IsNotNull(mechanismInfo.MechanismFlags);
            }
        }
    }
}

