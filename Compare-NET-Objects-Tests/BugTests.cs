using System;
using KellermanSoftware.CompareNetObjectsTests.Attributes;
using KellermanSoftware.CompareNetObjectsTests.TestClasses;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;
using System.Drawing;
using System.Linq;
using System.Drawing.Drawing2D;
using Point = System.Drawing.Point;

namespace KellermanSoftware.CompareNetObjectsTests
{
    [TestFixture]
    public class BugTests
    {
        #region Class Variables
        private CompareObjects _compare;
        #endregion

        #region Setup/Teardown

        /// <summary>
        /// Code that is run once for a suite of tests
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {

        }

        /// <summary>
        /// Code that is run once after a suite of tests has finished executing
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {

        }

        /// <summary>
        /// Code that is run before each test
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            _compare = new CompareObjects();
        }

        /// <summary>
        /// Code that is run after each test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            _compare = null;
        }
        #endregion

        #region Tests

        [Test]
        public void ComparerIgnoreOrderTest()
        {
            var elemA = new Element(1, 4);
            var elemB = Element.ReverseCopy(elemA);

            var comparer = new CompareObjects
            {
                IgnoreCollectionOrder = true,
            };

            comparer.Compare(elemA, elemB);
            Assert.IsTrue(comparer.Differences.Count == 0); //difference count should be 0 but 1 difference is found
        }


        [Test]
        public void ComparerIgnoreOrderSimpleArraysTest()
        {
            var a = new String[] { "A", "E", "F" };
            var b = new String[] { "A", "c", "d", "F" };

            var comparer = new CompareObjects
            {
                IgnoreCollectionOrder = true,
                MaxDifferences = int.MaxValue
            };

            comparer.Compare(a, b);
            Assert.IsTrue(comparer.Differences.Where(d => d.Object1Value == "E").Count() == 1);
            Assert.IsTrue(comparer.Differences.Where(d => d.Object2Value == "c").Count() == 1);
            Assert.IsTrue(comparer.Differences.Where(d => d.Object2Value == "d").Count() == 1);

        }

        [Test]
        public void EnumTypeShownTest()
        {
            Officer officer1 = new Officer();
            officer1.Name = "Greg";
            officer1.Type = Deck.Engineering;

            Officer officer2 = new Officer();
            officer2.Name = "John";
            officer2.Type = Deck.AstroPhysics;

            _compare.MaxDifferences = 2;
            if (!_compare.Compare(officer1, officer2))
            {
                Console.WriteLine(_compare.DifferencesString);
            }

            Assert.IsFalse(_compare.DifferencesString.Contains("Deck"));
        }

        [Test]
        public void TankElementsToIncludeTest()
        {
            _compare.MaxDifferences = 10;

            _compare.ElementsToInclude.Add("TankPerson");
            _compare.ElementsToInclude.Add("TankName");
            _compare.ElementsToInclude.Add("Name");
            _compare.ElementsToInclude.Add("FamilyName");
            _compare.ElementsToInclude.Add("GivenName");

            //Create a couple objects to compare
            TankPerson person1 = new TankPerson()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                Name = new TankName { FamilyName = "Huston", GivenName = "Greg" },
                Address = "Address1"
            };
            TankPerson person2 = new TankPerson()
            {
                Id = 2,
                Name = new TankName { FamilyName = "McClane", GivenName = "John" },
                DateCreated = DateTime.UtcNow,
                Address = "Address2"
            };

            Assert.IsFalse(_compare.Compare(person1, person2));

            //These will be different, write out the differences
            if (!_compare.Compare(person1, person2))
            {
                Console.WriteLine("------");

                Console.WriteLine("###################");
                _compare.Differences.ForEach(d => Console.WriteLine(d.ToString()));
            }

            _compare.ElementsToInclude.Clear();
            _compare.MaxDifferences = 1;
        }

        private Shipment CreateShipment()
        {
            return new Shipment { Customer = "ADEG", IdentCode = 12934871928374, InsertDate = new DateTime(2012, 06, 12) };
        }

        [Test]
        public void IgnoreByAttribute_test_should_fail_difference_should_be_customer()
        {
            // Arrange
            Shipment shipment1 = CreateShipment();
            Shipment shipment2 = CreateShipment();
            shipment2.InsertDate = DateTime.Now; // InsertDate has the CompareIgnoreAttribute on it
            shipment2.Customer = "Andritz";

            _compare.AttributesToIgnore.Add(typeof(CompareIgnoreAttribute));
            _compare.MaxDifferences = int.MaxValue;

            // Act
            var result = _compare.Compare(shipment1, shipment2);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(1, _compare.Differences.Count);
            Console.WriteLine(_compare.DifferencesString);
            Assert.AreEqual("ADEG", _compare.Differences[0].Object1Value);
            Assert.AreEqual("Andritz", _compare.Differences[0].Object2Value);

            _compare.AttributesToIgnore.Clear();
        }

        [Test]
        public void WilliamCWarnerTest()
        {
            ILabTest labTest = new LabTest();
            labTest.AlternateContainerDescription = "Test 1";
            labTest.TestName = "Test The Audit";

            ILabTest origLabLest = new LabTest();//this would be in session
            origLabLest.TestName = "Original Test Name";
            origLabLest.AlternateContainerDescription = "Test 2";

            _compare.MaxDifferences = 500;
            bool result = _compare.Compare(labTest, origLabLest);

            Assert.IsFalse(result);
            Assert.IsTrue(_compare.Differences.Count > 0);
            Console.WriteLine(_compare.DifferencesString);
        }

        [Test]
        public void LinearGradient()
        {
            LinearGradientBrush brush1 = new LinearGradientBrush(new Point(), new Point(0, 10), Color.Red, Color.Red);
            LinearGradientBrush brush2 = new LinearGradientBrush(new Point(), new Point(0, 10), Color.Red, Color.Blue);

            Assert.IsFalse(_compare.Compare(brush1, brush2));
        }

        #endregion
    }
}