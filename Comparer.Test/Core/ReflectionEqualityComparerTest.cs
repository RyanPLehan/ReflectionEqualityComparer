using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comparer.Core.EqualityComparers;

namespace Comparer.Test.Core
{
    [TestClass]
    public class ReflectionEqualityComparerTest
    {
        private readonly IEqualityComparer<PrimitiveDataObject> PrimitiveEqualityComparer;

        public ReflectionEqualityComparerTest()
        {
            this.PrimitiveEqualityComparer = new ReflectionEqualityComparer<PrimitiveDataObject>();
        }

        [TestInitialize]
        public void Initialize()
        { }

        [TestCleanup]
        public void Cleanup()
        { }

        #region Equal - Fail
        // The following tests are designed to Fail by:
        // 1. Different value for the Non-Ignored properites of the same property name
        // 2. Retaining the same value for the Ignored Properties

        [TestMethod]
        public void PrimitiveDataObject_Equal_Fail_Id()
        {
            // Arrange Data
            Guid parentId = Guid.NewGuid();
            var x = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            var y = new PrimitiveDataObject()
            {
                Id = 2,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            // Act
            var areEqual = this.PrimitiveEqualityComparer.Equals(x, y);

            // Assert
            Assert.IsFalse(areEqual);
            Assert.IsFalse(x.Equals(y));
        }

        [TestMethod]
        public void PrimitiveDataObject_Equal_Fail_ParentId()
        {
            // Arrange Data
            Guid parentId = Guid.NewGuid();
            var x = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = Guid.NewGuid(),
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            var y = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = Guid.NewGuid(),
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            // Act
            var areEqual = this.PrimitiveEqualityComparer.Equals(x, y);

            // Assert
            Assert.IsFalse(areEqual);
            Assert.IsFalse(x.Equals(y));
        }

        [TestMethod]
        public void PrimitiveDataObject_Equal_Fail_StringValue()
        {
            // Arrange Data
            Guid parentId = Guid.NewGuid();
            var x = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            var y = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "abcdefghijklmnopqrstuvwxyz",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            // Act
            var areEqual = this.PrimitiveEqualityComparer.Equals(x, y);

            // Assert
            Assert.IsFalse(areEqual);
            Assert.IsFalse(x.Equals(y));
        }

        [TestMethod]
        public void PrimitiveDataObject_Equal_Fail_IntValue()
        {
            // Arrange Data
            Guid parentId = Guid.NewGuid();
            var x = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            var y = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 5,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            // Act
            var areEqual = this.PrimitiveEqualityComparer.Equals(x, y);

            // Assert
            Assert.IsFalse(areEqual);
            Assert.IsFalse(x.Equals(y));
        }

        [TestMethod]
        public void PrimitiveDataObject_Equal_Fail_BoolValue()
        {
            // Arrange Data
            Guid parentId = Guid.NewGuid();
            var x = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            var y = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = false,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            // Act
            var areEqual = this.PrimitiveEqualityComparer.Equals(x, y);

            // Assert
            Assert.IsFalse(areEqual);
            Assert.IsFalse(x.Equals(y));
        }

        [TestMethod]
        public void PrimitiveDataObject_Equal_Fail_DoubleValue()
        {
            // Arrange Data
            Guid parentId = Guid.NewGuid();
            var x = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            var y = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.1234567891,
                IgnoreDoubleValue = 0.123456789,
            };

            // Act
            var areEqual = this.PrimitiveEqualityComparer.Equals(x, y);

            // Assert
            Assert.IsFalse(areEqual);
            Assert.IsFalse(x.Equals(y));
        }
        #endregion

        #region Equal - Pass
        // The following tests are designed to Pass by:
        // 1. Retaining the same value for the Non-Ignored properites of the same property name
        // 2. Different values for the Ignored Properties

        [TestMethod]
        public void PrimitiveDataObject_Equal_Pass_Ids()
        {
            // Arrange Data
            Guid parentId = Guid.NewGuid();
            var x = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            var y = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            // Act
            var areEqual = this.PrimitiveEqualityComparer.Equals(x, y);

            // Assert
            Assert.IsTrue(areEqual);
            Assert.IsTrue(x.Equals(y));
        }

        [TestMethod]
        public void PrimitiveDataObject_Equal_Pass_StringValue()
        {
            // Arrange Data
            Guid parentId = Guid.NewGuid();
            var x = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            var y = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "abcdefghijklmnopqrstuvwxyz",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            // Act
            var areEqual = this.PrimitiveEqualityComparer.Equals(x, y);

            // Assert
            Assert.IsTrue(areEqual);
            Assert.IsTrue(x.Equals(y));
        }

        [TestMethod]
        public void PrimitiveDataObject_Equal_Pass_IntValue()
        {
            // Arrange Data
            Guid parentId = Guid.NewGuid();
            var x = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            var y = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 5,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            // Act
            var areEqual = this.PrimitiveEqualityComparer.Equals(x, y);

            // Assert
            Assert.IsTrue(areEqual);
            Assert.IsTrue(x.Equals(y));
        }

        [TestMethod]
        public void PrimitiveDataObject_Equal_Pass_BoolValue()
        {
            // Arrange Data
            Guid parentId = Guid.NewGuid();
            var x = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            var y = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = false,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            // Act
            var areEqual = this.PrimitiveEqualityComparer.Equals(x, y);

            // Assert
            Assert.IsTrue(areEqual);
            Assert.IsTrue(x.Equals(y));
        }

        [TestMethod]
        public void PrimitiveDataObject_Equal_Pass_DoubleValue()
        {
            // Arrange Data
            Guid parentId = Guid.NewGuid();
            var x = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            var y = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.987654321,
            };

            // Act
            var areEqual = this.PrimitiveEqualityComparer.Equals(x, y);

            // Assert
            Assert.IsTrue(areEqual);
            Assert.IsTrue(x.Equals(y));
        }
        #endregion

        #region HashCode = Fail
        // The following tests are designed to Fail by:
        // 1. Different value for the HashCode properites of the same property name
        // 2. Values of other non-HashCode propertes do not affect the outcome

        [TestMethod]
        public void PrimitiveDataObject_HashCode_Fail_Id()
        {
            // Arrange Data
            Guid parentId = Guid.NewGuid();
            var x = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            var y = new PrimitiveDataObject()
            {
                Id = 2,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            // Act
            var xHashCode = this.PrimitiveEqualityComparer.GetHashCode(x);
            var yHashCode = this.PrimitiveEqualityComparer.GetHashCode(y);

            // Assert
            Assert.AreNotEqual(xHashCode, yHashCode);
            Assert.AreNotEqual(x.GetHashCode(), y.GetHashCode());
        }

        [TestMethod]
        public void PrimitiveDataObject_HashCode_Fail_ParentId()
        {
            // Arrange Data
            Guid parentId = Guid.NewGuid();
            var x = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = Guid.NewGuid(),
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            var y = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = Guid.NewGuid(),
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            // Act
            var xHashCode = this.PrimitiveEqualityComparer.GetHashCode(x);
            var yHashCode = this.PrimitiveEqualityComparer.GetHashCode(y);

            // Assert
            Assert.AreNotEqual(xHashCode, yHashCode);
            Assert.AreNotEqual(x.GetHashCode(), y.GetHashCode());
        }
        #endregion

        #region HashCode = Pass
        // The following tests are designed to Pass by:
        // 1. Retaining the same value for the HashCode properites of the same property name
        // 2. Values of other non-HashCode propertes do not affect the outcome

        [TestMethod]
        public void PrimitiveDataObject_HashCode_Pass_Ids()
        {
            // Arrange Data
            Guid parentId = Guid.NewGuid();
            var x = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 2,
                IgnoreIntValue = 2,
                BoolValue = true,
                IgnoreBoolValue = true,
                DoubleValue = 0.123456789,
                IgnoreDoubleValue = 0.123456789,
            };

            var y = new PrimitiveDataObject()
            {
                Id = 1,
                ParentId = parentId,
                StringValue = "abcdefghijklmnopqrstuvwxyz",
                IgnoreStringValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                IntValue = 5,
                IgnoreIntValue = 2,
                BoolValue = false,
                IgnoreBoolValue = true,
                DoubleValue = 0.987654321,
                IgnoreDoubleValue = 0.123456789,
            };

            // Act
            var xHashCode = this.PrimitiveEqualityComparer.GetHashCode(x);
            var yHashCode = this.PrimitiveEqualityComparer.GetHashCode(y);

            // Assert
            Assert.AreEqual(xHashCode, yHashCode);
            Assert.AreEqual(x.GetHashCode(), y.GetHashCode());
        }
        #endregion


        #region Test Classes
        private class PrimitiveDataObject
        {
            [ReflectionEqualityComparer(UseForHashCode = true)]
            public int Id { get; set; }

            [ReflectionEqualityComparer(UseForHashCode = true)]
            public Guid ParentId { get; set; }

            public string StringValue { get; set; }

            [ReflectionEqualityComparer(Ignore = true)]
            public string IgnoreStringValue { get; set; }

            public int IntValue { get; set; }

            [ReflectionEqualityComparer(Ignore = true)]
            public int IgnoreIntValue { get; set; }

            public bool BoolValue { get; set; }

            [ReflectionEqualityComparer(Ignore = true)]
            public bool IgnoreBoolValue { get; set; }

            public double DoubleValue { get; set; }

            [ReflectionEqualityComparer(Ignore = true)]
            public double IgnoreDoubleValue { get; set; }


            // Another way to use the ReflectionEqualityComparer
            public override bool Equals(object obj)
            {
                bool ret = false;
                Type t = this.GetType();

                // verify the object being passed in is of the same type
                if (t == obj.GetType())
                {
                    var comparer = new ReflectionEqualityComparer<PrimitiveDataObject>();
                    ret = comparer.Equals(this, (PrimitiveDataObject)obj);
                }

                return ret;
            }

            public override int GetHashCode()
            { 
                var comparer = new ReflectionEqualityComparer<PrimitiveDataObject>();
                return comparer.GetHashCode(this);
            }

        }
        #endregion
    }
}
