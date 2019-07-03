using CustomLinkedList.MyLinkedList;
using CustomLinkedList.Tests.Stubs;
using System;
using Xunit;

namespace CustomLinkedList.Tests
{
    public class MyDoubleLinkedListTests : IDisposable
    {
        public void Dispose()
        {
            MockNode<int>.counter = 0;
            MockNode<StubType>.counter = 0;
        }
        
        [Fact]
        public void AddBefore_should_throw_ArgumentNull_exception_if_null_supplied_instead_of_node()
        {
            var sut = new MyDoubleLinkedList<StubType,MockNode<StubType>>();

            Assert.Throws<ArgumentNullException>(() => { sut.AddBefore(null, new StubType()); });
        }

        [Fact]
        public void AddAfter_should_throw_ArgumentNull_exception_if_null_supplied_instead_of_node()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();

            Assert.Throws<ArgumentNullException>(() => { sut.AddAfter(null, new StubType()); });
        }
        [Fact]
        public void Find_should_return_first_value_found_if_multiple_values_are_provided()
        {
            var sut = new MyDoubleLinkedList<int, MockNode<int>>();
            int correctCreationValue = 2;

            sut.AddFirst(1);
            sut.AddFirst(0);
            sut.AddLast(0);

            var foundNode = sut.Find(0);
            int actualCreationValue = ((MockNode<int>)foundNode).creationValue;
            Assert.Equal(correctCreationValue, actualCreationValue);
        }
        [Fact]
        public void Find_should_return_last_value_found_if_multiple_values_are_provided()
        {
            var sut = new MyDoubleLinkedList<int, MockNode<int>>();
            int correctCreationValue = 3;

            sut.AddLast(0);
            sut.AddLast(1);
            sut.AddLast(0);

            var foundNode = sut.FindLast(0);
            int actualCreationValue = ((MockNode<int>)foundNode).creationValue;
            Assert.Equal(correctCreationValue, actualCreationValue);
        }

        [Fact]
        public void Find_should_return_null_if_value_is_not_found()
        {
            var sut = new MyDoubleLinkedList<int, MockNode<int>>();
            MockNode<int> expectedValue = null;
            sut.AddFirst(1);
            sut.AddFirst(2);
            var foundNode = sut.Find(0);
            Assert.Equal(expectedValue, foundNode);
        }
        [Fact]
        public void AddFirst_should_have_count_equal_3_if_3_values_are_added()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            int expectedCount = 3;

            sut.AddFirst(new StubType());
            sut.AddFirst(new StubType());
            sut.AddFirst(new StubType());

            Assert.Equal(expectedCount, sut.Count);
        }
        [Fact]
        public void AddLast_should_have_count_equal_3_if_3_values_are_added()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            int expectedCount = 3;

            sut.AddLast(new StubType());
            sut.AddLast(new StubType());
            sut.AddLast(new StubType());

            Assert.Equal(expectedCount, sut.Count);
        }
        [Fact]
        public void AddFirst_should_have_latest_added_element_as_first_if_elements_are_added()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            int expectedCreationValue = 2;

            sut.AddFirst(new StubType());
            sut.AddFirst(new StubType());

            int actualCreationValue = ((MockNode<StubType>)sut.First).creationValue;
            Assert.Equal(expectedCreationValue, actualCreationValue);
        }
        [Fact]
        public void AddLast_should_have_latest_added_element_as_last_if_elements_are_added()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            int expectedCreationValue = 2;

            sut.AddLast(new StubType());
            sut.AddLast(new StubType());

            int actualCreationValue = ((MockNode<StubType>)sut.Last).creationValue;
            Assert.Equal(expectedCreationValue, actualCreationValue);
        }
        [Fact]
        public void AddAfter_should_add_element_after_first_when_first_element_is_supplied()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            int expectedCreationValue = 3;

            sut.AddFirst(new StubType());
            sut.AddFirst(new StubType());
            sut.AddAfter(sut.First, new StubType());

            int actualCreationValue = ((MockNode<StubType>)sut.First.Next).creationValue;
            Assert.Equal(expectedCreationValue, actualCreationValue);
        }
        [Fact]
        public void AddAfter_element_should_become_last_if_last_node_is_supplied()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            int expectedCreationValue = 3;

            sut.AddFirst(new StubType());
            sut.AddFirst(new StubType());
            sut.AddAfter(sut.Last, new StubType());

            int actualCreationValue = ((MockNode<StubType>)sut.Last).creationValue;
            Assert.Equal(expectedCreationValue, actualCreationValue);
        }
        [Fact]
        public void AddBefore_should_add_element_before_last_when_last_element_is_supplied()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            int expectedCreationValue = 3;

            sut.AddFirst(new StubType());
            sut.AddFirst(new StubType());
            sut.AddBefore(sut.Last, new StubType());

            int actualCreationValue = ((MockNode<StubType>)sut.Last.Previous).creationValue;
            Assert.Equal(expectedCreationValue, actualCreationValue);
        }
        [Fact]
        public void AddBefore_element_should_become_first_if_first_node_is_supplied()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            int expectedCreationValue = 3;

            sut.AddFirst(new StubType());
            sut.AddFirst(new StubType());
            sut.AddBefore(sut.First, new StubType());
            int actualCreationValue = ((MockNode<StubType>)sut.First).creationValue;

            Assert.Equal(expectedCreationValue, actualCreationValue);
        }
        [Fact]
        public void Remove_should_have_count_1_if_existing_element_is_removed_from_list_with_2_elements()
        {
            var sut = new MyDoubleLinkedList<int, MockNode<int>>();
            int expectedCount = 1;

            sut.AddLast(0);
            sut.AddLast(0);

            sut.Remove(0);
            int actualCount = sut.Count;

            Assert.Equal(expectedCount, actualCount);
        }
        [Fact]
        public void Remove_should_have_count_2_if_not_existing_element_is_removed_from_list_with_2_elements()
        {
            var sut = new MyDoubleLinkedList<int, MockNode<int>>();
            int expectedCount = 2;

            sut.AddLast(0);
            sut.AddLast(0);

            sut.Remove(1);
            int actualCount = sut.Count;

            Assert.Equal(expectedCount, actualCount);
        }
        [Fact]
        public void Clear_should_have_count_0_if_reset_is_used_on_list_with_1_element()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            int expectedCount = 0;

            sut.AddFirst(new StubType());
            sut.Clear();
            int actualCount = sut.Count;

            Assert.Equal(expectedCount, actualCount);
        }
        [Fact]
        public void Clear_should_have_first_null_if_reset_is_used_on_list_with_1_element()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            MockNode<StubType> expectedValue = null;

            sut.AddFirst(new StubType());
            sut.Clear();

            Assert.Equal(expectedValue, sut.First);
        }
        [Fact]
        public void Clear_should_have_last_null_if_reset_is_used_on_list_with_1_element()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            MockNode<StubType> expectedValue = null;

            sut.AddFirst(new StubType());
            sut.Clear();

            Assert.Equal(expectedValue, sut.Last);
        }
        [Fact]
        public void removeFirst_should_have_count_equal_to_2_if_first_element_list_with_3_entries_is_removed()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            int expectedCount = 2;

            sut.AddFirst(new StubType());
            sut.AddFirst(new StubType());
            sut.AddFirst(new StubType());
            sut.RemoveFirst();

            Assert.Equal(expectedCount, sut.Count);
        }
        [Fact]
        public void removeFirst_should_have_second_element_as_first_if_first_element_is_removed_from_list_of_3_elements()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            int expectedCreationValue = 2;

            sut.AddLast(new StubType());
            sut.AddLast(new StubType());
            sut.AddLast(new StubType());
            sut.RemoveFirst();
            int actualCreationValue = ((MockNode<StubType>)sut.First).creationValue;

            Assert.Equal(expectedCreationValue, actualCreationValue);
        }
        [Fact]
        public void removeLast_should_have_count_equal_to_2_if_last_element_list_with_3_entries_is_removed()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            int expectedCount = 2;

            sut.AddFirst(new StubType());
            sut.AddFirst(new StubType());
            sut.AddFirst(new StubType());
            sut.RemoveLast();

            Assert.Equal(expectedCount, sut.Count);
        }
        [Fact]
        public void removeFirst_should_have_second_element_as_Last_if_Last_element_is_removed_from_list_of_3_elements()
        {
            var sut = new MyDoubleLinkedList<StubType, MockNode<StubType>>();
            int expectedCreationValue = 2;

            sut.AddLast(new StubType());
            sut.AddLast(new StubType());
            sut.AddLast(new StubType());
            sut.RemoveLast();
            int actualCreationValue = ((MockNode<StubType>)sut.Last).creationValue;

            Assert.Equal(expectedCreationValue, actualCreationValue);
        }
    }
}
