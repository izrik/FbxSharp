using System;
using NUnit.Framework;
using FbxSharp;

namespace FbxSharpTests
{
    [TestFixture]
    public class FbxPropertyTest : TestBase
    {
        [Test]
        public void FbxProperty_Create_HasDefaults()
        {
            // given:
            var obj = new FbxObject("");
            var dt = FbxDataTypes.FbxIntDT;
            // when:
            var prop = FbxProperty.Create(obj, dt, "prop");
            // then:
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("prop"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("prop"));
            Assert.True(prop.GetParent().IsValid());
            Assert.False(prop.IsRoot());
            Assert.True(prop.GetParent().IsRoot());
            Assert.False(prop.GetChild().IsValid());
            Assert.False(prop.GetSibling().IsValid());
            Assert.False(prop.GetFirstDescendent().IsValid());
        }

        [Test]
        public void FbxProperty_Create_WithParentSetsParent()
        {
            // given:
            var obj = new FbxObject("");
            var dt = FbxDataTypes.FbxIntDT;
            var parent = FbxProperty.Create(obj, dt, "parent");
            // when:
            var prop = FbxProperty.Create(parent, dt, "prop");
            Assert.True(prop.IsValid());
            Assert.That(prop.GetName(), Is.EqualTo("prop"));
            Assert.That(prop.GetHierarchicalName(), Is.EqualTo("parent|prop"));
            Assert.True(prop.GetParent().IsValid());
            Assert.That(prop.GetParent().GetHierarchicalName(), Is.EqualTo("parent"));
            Assert.False(prop.IsRoot());
            Assert.False(prop.GetChild().IsValid());
            Assert.False(prop.GetSibling().IsValid());
            Assert.False(prop.GetFirstDescendent().IsValid());
            Assert.True(prop.IsChildOf(parent));
            Assert.True(prop.IsDescendentOf(parent));
            Assert.True(parent.GetChild().IsValid());
            Assert.That(parent.GetChild().GetHierarchicalName(), Is.EqualTo("parent|prop"));
            Assert.True(parent.GetFirstDescendent().IsValid());
            Assert.That(parent.GetFirstDescendent().GetHierarchicalName(), Is.EqualTo("parent|prop"));
        }

        [Test]
        public void FbxProperty_Find_FindsChildren()
        {
            // given:
            var obj = new FbxObject("");
            var dt = FbxDataTypes.FbxIntDT;
            var parent = FbxProperty.Create(obj, dt, "parent");
            var child = FbxProperty.Create(parent, dt, "child");

            // when:
            var prop = parent.Find("child");

            // then:
            Assert.True(prop.IsValid());
            Assert.True(prop == child);

            // when:
            prop = parent.Find("something else");

            // then:
            Assert.False(prop.IsValid());
        }

        [Test]
        public void FbxProperty_Find_DoesNotFindGrandchildren()
        {
            // given:
            var obj = new FbxObject("");
            var dt = FbxDataTypes.FbxIntDT;
            var parent = FbxProperty.Create(obj, dt, "parent");
            var child = FbxProperty.Create(parent, dt, "child");
            var grandchild = FbxProperty.Create(child, dt, "grandchild");

            // when:
            var prop = parent.Find("grandchild");

            // then:
            Assert.False(prop.IsValid());
        }

        [Test]
        public void FbxProperty_FindHierarchical_FindsDescendants()
        {
            // given:
            var obj = new FbxObject("");
            var dt = FbxDataTypes.FbxIntDT;
            var parent = FbxProperty.Create(obj, dt, "parent");
            var child = FbxProperty.Create(parent, dt, "child");
            var grandchild = FbxProperty.Create(child, dt, "grandchild");

            // when:
            var prop = parent.FindHierarchical("child");

            // then:
            Assert.True(prop.IsValid());
            Assert.True(prop == child);

            // when:
            prop = parent.FindHierarchical("child|grandchild");

            // then:
            Assert.True(prop.IsValid());
            Assert.True(prop == grandchild);

            // when:
            prop = parent.FindHierarchical("parent|child|grandchild");

            // then:
            Assert.False(prop.IsValid());

            // when:
            prop = parent.FindHierarchical("grandchild");

            // then:
            Assert.False(prop.IsValid());

            // when:
            prop = child.FindHierarchical("grandchild");

            // then:
            Assert.True(prop.IsValid());
            Assert.True(prop == grandchild);
        }
    }
}
