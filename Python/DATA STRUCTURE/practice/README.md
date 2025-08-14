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

# DSA Assessment MCQs

## Python Basics (20 MCQs)

1. Which Python data type is mutable and ordered?
   - A) tuple
   - B) list
   - C) frozenset
   - D) str
   **Answer: B**

2. Python list `append()` method adds element at:
   - A) beginning
   - B) middle
   - C) end
   - D) random position
   **Answer: C**

3. Python list `insert(i, x)` method:
   - A) replaces element at index i
   - B) inserts x before index i
   - C) inserts x at index i
   - D) removes element at index i
   **Answer: C**

4. Python list `pop()` method without arguments:
   - A) removes first element
   - B) removes last element
   - C) removes random element
   - D) removes middle element
   **Answer: B**

5. Python list `remove(x)` method:
   - A) removes element at index x
   - B) removes first occurrence of value x
   - C) removes all occurrences of x
   - D) removes last occurrence of x
   **Answer: B**

6. Python list `extend()` method:
   - A) adds single element
   - B) adds multiple elements from iterable
   - C) replaces all elements
   - D) sorts the list
   **Answer: B**

7. Python list `clear()` method:
   - A) removes all elements
   - B) sets all elements to None
   - C) reverses the list
   - D) sorts the list
   **Answer: A**

8. Python list `reverse()` method:
   - A) returns reversed copy
   - B) reverses list in-place
   - C) sorts in reverse order
   - D) removes reverse elements
   **Answer: B**

9. Python list `sort()` method:
   - A) returns sorted copy
   - B) sorts list in-place
   - C) only works with numbers
   - D) requires key function
   **Answer: B**

10. Python list `count(x)` method:
    - A) returns index of x
    - B) returns number of occurrences of x
    - C) returns length of list
    - D) returns sum of elements
    **Answer: B**

11. Python list `index(x)` method:
    - A) returns first occurrence index of x
    - B) returns all indices of x
    - C) returns last occurrence index of x
    - D) returns random index of x
    **Answer: A**

12. Python list `len()` function:
    - A) returns number of elements
    - B) returns sum of elements
    - C) returns average of elements
    - D) returns maximum element
    **Answer: A**

13. Python list slicing `list[start:end:step]`:
    - A) always includes end index
    - B) excludes end index
    - C) includes both start and end
    - D) depends on step value
    **Answer: B**

14. Python list `max()` function:
    - A) returns largest element
    - B) returns index of largest element
    - C) returns sum of all elements
    - D) returns length of list
    **Answer: A**

15. Python list `min()` function:
    - A) returns smallest element
    - B) returns index of smallest element
    - C) returns average of elements
    - D) returns first element
    **Answer: A**

16. Python list `sum()` function:
    - A) works only with numbers
    - B) works with any data type
    - C) concatenates strings
    - D) multiplies elements
    **Answer: A**

17. Python list `in` operator:
    - A) checks if element exists
    - B) adds element to list
    - C) removes element from list
    - D) sorts the list
    **Answer: A**

18. Python list `not in` operator:
    - A) checks if element doesn't exist
    - B) adds element to list
    - C) removes element from list
    - D) reverses the list
    **Answer: A**

19. Python list `+` operator:
    - A) adds elements
    - B) concatenates lists
    - C) multiplies lists
    - D) divides lists
    **Answer: B**

20. Python list `*` operator:
    - A) multiplies elements
    - B) repeats list
    - C) concatenates lists
    - D) divides lists
    **Answer: B**

## Lists (20 MCQs)

21. Python list is:
    - A) immutable
    - B) mutable
    - C) partially mutable
    - D) depends on elements
    **Answer: B**

22. Python list can contain:
    - A) only numbers
    - B) only strings
    - C) mixed data types
    - D) only same data types
    **Answer: C**

23. Python list `del` statement:
    - A) removes element at index
    - B) removes element by value
    - C) clears entire list
    - D) all of above
    **Answer: D**

24. Python list `copy()` method:
    - A) creates shallow copy
    - B) creates deep copy
    - C) creates reference
    - D) creates empty list
    **Answer: A**

25. Python list `deepcopy()` from copy module:
    - A) creates shallow copy
    - B) creates deep copy
    - C) creates reference
    - D) creates empty list
    **Answer: B**

26. Python list `list()` constructor:
    - A) creates empty list
    - B) converts iterable to list
    - C) both A and B
    - D) creates list with default values
    **Answer: C**

27. Python list `range()` function:
    - A) creates list directly
    - B) creates range object
    - C) creates tuple
    - D) creates set
    **Answer: B**

28. Python list `enumerate()` function:
    - A) returns index-value pairs
    - B) returns only indices
    - C) returns only values
    - D) returns length
    **Answer: A**

29. Python list `zip()` function:
    - A) combines multiple lists
    - B) separates list elements
    - C) sorts list
    - D) reverses list
    **Answer: A**

30. Python list `filter()` function:
    - A) removes elements
    - B) keeps elements based on condition
    - C) sorts elements
    - D) reverses elements
    **Answer: B**

31. Python list `map()` function:
    - A) applies function to each element
    - B) maps indices to values
    - C) creates dictionary
    - D) sorts elements
    **Answer: A**

32. Python list `reduce()` function:
    - A) reduces list to single value
    - B) removes elements
    - C) sorts elements
    - D) reverses elements
    **Answer: A**

33. Python list `any()` function:
    - A) returns True if any element is True
    - B) returns True if all elements are True
    - C) returns sum of elements
    - D) returns length
    **Answer: A**

34. Python list `all()` function:
    - A) returns True if any element is True
    - B) returns True if all elements are True
    - C) returns sum of elements
    - D) returns length
    **Answer: B**

35. Python list `sorted()` function:
    - A) sorts in-place
    - B) returns sorted copy
    - C) reverses list
    - D) removes duplicates
    **Answer: B**

36. Python list `reversed()` function:
    - A) reverses in-place
    - B) returns reversed copy
    - C) sorts in reverse
    - D) removes elements
    **Answer: B**

37. Python list `set()` conversion:
    - A) removes duplicates
    - B) sorts elements
    - C) reverses elements
    - D) adds elements
    **Answer: A**

38. Python list `tuple()` conversion:
    - A) makes list immutable
    - B) sorts elements
    - C) reverses elements
    - D) removes elements
    **Answer: A**

39. Python list `str.join()` method:
    - A) joins list elements with separator
    - B) splits string into list
    - C) sorts list
    - D) reverses list
    **Answer: A**

40. Python list `str.split()` method:
    - A) joins list elements
    - B) splits string into list
    - C) sorts list
    - D) reverses list
    **Answer: B**

## Linked List (20 MCQs)

41. A node in singly linked list contains:
    - A) only data
    - B) data and next pointer
    - C) data and two pointers
    - D) only pointers
    **Answer: B**

42. Last node in singly linked list points to:
    - A) first node
    - B) itself
    - C) None/null
    - D) random node
    **Answer: C**

43. To insert at beginning of linked list:
    - A) update head pointer
    - B) update tail pointer
    - C) update middle node
    - D) no change needed
    **Answer: A**

44. To delete first node in linked list:
    - A) update head pointer
    - B) update tail pointer
    - C) update middle node
    - D) no change needed
    **Answer: A**

45. To insert at end of linked list:
    - A) update head pointer
    - B) update tail pointer
    - C) update middle node
    - D) traverse to end
    **Answer: D**

46. To delete last node in linked list:
    - A) update head pointer
    - B) update tail pointer
    - C) find second last node
    - D) no change needed
    **Answer: C**

47. To insert after a given node:
    - A) update next pointers
    - B) update data only
    - C) update head pointer
    - D) update tail pointer
    **Answer: A**

48. To delete a node after given node:
    - A) update next pointers
    - B) update data only
    - C) update head pointer
    - D) update tail pointer
    **Answer: A**

49. To find length of linked list:
    - A) count nodes while traversing
    - B) use built-in length function
    - C) check head pointer
    - D) check tail pointer
    **Answer: A**

50. To search element in linked list:
    - A) traverse and compare
    - B) use index
    - C) use hash table
    - D) use binary search
    **Answer: A**

51. To reverse linked list:
    - A) update data values
    - B) update next pointers
    - C) update head pointer
    - D) update tail pointer
    **Answer: B**

52. To detect cycle in linked list:
    - A) Floyd's cycle detection
    - B) count nodes
    - C) check head pointer
    - D) check tail pointer
    **Answer: A**

53. To find middle of linked list:
    - A) count total nodes
    - B) use two pointers (fast/slow)
    - C) use tail pointer
    - D) use head pointer
    **Answer: B**

54. To remove duplicates from linked list:
    - A) use hash set
    - B) sort first
    - C) reverse first
    - D) no method exists
    **Answer: A**

55. To check if linked list is palindrome:
    - A) reverse and compare
    - B) use stack
    - C) use two pointers
    - D) all of above
    **Answer: D**

56. To merge two sorted linked lists:
    - A) compare and link
    - B) concatenate and sort
    - C) reverse both first
    - D) no method exists
    **Answer: A**

57. To add two numbers represented by linked lists:
    - A) convert to numbers first
    - B) add digit by digit
    - C) reverse both first
    - D) no method exists
    **Answer: B**

58. To remove nth node from end:
    - A) use two pointers
    - B) count total nodes
    - C) use hash table
    - D) no method exists
    **Answer: A**

59. To swap nodes in linked list:
    - A) swap data only
    - B) swap next pointers
    - C) both A and B
    - D) no method exists
    **Answer: C**

60. To sort linked list:
    - A) use merge sort
    - B) use quick sort
    - C) use bubble sort
    - D) all of above
    **Answer: D**

## Stack (20 MCQs)

61. Stack follows which principle?
    - A) FIFO (First In First Out)
    - B) LIFO (Last In First Out)
    - C) Random access
    - D) Priority based
    **Answer: B**

62. Main operations in stack are:
    - A) push and pop
    - B) enqueue and dequeue
    - C) insert and delete
    - D) add and remove
    **Answer: A**

63. `push()` operation in stack:
    - A) removes top element
    - B) adds element to top
    - C) views top element
    - D) clears stack
    **Answer: B**

64. `pop()` operation in stack:
    - A) removes top element
    - B) adds element to top
    - C) views top element
    - D) clears stack
    **Answer: A**

65. `peek()` or `top()` operation:
    - A) removes top element
    - B) adds element to top
    - C) views top element
    - D) clears stack
    **Answer: C**

66. `isEmpty()` operation checks:
    - A) if stack is full
    - B) if stack is empty
    - C) if stack has one element
    - D) if stack is balanced
    **Answer: B**

67. `isFull()` operation checks:
    - A) if stack is full
    - B) if stack is empty
    - C) if stack has one element
    - D) if stack is balanced
    **Answer: A**

68. Stack underflow occurs when:
    - A) popping from empty stack
    - B) pushing to full stack
    - C) peeking empty stack
    - D) clearing empty stack
    **Answer: A**

69. Stack overflow occurs when:
    - A) popping from empty stack
    - B) pushing to full stack
    - C) peeking empty stack
    - D) clearing empty stack
    **Answer: B**

70. Stack can be implemented using:
    - A) array only
    - B) linked list only
    - C) both array and linked list
    - D) tree only
    **Answer: C**

71. In array-based stack, top pointer:
    - A) points to next empty position
    - B) points to top element
    - C) points to bottom element
    - D) points to middle element
    **Answer: B**

72. In linked list-based stack:
    - A) head is top of stack
    - B) tail is top of stack
    - C) middle node is top
    - D) random node is top
    **Answer: A**

73. Stack applications include:
    - A) function call management
    - B) expression evaluation
    - C) backtracking
    - D) all of above
    **Answer: D**

74. For balanced parentheses checking:
    - A) use queue
    - B) use stack
    - C) use linked list
    - D) use tree
    **Answer: B**

75. For infix to postfix conversion:
    - A) use queue
    - B) use stack
    - C) use linked list
    - D) use tree
    **Answer: B**

76. For undo/redo functionality:
    - A) use single stack
    - B) use two stacks
    - C) use queue
    - D) use linked list
    **Answer: B**

77. For depth-first search (DFS):
    - A) use queue
    - B) use stack
    - C) use linked list
    - D) use tree
    **Answer: B**

78. For tower of Hanoi problem:
    - A) use queue
    - B) use stack
    - C) use linked list
    - D) use tree
    **Answer: B**

79. Stack size can be:
    - A) fixed only
    - B) dynamic only
    - C) both fixed and dynamic
    - D) infinite only
    **Answer: C**

80. To reverse a string using stack:
    - A) push characters then pop
    - B) push characters then peek
    - C) pop characters then push
    - D) no method exists
    **Answer: A**

## Queue (20 MCQs)

81. Queue follows which principle?
    - A) FIFO (First In First Out)
    - B) LIFO (Last In First Out)
    - C) Random access
    - D) Priority based
    **Answer: A**

82. Main operations in queue are:
    - A) push and pop
    - B) enqueue and dequeue
    - C) insert and delete
    - D) add and remove
    **Answer: B**

83. `enqueue()` operation in queue:
    - A) removes front element
    - B) adds element to rear
    - C) views front element
    - D) clears queue
    **Answer: B**

84. `dequeue()` operation in queue:
    - A) removes front element
    - B) adds element to rear
    - C) views front element
    - D) clears queue
    **Answer: A**

85. `front()` or `peek()` operation:
    - A) removes front element
    - B) adds element to rear
    - C) views front element
    - D) clears queue
    **Answer: C**

86. `rear()` operation:
    - A) removes rear element
    - B) adds element to rear
    - C) views rear element
    - D) clears queue
    **Answer: C**

87. `isEmpty()` operation checks:
    - A) if queue is full
    - B) if queue is empty
    - C) if queue has one element
    - D) if queue is balanced
    **Answer: B**

88. `isFull()` operation checks:
    - A) if queue is full
    - B) if queue is empty
    - C) if queue has one element
    - D) if queue is balanced
    **Answer: A**

89. Queue underflow occurs when:
    - A) dequeuing from empty queue
    - B) enqueuing to full queue
    - C) peeking empty queue
    - D) clearing empty queue
    **Answer: A**

90. Queue overflow occurs when:
    - A) dequeuing from empty queue
    - B) enqueuing to full queue
    - C) peeking empty queue
    - D) clearing empty queue
    **Answer: B**

91. Queue can be implemented using:
    - A) array only
    - B) linked list only
    - C) both array and linked list
    - D) tree only
    **Answer: C**

92. In array-based queue, front pointer:
    - A) points to next empty position
    - B) points to front element
    - C) points to rear element
    - D) points to middle element
    **Answer: B**

93. In linked list-based queue:
    - A) head is front of queue
    - B) tail is front of queue
    - C) middle node is front
    - D) random node is front
    **Answer: A**

94. Queue applications include:
    - A) CPU scheduling
    - B) breadth-first search
    - C) printer spooling
    - D) all of above
    **Answer: D**

95. For breadth-first search (BFS):
    - A) use stack
    - B) use queue
    - C) use linked list
    - D) use tree
    **Answer: B**

96. For CPU task scheduling:
    - A) use stack
    - B) use queue
    - C) use linked list
    - D) use tree
    **Answer: B**

97. For printer spooling:
    - A) use stack
    - B) use queue
    - C) use linked list
    - D) use tree
    **Answer: B**

98. Queue size can be:
    - A) fixed only
    - B) dynamic only
    - C) both fixed and dynamic
    - D) infinite only
    **Answer: C**

99. To reverse a queue:
    - A) use another queue
    - B) use stack
    - C) use linked list
    - D) no method exists
    **Answer: B**

100. To implement queue using two stacks:
    - A) one stack for enqueue, one for dequeue
    - B) both stacks for enqueue
    - C) both stacks for dequeue
    - D) no method exists
    **Answer: A**

## Circular Queue (20 MCQs)

101. Circular queue is used to:
    - A) avoid memory wastage
    - B) make queue faster
    - C) make queue smaller
    - D) make queue circular
    **Answer: A**

102. In circular queue, when rear reaches end:
    - A) queue is full
    - B) rear wraps to beginning
    - C) front moves to end
    - D) queue stops working
    **Answer: B**

103. In circular queue, when front reaches end:
    - A) queue is empty
    - B) front wraps to beginning
    - C) rear moves to end
    - D) queue stops working
    **Answer: B**

104. Circular queue full condition:
    - A) front == rear
    - B) (rear + 1) % N == front
    - C) rear == N-1
    - D) front == 0
    **Answer: B**

105. Circular queue empty condition:
    - A) front == rear
    - B) (rear + 1) % N == front
    - C) rear == N-1
    - D) front == 0
    **Answer: A**

106. In circular queue, to move rear forward:
    - A) rear = rear + 1
    - B) rear = (rear + 1) % N
    - C) rear = rear - 1
    - D) rear = N
    **Answer: B**

107. In circular queue, to move front forward:
    - A) front = front + 1
    - B) front = (front + 1) % N
    - C) front = front - 1
    - D) front = N
    **Answer: B**

108. Circular queue size calculation:
    - A) (rear - front + N) % N
    - B) rear - front
    - C) front - rear
    - D) N - (rear - front)
    **Answer: A**

109. Circular queue with count variable:
    - A) full when count == N
    - B) empty when count == 0
    - C) both A and B
    - D) neither A nor B
    **Answer: C**

110. Circular queue without count variable:
    - A) needs special handling for full/empty
    - B) always leaves one space empty
    - C) both A and B
    - D) neither A nor B
    **Answer: C**

111. Circular queue initialization:
    - A) front = rear = 0
    - B) front = rear = -1
    - C) front = 0, rear = -1
    - D) all of above
    **Answer: D**

112. Circular queue after removing last element:
    - A) front = rear = 0
    - B) front = rear = -1
    - C) front = 0, rear = -1
    - D) front = -1, rear = 0
    **Answer: B**

113. Circular queue advantage over linear queue:
    - A) faster operations
    - B) reuses freed space
    - C) smaller memory usage
    - D) easier implementation
    **Answer: B**

114. Circular queue disadvantage:
    - A) complex implementation
    - B) slower operations
    - C) more memory usage
    - D) limited size
    **Answer: A**

115. Circular queue using array:
    - A) fixed size only
    - B) dynamic size only
    - C) both fixed and dynamic
    - D) infinite size
    **Answer: A**

116. Circular queue using linked list:
    - A) fixed size only
    - B) dynamic size only
    - C) both fixed and dynamic
    - D) infinite size
    **Answer: C**

117. Circular queue applications:
    - A) CPU scheduling
    - B) memory management
    - C) traffic control
    - D) all of above
    **Answer: D**

118. Circular queue in traffic light system:
    - A) manages vehicle queue
    - B) controls light timing
    - C) both A and B
    - D) neither A nor B
    **Answer: A**

119. Circular queue in memory buffer:
    - A) stores data circularly
    - B) prevents overflow
    - C) both A and B
    - D) neither A nor B
    **Answer: C**

120. Circular queue vs simple queue:
    - A) circular is always better
    - B) simple is always better
    - C) depends on use case
    - D) both are same
    **Answer: C**

## Double Ended Queue (Deque) (20 MCQs)

121. Deque stands for:
    - A) Double Ended Queue
    - B) Data Entry Queue
    - C) Dynamic Entry Queue
    - D) Direct Entry Queue
    **Answer: A**

122. Deque allows insertion/deletion at:
    - A) front only
    - B) rear only
    - C) both front and rear
    - D) middle only
    **Answer: C**

123. Deque operations include:
    - A) insertFront, insertRear
    - B) deleteFront, deleteRear
    - C) both A and B
    - D) neither A nor B
    **Answer: C**

124. Deque can be used as:
    - A) stack only
    - B) queue only
    - C) both stack and queue
    - D) neither stack nor queue
    **Answer: C**

125. Deque as stack (LIFO):
    - A) use front operations only
    - B) use rear operations only
    - C) use both front and rear
    - D) use middle operations
    **Answer: A**

126. Deque as queue (FIFO):
    - A) insert at front, delete from rear
    - B) insert at rear, delete from front
    - C) insert at middle, delete from end
    - D) insert at end, delete from middle
    **Answer: B**

127. Deque can be implemented using:
    - A) array only
    - B) linked list only
    - C) both array and linked list
    - D) tree only
    **Answer: C**

128. Deque using doubly linked list:
    - A) each node has two pointers
    - B) each node has one pointer
    - C) each node has three pointers
    - D) no pointers needed
    **Answer: A**

129. Deque using circular array:
    - A) front and rear can wrap around
    - B) only front can wrap around
    - C) only rear can wrap around
    - D) no wrapping allowed
    **Answer: A**

130. Deque `insertFront(x)` operation:
    - A) adds x at front
    - B) adds x at rear
    - C) adds x at middle
    - D) removes x from front
    **Answer: A**

131. Deque `insertRear(x)` operation:
    - A) adds x at front
    - B) adds x at rear
    - C) adds x at middle
    - D) removes x from rear
    **Answer: B**

132. Deque `deleteFront()` operation:
    - A) removes front element
    - B) removes rear element
    - C) removes middle element
    - D) adds element at front
    **Answer: A**

133. Deque `deleteRear()` operation:
    - A) removes front element
    - B) removes rear element
    - C) removes middle element
    - D) adds element at rear
    **Answer: B**

134. Deque `getFront()` operation:
    - A) returns front element
    - B) returns rear element
    - C) returns middle element
    - D) returns size
    **Answer: A**

135. Deque `getRear()` operation:
    - A) returns front element
    - B) returns rear element
    - C) returns middle element
    - D) returns size
    **Answer: B**

136. Deque `isEmpty()` operation:
    - A) checks if empty
    - B) checks if full
    - C) checks size
    - D) checks capacity
    **Answer: A**

137. Deque `isFull()` operation:
    - A) checks if empty
    - B) checks if full
    - C) checks size
    - D) checks capacity
    **Answer: B**

138. Deque applications:
    - A) undo/redo systems
    - B) browser history
    - C) sliding window problems
    - D) all of above
    **Answer: D**

139. Deque in browser history:
    - A) stores visited pages
    - B) allows back/forward navigation
    - C) both A and B
    - D) neither A nor B
    **Answer: C**

140. Deque vs simple queue:
    - A) deque is always better
    - B) simple queue is always better
    - C) depends on requirements
    - D) both are same
    **Answer: C**

## Priority Queue (20 MCQs)

141. Priority queue orders elements by:
    - A) insertion order
    - B) priority value
    - C) random order
    - D) size order
    **Answer: B**

142. Priority queue can be:
    - A) min-priority queue only
    - B) max-priority queue only
    - C) both min and max
    - D) neither min nor max
    **Answer: C**

143. In min-priority queue:
    - A) highest priority element is removed first
    - B) lowest priority element is removed first
    - C) random element is removed
    - D) last element is removed
    **Answer: B**

144. In max-priority queue:
    - A) highest priority element is removed first
    - B) lowest priority element is removed first
    - C) random element is removed
    - D) last element is removed
    **Answer: A**

145. Priority queue operations include:
    - A) insert and delete
    - B) enqueue and dequeue
    - C) push and pop
    - D) all of above
    **Answer: D**

146. Priority queue `insert(x, priority)`:
    - A) adds element x with given priority
    - B) removes element with priority x
    - C) updates priority of element x
    - D) finds element with priority x
    **Answer: A**

147. Priority queue `delete()` or `extract()`:
    - A) removes highest/lowest priority element
    - B) removes random element
    - C) removes last element
    - D) removes first element
    **Answer: A**

148. Priority queue `peek()` or `top()`:
    - A) returns highest/lowest priority element
    - B) returns random element
    - C) returns last element
    - D) returns first element
    **Answer: A**

149. Priority queue can be implemented using:
    - A) array only
    - B) linked list only
    - C) heap only
    - D) all of above
    **Answer: D**

150. Heap-based priority queue:
    - A) is most efficient
    - B) is least efficient
    - C) is same as others
    - D) depends on size
    **Answer: A**

151. Array-based priority queue:
    - A) maintains sorted order
    - B) maintains insertion order
    - C) maintains random order
    - D) maintains reverse order
    **Answer: A**

152. Linked list-based priority queue:
    - A) maintains sorted order
    - B) maintains insertion order
    - C) maintains random order
    - D) maintains reverse order
    **Answer: A**

153. Priority queue applications:
    - A) CPU scheduling
    - B) Dijkstra's algorithm
    - C) Huffman coding
    - D) all of above
    **Answer: D**

154. Priority queue in CPU scheduling:
    - A) schedules tasks by priority
    - B) schedules tasks by time
    - C) schedules tasks randomly
    - D) schedules tasks by size
    **Answer: A**

155. Priority queue in Dijkstra's algorithm:
    - A) finds shortest path
    - B) finds longest path
    - C) finds random path
    - D) finds all paths
    **Answer: A**

156. Priority queue in Huffman coding:
    - A) builds optimal prefix code
    - B) builds random code
    - C) builds fixed code
    - D) builds variable code
    **Answer: A**

157. Priority queue `changePriority(x, newPriority)`:
    - A) changes priority of element x
    - B) changes element x to newPriority
    - C) removes element with priority x
    - D) adds element with newPriority
    **Answer: A**

158. Priority queue `isEmpty()`:
    - A) checks if empty
    - B) checks if full
    - C) checks size
    - D) checks capacity
    **Answer: A**

159. Priority queue `size()`:
    - A) returns number of elements
    - B) returns capacity
    - C) returns priority range
    - D) returns element type
    **Answer: A**

160. Priority queue vs simple queue:
    - A) priority queue is always better
    - B) simple queue is always better
    - C) depends on requirements
    - D) both are same
    **Answer: C**

---

**Total MCQs: 160**

**Topics Covered:**
- Python Basics (20 MCQs)
- Lists (20 MCQs) 
- Linked List (20 MCQs)
- Stack (20 MCQs)
- Queue (20 MCQs)
- Circular Queue (20 MCQs)
- Double Ended Queue/Deque (20 MCQs)
- Priority Queue (20 MCQs)

**Note:** All MCQs avoid time complexity and space complexity questions as requested. Focus on concepts, operations, applications, and implementation details.


