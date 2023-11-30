using Main.DataStructures;
using Xunit;

namespace MainTest.DataStructures
{
    public class LinkedListTests
    {
        [Theory]
        [InlineData(10)]
        public void AddItem_Count_ExpectCountEqual(int itemsCount)
        {
            // arrange
            var linkedList = new LinkedList<int>();
            
            // act
            for(int i = 0; i < itemsCount; i++) 
            {  
                linkedList.Add(i); 
            }

            // assert
            Assert.Equal(itemsCount, linkedList.Count);
        }

        [Fact]
        public void RemoveItem_Count_ExpectCountDecrease()
        {
            // arrange 
            var linkedList = new LinkedList<int>();
            linkedList.Add(0);
            linkedList.Add(1);
            linkedList.Add(2);

            // act
            linkedList.Remove(0);

            Assert.Equal(2, linkedList.Count);
        }

        [Fact]
        public void RemoveItem_Contains_ExpectNotContains()
        {
            // arrange 
            var linkedList = new LinkedList<int>();
            linkedList.Add(0);
            linkedList.Add(1);
            linkedList.Add(2);

            // act
            linkedList.Remove(0);

            Assert.False(linkedList.Contains(0));
        }

        [Fact]
        public void ClearList_Clear_CountEqualsZero()
        {
            var linkedList = new LinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);

            linkedList.Clear();

            Assert.Equal(0, linkedList.Count);
        }
    }
}
