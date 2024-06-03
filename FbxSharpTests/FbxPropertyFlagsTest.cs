using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxPropertyFlagsTest : TestBase
    {
        [Test]
        public void FbxPropertyFlags_EInheritType_IdentifiersHaveSpecificValues()
        {
            // expect:
            Assert.That((int)FbxPropertyFlags.EInheritType.eOverride, Is.EqualTo(0));
            Assert.That((int)FbxPropertyFlags.EInheritType.eInherit, Is.EqualTo(1));
            Assert.That((int)FbxPropertyFlags.EInheritType.eDeleted, Is.EqualTo(2));
        }

        [Test]
        public void FbxPropertyFlags_EFlags_IdentifiersHaveSpecificValues()
        {
            // expect:
            Assert.That((int)FbxPropertyFlags.EFlags.eNone, Is.EqualTo(0));
            Assert.That((int)FbxPropertyFlags.EFlags.eStatic, Is.EqualTo(1));
            Assert.That((int)FbxPropertyFlags.EFlags.eAnimatable, Is.EqualTo(2));
            Assert.That((int)FbxPropertyFlags.EFlags.eAnimated, Is.EqualTo(4));
            Assert.That((int)FbxPropertyFlags.EFlags.eImported, Is.EqualTo(8));
            Assert.That((int)FbxPropertyFlags.EFlags.eUserDefined, Is.EqualTo(16));
            Assert.That((int)FbxPropertyFlags.EFlags.eHidden, Is.EqualTo(32));
            Assert.That((int)FbxPropertyFlags.EFlags.eNotSavable, Is.EqualTo(64));

            Assert.That((int)FbxPropertyFlags.EFlags.eLockedMember0, Is.EqualTo(128));
            Assert.That((int)FbxPropertyFlags.EFlags.eLockedMember1, Is.EqualTo(256));
            Assert.That((int)FbxPropertyFlags.EFlags.eLockedMember2, Is.EqualTo(512));
            Assert.That((int)FbxPropertyFlags.EFlags.eLockedMember3, Is.EqualTo(1024));
            Assert.That((int)FbxPropertyFlags.EFlags.eLockedAll, Is.EqualTo(1920));

            Assert.That((int)FbxPropertyFlags.EFlags.eMutedMember0, Is.EqualTo(2048));
            Assert.That((int)FbxPropertyFlags.EFlags.eMutedMember1, Is.EqualTo(4096));
            Assert.That((int)FbxPropertyFlags.EFlags.eMutedMember2, Is.EqualTo(8192));
            Assert.That((int)FbxPropertyFlags.EFlags.eMutedMember3, Is.EqualTo(16384));
            Assert.That((int)FbxPropertyFlags.EFlags.eMutedAll, Is.EqualTo(30720));

            Assert.That((int)FbxPropertyFlags.EFlags.eUIDisabled, Is.EqualTo(32768));
            Assert.That((int)FbxPropertyFlags.EFlags.eUIGroup, Is.EqualTo(65536));
            Assert.That((int)FbxPropertyFlags.EFlags.eUIBoolGroup, Is.EqualTo(131072));
            Assert.That((int)FbxPropertyFlags.EFlags.eUIExpanded, Is.EqualTo(262144));
            Assert.That((int)FbxPropertyFlags.EFlags.eUINoCaption, Is.EqualTo(524288));
            Assert.That((int)FbxPropertyFlags.EFlags.eUIPanel, Is.EqualTo(1048576));
            Assert.That((int)FbxPropertyFlags.EFlags.eUILeftLabel, Is.EqualTo(2097152));
            Assert.That((int)FbxPropertyFlags.EFlags.eUIHidden, Is.EqualTo(4194304));

            Assert.That((int)FbxPropertyFlags.EFlags.eCtrlFlags, Is.EqualTo(32767));

            Assert.That((int)FbxPropertyFlags.EFlags.eUIFlags, Is.EqualTo(8355840));

            Assert.That((int)FbxPropertyFlags.EFlags.eAllFlags, Is.EqualTo(8388607));

            Assert.That((int)FbxPropertyFlags.EFlags.eFlagCount, Is.EqualTo(23));
        }
    }
}
