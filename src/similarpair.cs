using System;
using System.Collections.Generic;
using System.IO;

class StackElement
{
    public int Lable;
    public int CurrentChildIndex;
}

class CountTree
{
    public int LowerBound { get; private set; }
    public int UpperBound { get; private set; }
    public int Count { get; private set; }
    
    private CountTree LeftTree = null;
    private CountTree RightTree = null;
    
    public CountTree(int lowerBound, int upperBound)
    {
        LowerBound = lowerBound;
        UpperBound = upperBound;
        if (LowerBound < UpperBound)
        {
            LeftTree = new CountTree(LowerBound, (LowerBound + UpperBound) / 2);
            RightTree = new CountTree((LowerBound + UpperBound) / 2 + 1, UpperBound);
        }
    }
    
    public void Add(int number)
    {
        ++Count;
        if (LeftTree != null)
        {
            if (number <= LeftTree.UpperBound)
            {
                LeftTree.Add(number);
            }
            else
            {
                RightTree.Add(number);
            }
        }
    }
    
    public void Remove(int number)
    {
        --Count;
        if (LeftTree != null)
        {
            if (number <= LeftTree.UpperBound)
            {
                LeftTree.Remove(number);
            }
            else
            {
                RightTree.Remove(number);
            }
        }
    }
    
    public int GetCountLessThanOrEqualTo(int number)
    {
        if (number < LowerBound)
        {
            return 0;
        }
        if (number >= UpperBound)
        {
            return Count;
        }
        return LeftTree.GetCountLessThanOrEqualTo(number) + RightTree.GetCountLessThanOrEqualTo(number);
    }
}

class Solution {
    static void Main(String[] args) {
        string[] strs;
        strs = Console.ReadLine().Split(' ');
        var n = int.Parse(strs[0]);
        var t = int.Parse(strs[1]);
        var children = new List<int>[n + 1];
        var hasParent = new bool[n + 1];
        
        for (var i = 1; i < n; ++i)
        {
            strs = Console.ReadLine().Split(' ');
            var parent = int.Parse(strs[0]);
            var child = int.Parse(strs[1]);
            if (children[parent] == null)
            {
                children[parent] = new List<int>();
            }
            children[parent].Add(child);
            hasParent[child] = true;
        }
        
        int root = 0;
        for (var i = 1; i <= n; ++i)
        {
            if (!hasParent[i])
            {
                root = i;
                break;
            }
        }
        
        long result = 0;
        var visitedNodes = new CountTree(1, n);
        visitedNodes.Add(root);
        var stack = new Stack<StackElement>();
        stack.Push(new StackElement { Lable = root, CurrentChildIndex = 0 });
        
        while (stack.Count > 0)
        {
            var node = stack.Peek();
            var childrenCount = children[node.Lable] == null ? 0 : children[node.Lable].Count; 
            if (node.CurrentChildIndex >= childrenCount)
            {
                visitedNodes.Remove(node.Lable);
                stack.Pop();
            }
            else
            {
                var nextNode = children[node.Lable][node.CurrentChildIndex];
                var lower = nextNode - t;
                var upper = nextNode + t;
                result += visitedNodes.GetCountLessThanOrEqualTo(upper) - visitedNodes.GetCountLessThanOrEqualTo(lower - 1);
                ++node.CurrentChildIndex;
                visitedNodes.Add(nextNode);
                stack.Push(new StackElement { Lable = nextNode, CurrentChildIndex = 0 });
            }
        }
        
        Console.WriteLine(result);
    }
}