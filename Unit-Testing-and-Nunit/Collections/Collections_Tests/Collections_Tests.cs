using Collections;
using NUnit.Framework;
using System;
using System.Linq;

namespace Collections_Tests
{
    public class CollectionTests
    {

        [Test]
        public void Test_EmptyConstructor()
        {
            var nums = new Collection<int>();

            Assert.That(nums.Count == 0);
            Assert.AreEqual(16, nums.Capacity);
            
        }

        [Test]
        [Timeout(1000)]
        public void Test_OneMillionItems()
        {
            int items = 1000000;
            Collection<int> collection = new Collection<int>();
            collection.AddRange(Enumerable.Range(0, items).ToArray());
            Assert.That(collection.Count, Is.EqualTo(items), "Test Collection count should be equal to 1000000");
            Assert.That(collection.Capacity, Is.GreaterThanOrEqualTo(items), "Test Collection capacity should be greater or equal to 1000000");
            collection.Clear();
            Assert.AreEqual(collection.ToString(), "[]");
            Assert.GreaterOrEqual(collection.Capacity, collection.Count);
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var nums = new Collection<int>(20);
            Assert.That(nums.ToString(), Is.EqualTo("[20]"));
            Assert.That(nums.Count == 1);
            Assert.AreEqual(1, nums.Count);
            Assert.That(nums[0] == 20);
            Assert.That(nums.Count > 0);
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var nums = new Collection<int>(10, 20, 30);
            Assert.That(nums.ToString(), Is.EqualTo("[10, 20, 30]"));
            Assert.That(nums.Count > 0);
            Assert.That(nums[0] == 10 || nums[1] == 20 || nums[2] == 30);     
        }
        [Test]
        public void Test_Clear()
        {
            var nums = new Collection<int>(10, 20, 30);
            nums.Clear();
            Assert.AreEqual(0, nums.Count);
        }

        [Test]
        public void Test_Collection_AddItem()
        {
            var nums = new Collection<int>();
            nums.Add(10);
            nums.Add(20);

            Assert.That(nums.ToString(), Is.EqualTo("[10, 20]"));

            nums.Add(30);

            Assert.That(nums[2] == 30);
        }
        [Test]
        public void Test_Collection_AddRange()
        {
            var nums = new Collection<int>(10, 20, 30);
            int[] newrange = new int[] { 1, 5, -3, 48, 0 };
            nums.AddRange(newrange);

            Assert.That(nums.ToString(), Is.EqualTo("[10, 20, 30, 1, 5, -3, 48, 0]"));
        }

        [Test]
        public void Test_AddRangeWithGrow()
        {
            var nums = new Collection<int>();
            int[] elements = new int[17];
            int oldLenght = nums.Capacity;
            nums.AddRange(elements);
            Assert.AreEqual(2 * oldLenght, nums.Capacity);
        }


        [Test]
        public void Test_Collection_GetByValidIndex()
        {
            var nums = new Collection<int>(10, 20, 30, 40, 50);
            int itemA = nums[2];
            int itemB = nums[4];

            Assert.That(itemA.ToString, Is.EqualTo("30"));
            Assert.That(itemB.ToString, Is.EqualTo("50"));
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var nums = new Collection<int>(10, 20, 30, 40, 50);

            Assert.That(() => { int num = nums[-1]; }, Throws.InstanceOf<System.ArgumentOutOfRangeException>());
            Assert.That(() => { int num = nums[10]; }, Throws.InstanceOf<System.ArgumentOutOfRangeException>());            
        }

        [Test]
        public void Test_Collection_ExchangeFirstLast()
        {
            var nums = new Collection<int>(10, 20, 30, 40, 50);
            nums.Exchange(0, 4);

            Assert.That(nums.ToString(), Is.EqualTo("[50, 20, 30, 40, 10]"));  
        }

        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            var nums = new Collection<int>(10, 20, 30, 40, 50);
            nums.Exchange(2, 3);

            Assert.That(nums.ToString(), Is.EqualTo("[10, 20, 40, 30, 50]"));
        }

        [Test]
        public void Test_Collection_ExchangeTwoInvalidItems()
        {
            var nums = new Collection<int>();
            nums.AddRange(1, 2, 3, 4, 5);
            Assert.Throws<ArgumentOutOfRangeException>
            (() => nums.Exchange(-1, 5));
        }

        [Test]
        public void Test_Collection_ExchangeOneInvalidItems()
        {
            var nums = new Collection<int> (1, 2, 3, 4, 5);
            Assert.Throws<ArgumentOutOfRangeException>
            (() => nums.Exchange(0, 5));
        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5);

            nums.InsertAt(5, 10);
            Assert.That(nums.ToString(), Is.EqualTo("[1, 2, 3, 4, 5, 10]"));
        }

        [Test]
        public void Test_InsertAtInvalidIndex()
        {
            Collection<string> collection = new Collection<string>(new string[] { "uno", "dos", "tres" });
            string element = "cuatro";
            int index = -1;
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => collection.InsertAt(index, element));
            Assert.IsTrue(exception.Message.Contains($"Parameter should be in the range [0...{collection.Count}]"));
        }

        [Test]
        public void Test_InsertAtMiddle()
        {
            Collection<string> collection = new Collection<string>(new string[] { "uno", "dos", "tres", "cuatro" });
            string element = "middle";
            collection.InsertAt(collection.Count / 2, element);
            Assert.AreEqual(element, collection[collection.Count / 2], "Test Collection element at middle should be equal to middle");
        }

        [Test]
        public void Test_InsertAtStart()
        {
            Collection<string> collection = new Collection<string>(new string[] { "uno", "dos", "tres", "cuatro" });
            string element = "zero";
            collection.InsertAt(0, element);
            Assert.AreEqual(element, collection[0], "Test Collection firstelement should be equal to zero");
        }

        [Test]
        public void Test_RemoveAtEnd()
        {
            Collection<string> collection = new Collection<string>(new string[] { "uno", "dos", "tres", "cuatro", });
            string lastElement = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count - 1);
            Assert.AreNotEqual(lastElement, collection[collection.Count - 1]);
        }

        [Test]
        public void Test_RemoveAtInvalidIndex()
        {
            Collection<string> collection = new Collection<string>(new string[] { "uno", "dos", "tres", "cuatro", });
            int index = -1;
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => collection.RemoveAt(index));
            Assert.IsTrue(exception.Message.Contains($"Parameter should be in the range [0...{collection.Count - 1}]"));
        }
        [Test]
        public void Test_RemoveAtMiddle()
        {
            Collection<string> collection = new Collection<string>(new string[] { "uno", "dos", "tres", });
            string middleElement = collection[collection.Count / 2];
            collection.RemoveAt(collection.Count / 2);
            Assert.IsFalse(middleElement == collection[collection.Count / 2]);

        }
        [Test]
        public void Test_RemoveAtStart()
        {
            Collection<string> collection = new Collection<string>(new string[] { "uno", "dos", "tres", });
            string firstElement = collection[0];
            collection.RemoveAt(0);
            Assert.IsFalse(firstElement == collection[0]);
        }

        [Test]
        public void TestRemoveAll()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5);
            nums.Clear();
            Assert.That(nums.ToString, Is.EqualTo("[]"));
        }

        [Test]
        public void Test_ToStringCollectionOfCollections()
        {
            Collection<string> firstCollection = new Collection<string>(new string[] { "tzatziki", "uzo", "fosalada" }); Collection<double> secondCollection = new Collection<double>(new double[] { 5.59, 4.41, 3.79 });
            Collection<object> thirdCollection = new Collection<object>(firstCollection, secondCollection);
            string thirdCollectionToString = thirdCollection.ToString();
            Assert.AreEqual("[[tzatziki, uzo, fosalada], [5.59, 4.41, 3.79]]", thirdCollectionToString);
        }
        [Test]
        public void Test_ToStringEmpty()
        {
            Collection<int> collection = new Collection<int>();
            string collectionToString = collection.ToString();
            Assert.AreEqual("[]", collectionToString);
        }
        [Test]
        public void Test_ToStringSingle()
        {
            Collection<int> collection = new Collection<int>(new int[] { 3256624 });
            string collectiontostring = collection.ToString();
            string expected = "[3256624]";
            Assert.AreEqual(expected, collectiontostring);
        }
    }
}