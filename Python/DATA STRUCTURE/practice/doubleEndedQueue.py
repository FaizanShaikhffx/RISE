# ============================================
# DOUBLE ENDED QUEUE (DEQUE) IMPLEMENTATION
# ============================================
# A double-ended queue allows insertion and deletion from both ends
# It combines the features of both stack and queue
# Can be used as: LIFO (stack), FIFO (queue), or both

# Define the maximum size of the deque
size = 5

# Create a list to store deque elements, initialized with None values
queue = [None] * size

# Initialize front pointer to -1 (indicates deque is empty)
front = -1

# Initialize rear pointer to -1 (indicates deque is empty)
rear = -1

def enqueue_front(value):
    """
    Function to add an element to the front of the deque
    Parameters: value - the element to be added
    """
    global front, rear  # Access global front and rear variables
    
    # Check if deque is full using circular logic
    # Condition: (rear + 1) % size == front
    if (rear + 1) % size == front:
        print("Deque is full - cannot add more elements")
    else:
        # If deque is empty, set both pointers to 0
        if front == -1:
            front = 0
            rear = 0
        else:
            # Move front pointer backward using circular logic
            # (front - 1) % size handles wrapping from 0 to size-1
            front = (front - 1) % size
        
        # Add the value at the front position
        queue[front] = value
        print(f"Added {value} to front of deque at position {front}")

def enqueue_rear(value):
    """
    Function to add an element to the rear of the deque
    Parameters: value - the element to be added
    """
    global front, rear  # Access global front and rear variables
    
    # Check if deque is full using circular logic
    if (rear + 1) % size == front:
        print("Deque is full - cannot add more elements")
    else:
        # If deque is empty, set both pointers to 0
        if front == -1:
            front = 0
            rear = 0
        else:
            # Move rear pointer forward using circular logic
            rear = (rear + 1) % size
        
        # Add the value at the rear position
        queue[rear] = value
        print(f"Added {value} to rear of deque at position {rear}")

def dequeue_front():
    """
    Function to remove an element from the front of the deque
    Returns: The removed element or None if deque is empty
    """
    global front, rear  # Access global front and rear variables
    
    # Check if deque is empty
    if front == -1:
        print("Deque is empty - nothing to remove from front")
        return None
    else:
        # Store the value to be removed
        removed_value = queue[front]
        
        # Mark the position as empty
        queue[front] = None
        
        # If only one element was in the deque, reset both pointers
        if front == rear:
            front = -1
            rear = -1
        else:
            # Move front pointer forward using circular logic
            front = (front + 1) % size
        
        print(f"Removed {removed_value} from front of deque")
        return removed_value

def dequeue_rear():
    """
    Function to remove an element from the rear of the deque
    Returns: The removed element or None if deque is empty
    """
    global front, rear  # Access global front and rear variables
    
    # Check if deque is empty
    if front == -1:
        print("Deque is empty - nothing to remove from rear")
        return None
    else:
        # Store the value to be removed
        removed_value = queue[rear]
        
        # Mark the position as empty
        queue[rear] = None
        
        # If only one element was in the deque, reset both pointers
        if front == rear:
            front = -1
            rear = -1
        else:
            # Move rear pointer backward using circular logic
            # (rear - 1) % size handles wrapping from 0 to size-1
            rear = (rear - 1) % size
        
        print(f"Removed {removed_value} from rear of deque")
        return removed_value

def show():
    """
    Function to display the current contents of the deque
    Shows elements in order from front to rear, handling circular wrapping
    """
    global front, rear
    
    # Check if deque is empty
    if front == -1:
        print("Deque is empty")
    else:
        print("Deque contents (front to rear):", end=" ")
        i = front  # Start from front position
        
        # Loop through the deque from front to rear
        while True:
            print(queue[i], end=" ")  # Print current element
            
            # If we've reached the rear, we're done
            if i == rear:
                break
            
            # Move to next position with circular wrapping
            i = (i + 1) % size
        
        print()  # New line after printing all elements

def is_empty():
    """
    Function to check if deque is empty
    Returns: True if empty, False otherwise
    """
    return front == -1

def is_full():
    """
    Function to check if deque is full
    Returns: True if full, False otherwise
    """
    return (rear + 1) % size == front

def peek_front():
    """
    Function to see the front element without removing it
    Returns: Front element or None if empty
    """
    if not is_empty():
        return queue[front]
    return None

def peek_rear():
    """
    Function to see the rear element without removing it
    Returns: Rear element or None if empty
    """
    if not is_empty():
        return queue[rear]
    return None

def get_size():
    """
    Function to get the current number of elements in the deque
    Returns: Number of elements
    """
    if is_empty():
        return 0
    elif front <= rear:
        # Normal case: front is before rear
        return rear - front + 1
    else:
        # Wrapped case: front is after rear
        return (size - front) + (rear + 1)

# ============================================
# DEMONSTRATION OF DOUBLE ENDED QUEUE OPERATIONS
# ============================================

print("=== DOUBLE ENDED QUEUE DEMONSTRATION ===\n")

# Show initial state
print("Initial deque state:")
show()
print(f"Front pointer: {front}, Rear pointer: {rear}")
print(f"Is empty: {is_empty()}, Is full: {is_full()}")
print(f"Current size: {get_size()}\n")

# Demonstrate front insertion
print("Adding elements to front of deque:")
enqueue_front(10)   # Add 10 to front
enqueue_front(20)   # Add 20 to front
enqueue_front(30)   # Add 30 to front

print(f"\nAfter adding to front:")
show()
print(f"Front pointer: {front}, Rear pointer: {rear}")
print(f"Front element: {peek_front()}, Rear element: {peek_rear()}\n")

# Demonstrate rear insertion
print("Adding elements to rear of deque:")
enqueue_rear(40)    # Add 40 to rear
enqueue_rear(50)    # Add 50 to rear

print(f"\nAfter adding to rear:")
show()
print(f"Front pointer: {front}, Rear pointer: {rear}")
print(f"Front element: {peek_front()}, Rear element: {peek_rear()}")
print(f"Current size: {get_size()}\n")

# Try to add one more (should fail - deque is full)
print("Trying to add one more element:")
enqueue_front(60)   # This will show "Deque is full"

# Remove from front
print(f"\nRemoving from front:")
dequeue_front()      # Remove 30 from front

print(f"\nAfter removing from front:")
show()
print(f"Front pointer: {front}, Rear pointer: {rear}")
print(f"Front element: {peek_front()}, Rear element: {peek_rear()}\n")

# Remove from rear
print("Removing from rear:")
dequeue_rear()       # Remove 50 from rear

print(f"\nAfter removing from rear:")
show()
print(f"Front pointer: {front}, Rear pointer: {rear}")
print(f"Front element: {peek_front()}, Rear element: {peek_rear()}\n")

# Add more elements to demonstrate circular behavior
print("Adding more elements (demonstrating circular behavior):")
enqueue_front(60)    # Add 60 to front
enqueue_rear(70)     # Add 70 to rear

print(f"\nAfter adding more elements:")
show()
print(f"Front pointer: {front}, Rear pointer: {rear}")
print(f"Front element: {peek_front()}, Rear element: {peek_rear()}")
print(f"Current size: {get_size()}\n")

# Show the full array representation
print("Full array representation (including None values):")
print(queue)

# Demonstrate the flexibility of deque
print(f"\nDeque flexibility demonstration:")
print(f"- Can be used as a stack (LIFO): enqueue_front + dequeue_front")
print(f"- Can be used as a queue (FIFO): enqueue_rear + dequeue_front")
print(f"- Can be used as both: insert/delete from either end")
print(f"- Front pointer: {front} (points to element {queue[front] if front != -1 else 'None'})")
print(f"- Rear pointer: {rear} (points to element {queue[rear] if rear != -1 else 'None'})")

