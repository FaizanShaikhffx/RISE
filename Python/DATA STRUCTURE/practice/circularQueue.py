# ============================================
# CIRCULAR QUEUE IMPLEMENTATION
# ============================================
# A circular queue is a queue where the last element is connected to the first element
# This allows efficient use of memory by reusing empty spaces at the beginning
# Key advantage: No need to shift elements when dequeuing

# Define the maximum size of the queue
size = 5

# Create a list to store queue elements, initialized with None values
queue = [None] * size

# Initialize front pointer to -1 (indicates queue is empty)
front = -1

# Initialize rear pointer to -1 (indicates queue is empty)
rear = -1

def enqueue(value):
    """
    Function to add an element to the rear of the circular queue
    Parameters: value - the element to be added
    """
    global front, rear  # Access global front and rear variables
    
    # Check if queue is full using circular logic
    # Condition: (rear + 1) % size == front
    # This means rear has wrapped around and caught up to front
    if (rear + 1) % size == front:
        print("Queue is full - cannot add more elements")
    else:
        # If queue is empty, set front to 0 (first position)
        if front == -1:
            front = 0
        
        # Move rear pointer to next position using modulo for circular behavior
        # (rear + 1) % size ensures rear wraps around to 0 when it reaches size-1
        rear = (rear + 1) % size
        
        # Add the value at the rear position
        queue[rear] = value
        print(f"Added {value} to queue at position {rear}")

def dequeue():
    """
    Function to remove an element from the front of the circular queue
    Returns: The removed element or None if queue is empty
    """
    global front, rear  # Access global front and rear variables
    
    # Check if queue is empty (front == -1 means no elements)
    if front == -1:
        print("Queue is empty - nothing to remove")
        return None
    else:
        # Store the value to be removed
        removed_value = queue[front]
        
        # Mark the position as empty (optional, for clarity)
        queue[front] = None
        
        # If only one element was in the queue, reset both pointers
        # This happens when front == rear (single element)
        if front == rear:
            front = -1  # Reset to indicate empty queue
            rear = -1   # Reset to indicate empty queue
        else:
            # Move front pointer to next position using modulo for circular behavior
            # (front + 1) % size ensures front wraps around to 0 when it reaches size-1
            front = (front + 1) % size
        
        print(f"Removed {removed_value} from front of queue")
        return removed_value

def show():
    """
    Function to display the current contents of the circular queue
    Shows elements in order from front to rear, handling circular wrapping
    """
    global front, rear
    
    # Check if queue is empty
    if front == -1:
        print("Queue is empty")
    else:
        print("Queue contents:", end=" ")
        i = front  # Start from front position
        
        # Loop through the queue from front to rear
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
    Function to check if circular queue is empty
    Returns: True if empty, False otherwise
    """
    return front == -1

def is_full():
    """
    Function to check if circular queue is full
    Returns: True if full, False otherwise
    """
    return (rear + 1) % size == front

def peek():
    """
    Function to see the front element without removing it
    Returns: Front element or None if empty
    """
    if not is_empty():
        return queue[front]
    return None

def get_size():
    """
    Function to get the current number of elements in the queue
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
# DEMONSTRATION OF CIRCULAR QUEUE OPERATIONS
# ============================================

print("=== CIRCULAR QUEUE DEMONSTRATION ===\n")

# Show initial state
print("Initial queue state:")
show()
print(f"Front pointer: {front}, Rear pointer: {rear}")
print(f"Is empty: {is_empty()}, Is full: {is_full()}")
print(f"Current size: {get_size()}\n")

# Add elements to fill the queue
print("Adding elements to fill the queue:")
enqueue(10)   # Add 10
enqueue(20)   # Add 20
enqueue(30)   # Add 30
enqueue(40)   # Add 40
enqueue(50)   # Add 50

print(f"\nAfter filling the queue:")
show()
print(f"Front pointer: {front}, Rear pointer: {rear}")
print(f"Is empty: {is_empty()}, Is full: {is_full()}")
print(f"Current size: {get_size()}")
print(f"Front element (peek): {peek()}\n")

# Try to add one more (should fail - queue is full)
print("Trying to add one more element:")
enqueue(60)   # This will show "Queue is full"

# Remove some elements from the front
print(f"\nRemoving elements from front:")
dequeue()     # Remove 10
dequeue()     # Remove 20

print(f"\nAfter removing elements:")
show()
print(f"Front pointer: {front}, Rear pointer: {rear}")
print(f"Is empty: {is_empty()}, Is full: {is_full()}")
print(f"Current size: {get_size()}")
print(f"Front element (peek): {peek()}\n")

# Now add more elements (this demonstrates circular behavior)
print("Adding more elements (demonstrating circular behavior):")
enqueue(60)   # Add 60
enqueue(70)   # Add 70

print(f"\nAfter adding more elements:")
show()
print(f"Front pointer: {front}, Rear pointer: {rear}")
print(f"Is empty: {is_empty()}, Is full: {is_full()}")
print(f"Current size: {get_size()}")
print(f"Front element (peek): {peek()}\n")

# Show the full array representation
print("Full array representation (including None values):")
print(queue)
print("Note: Circular queue efficiently reuses empty spaces")

# Demonstrate the circular nature
print(f"\nCircular behavior explanation:")
print(f"- Front pointer: {front} (points to element {queue[front] if front != -1 else 'None'})")
print(f"- Rear pointer: {rear} (points to element {queue[rear] if rear != -1 else 'None'})")
print(f"- When we add elements, rear wraps around from {size-1} to 0")
print(f"- When we remove elements, front wraps around from {size-1} to 0")

