# Data Structures Practice Guide

This directory contains comprehensive implementations of fundamental data structures with detailed comments and examples.

## 📁 Files Overview

### 1. **simpleQueue.py** - Simple Queue Implementation
- **Principle**: FIFO (First In First Out)
- **Key Operations**: enqueue, dequeue, peek, show
- **Pointers**: front (always 0), back (moves forward)
- **Use Case**: When you need elements processed in order of arrival

### 2. **circularQueue.py** - Circular Queue Implementation
- **Principle**: FIFO with circular memory reuse
- **Key Operations**: enqueue, dequeue, show with circular logic
- **Pointers**: front and rear (both move and wrap around)
- **Advantage**: Efficient memory usage, no shifting needed
- **Use Case**: When you need a fixed-size queue that reuses space

### 3. **doubleEndedQueue.py** - Double-Ended Queue (Deque)
- **Principle**: Insertion/deletion from both ends
- **Key Operations**: enqueue_front, enqueue_rear, dequeue_front, dequeue_rear
- **Flexibility**: Can act as stack (LIFO) or queue (FIFO)
- **Use Case**: When you need flexibility in insertion/deletion positions

### 4. **priorityQueue.py** - Priority Queue Implementation
- **Principle**: Elements ordered by priority (not insertion order)
- **Key Operations**: add_task, get_next_task, peek
- **Priority Rule**: Lower number = Higher priority (1 > 2 > 3)
- **Use Case**: Task scheduling, emergency systems, algorithm implementations

### 5. **linkedList.py** - Linked List Implementation
- **Principle**: Nodes connected by references
- **Key Operations**: insert, delete, search, reverse
- **Structure**: Each node has data + next pointer
- **Use Case**: Dynamic data, when you need frequent insertions/deletions

### 6. **stack.py** - Stack Implementation
- **Principle**: LIFO (Last In First Out)
- **Key Operations**: push, pop, peek
- **Structure**: Elements added/removed from same end (top)
- **Use Case**: Undo/Redo, browser history, function call stack

## 🔑 Key Concepts for Assessment

### **Queue Types Comparison**
| Type | Insertion | Deletion | Memory Usage | Use Case |
|------|-----------|----------|--------------|----------|
| Simple | O(1) | O(1) | Inefficient | Basic FIFO needs |
| Circular | O(1) | O(1) | Efficient | Fixed-size queues |
| Double-ended | O(1) | O(1) | Efficient | Flexible operations |
| Priority | O(log n) | O(log n) | Efficient | Priority-based processing |

### **Data Structure Principles**
- **FIFO**: First In First Out (Queues)
- **LIFO**: Last In First Out (Stacks)
- **Priority**: Based on importance, not order
- **Dynamic**: Size changes as needed (Linked Lists)

### **Common Operations & Time Complexity**
| Operation | Array | Linked List | Stack | Queue |
|-----------|-------|-------------|-------|-------|
| Access | O(1) | O(n) | O(1) | O(1) |
| Search | O(n) | O(n) | O(n) | O(n) |
| Insertion | O(n) | O(1) | O(1) | O(1) |
| Deletion | O(n) | O(1) | O(1) | O(1) |

## 📝 Assessment Preparation Tips

### **What They Might Ask:**

1. **Implementation Questions:**
   - Write enqueue/dequeue functions
   - Implement circular queue logic
   - Show how pointers work

2. **Concept Questions:**
   - Difference between queue types
   - When to use each data structure
   - Memory efficiency comparisons

3. **Code Analysis:**
   - Trace through operations
   - Identify bugs
   - Explain algorithms

4. **Practical Problems:**
   - Real-world applications
   - Performance analysis
   - Optimization scenarios

### **Key Points to Remember:**

- **Simple Queue**: front=0, back moves forward, inefficient memory
- **Circular Queue**: front and rear wrap around, efficient memory
- **Deque**: Can insert/delete from both ends
- **Priority Queue**: Orders by priority, not insertion time
- **Linked List**: Dynamic size, no random access
- **Stack**: LIFO, same end for add/remove

### **Common Mistakes to Avoid:**

1. **Circular Queue**: Forgetting modulo operation for wrapping
2. **Priority Queue**: Confusing priority order (1 > 2 > 3)
3. **Linked List**: Not handling edge cases (empty list, single node)
4. **Stack**: Trying to access middle elements
5. **Pointers**: Not updating pointers correctly after operations

## 🚀 Running the Examples

Each file can be run independently to see demonstrations:

```bash
python simpleQueue.py
python circularQueue.py
python doubleEndedQueue.py
python priorityQueue.py
python linkedList.py
python stack.py
```

## 📚 Additional Resources

- **Time Complexity**: Understand Big O notation
- **Memory Management**: How data structures use memory
- **Real Applications**: Where each structure is used in practice
- **Algorithm Integration**: How these structures are used in algorithms

## 🎯 Practice Exercises

1. **Modify existing implementations** to add new features
2. **Trace through operations** step by step
3. **Implement missing methods** (like search in queue)
4. **Compare performance** between different implementations
5. **Solve problems** using appropriate data structures

Good luck with your assessment! 🍀
