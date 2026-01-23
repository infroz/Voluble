namespace Voluble.Unit.Should.BeEquivalentTo;

/// <summary>
/// Tests for Phase 9: Circular reference protection in BeEquivalentTo
/// </summary>
public class CircularReferenceTests
{
    #region Self-Referencing Objects

    private class SelfReferencingNode
    {
        public string Name { get; set; } = "";
        public SelfReferencingNode? Self { get; set; }
    }

    [Fact]
    public void SelfReferencingObject_DoesNotCauseInfiniteLoop()
    {
        var node = new SelfReferencingNode { Name = "Root" };
        node.Self = node; // Circular reference to self

        var expected = new SelfReferencingNode { Name = "Root" };
        expected.Self = expected;

        // Should not throw StackOverflowException or hang
        var ex = Record.Exception(() => node.Should().BeEquivalentTo(expected));

        Assert.Null(ex);
    }

    #endregion

    #region Parent-Child Circular References

    private class Parent
    {
        public string Name { get; set; } = "";
        public Child? Child { get; set; }
    }

    private class Child
    {
        public string Name { get; set; } = "";
        public Parent? Parent { get; set; }
    }

    [Fact]
    public void ParentChildCircularReference_DoesNotCauseInfiniteLoop()
    {
        var parent = new Parent { Name = "Parent" };
        var child = new Child { Name = "Child", Parent = parent };
        parent.Child = child;

        var expectedParent = new Parent { Name = "Parent" };
        var expectedChild = new Child { Name = "Child", Parent = expectedParent };
        expectedParent.Child = expectedChild;

        // Should not throw StackOverflowException or hang
        var ex = Record.Exception(() => parent.Should().BeEquivalentTo(expectedParent));

        Assert.Null(ex);
    }

    #endregion

    #region Linked List Circular References

    private class LinkedNode
    {
        public int Value { get; set; }
        public LinkedNode? Next { get; set; }
    }

    [Fact]
    public void CircularLinkedList_DoesNotCauseInfiniteLoop()
    {
        // Create a circular linked list: 1 -> 2 -> 3 -> 1 (back to start)
        var node1 = new LinkedNode { Value = 1 };
        var node2 = new LinkedNode { Value = 2 };
        var node3 = new LinkedNode { Value = 3 };
        node1.Next = node2;
        node2.Next = node3;
        node3.Next = node1; // Circular reference

        var expected1 = new LinkedNode { Value = 1 };
        var expected2 = new LinkedNode { Value = 2 };
        var expected3 = new LinkedNode { Value = 3 };
        expected1.Next = expected2;
        expected2.Next = expected3;
        expected3.Next = expected1; // Circular reference

        // Should not throw StackOverflowException or hang
        var ex = Record.Exception(() => node1.Should().BeEquivalentTo(expected1));

        Assert.Null(ex);
    }

    #endregion

    #region Graph with Multiple Circular References

    private class GraphNode
    {
        public string Id { get; set; } = "";
        public List<GraphNode> Neighbors { get; set; } = new();
    }

    [Fact]
    public void GraphWithMultipleCircularReferences_DoesNotCauseInfiniteLoop()
    {
        // Create a graph: A <-> B <-> C, A <-> C (triangle)
        var nodeA = new GraphNode { Id = "A" };
        var nodeB = new GraphNode { Id = "B" };
        var nodeC = new GraphNode { Id = "C" };

        nodeA.Neighbors.Add(nodeB);
        nodeA.Neighbors.Add(nodeC);
        nodeB.Neighbors.Add(nodeA);
        nodeB.Neighbors.Add(nodeC);
        nodeC.Neighbors.Add(nodeA);
        nodeC.Neighbors.Add(nodeB);

        var expectedA = new GraphNode { Id = "A" };
        var expectedB = new GraphNode { Id = "B" };
        var expectedC = new GraphNode { Id = "C" };

        expectedA.Neighbors.Add(expectedB);
        expectedA.Neighbors.Add(expectedC);
        expectedB.Neighbors.Add(expectedA);
        expectedB.Neighbors.Add(expectedC);
        expectedC.Neighbors.Add(expectedA);
        expectedC.Neighbors.Add(expectedB);

        // Should not throw StackOverflowException or hang
        var ex = Record.Exception(() => nodeA.Should().BeEquivalentTo(expectedA));

        Assert.Null(ex);
    }

    #endregion

    #region Deep Nesting without Circular References (should still work)

    private class DeepNested
    {
        public string Value { get; set; } = "";
        public DeepNested? Inner { get; set; }
    }

    [Fact]
    public void DeeplyNestedObject_WithoutCircularReference_Success()
    {
        // Create a deep nesting without circular references
        var actual = new DeepNested
        {
            Value = "Level1",
            Inner = new DeepNested
            {
                Value = "Level2",
                Inner = new DeepNested
                {
                    Value = "Level3",
                    Inner = null
                }
            }
        };

        var expected = new DeepNested
        {
            Value = "Level1",
            Inner = new DeepNested
            {
                Value = "Level2",
                Inner = new DeepNested
                {
                    Value = "Level3",
                    Inner = null
                }
            }
        };

        var ex = Record.Exception(() => actual.Should().BeEquivalentTo(expected));

        Assert.Null(ex);
    }

    #endregion
}
