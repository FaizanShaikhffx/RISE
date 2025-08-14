# ============================================
# SIMPLE QUEUE IMPLEMENTATION
# ============================================
# A simple queue follows FIFO (First In First Out) principle
# Elements are added at the back and removed from the front

# Define the maximum size of the queue
size = 5

# Create a list to store queue elements, initialized with None values
queue = [None] * size

# Initialize back pointer to -1 (indicates queue is empty)
back = -1

# Initialize front pointer to 0 (always points to the first element)
front = 0

def enqueue(value):
    """
    Function to add an element to the back of the queue
    Parameters: value - the element to be added
    """
    global back  # Access the global back variable
    
    # Check if queue is full (back pointer has reached the last position)
    if back == size - 1:
        print("Queue is full - cannot add more elements")
    else:
        # Move back pointer to next position
        back = back + 1
        # Add the value at the back position
        queue[back] = value
        print(f"Added {value} to queue at position {back}")

def dequeue():
    """
    Function to remove an element from the front of the queue
    Returns: The removed element or None if queue is empty
    """
    global front, back  # Access global front and back variables
    
    # Check if queue is empty (front pointer has moved past back pointer)
    if front > back:
        print("Queue is empty - nothing to remove")
        return None
    else:
        # Store the value to be removed
        removed_value = queue[front]
        # Mark the position as empty (optional, for clarity)
        queue[front] = None
        # Move front pointer to next position
        front = front + 1
        print(f"Removed {removed_value} from front of queue")
        return removed_value

def show():
    """
    Function to display the current contents of the queue
    Shows only the elements that are actually in the queue
    """
    global front, back
    
    # Check if queue is empty
    if front > back:
        print("Queue is empty")
    else:
        # Display elements from front to back (excluding None values)
        # queue[front: back + 1] creates a slice from front to back inclusive
        print("Queue contains:", queue[front: back + 1])

def is_empty():
    """
    Function to check if queue is empty
    Returns: True if empty, False otherwise
    """
    return front > back

def is_full():
    """
    Function to check if queue is full
    Returns: True if full, False otherwise
    """
    return back == size - 1

def peek():
    """
    Function to see the front element without removing it
    Returns: Front element or None if empty
    """
    if not is_empty():
        return queue[front]
    return None

# ============================================
# DEMONSTRATION OF QUEUE OPERATIONS
# ============================================

print("=== SIMPLE QUEUE DEMONSTRATION ===\n")

# Show initial state
print("Initial queue state:")
show()
print(f"Front pointer: {front}, Back pointer: {back}")
print(f"Is empty: {is_empty()}, Is full: {is_full()}\n")

# Add elements to the queue
print("Adding elements to queue:")
enqueue(5)    # Add 5
enqueue(6)    # Add 6
enqueue(7)    # Add 7
enqueue(8)    # Add 8
enqueue(9)    # Add 9

# Try to add one more (should fail - queue is full)
enqueue(10)   # This will show "Queue is full"

print(f"\nAfter adding elements:")
show()
print(f"Front pointer: {front}, Back pointer: {back}")
print(f"Is empty: {is_empty()}, Is full: {is_full()}")
print(f"Front element (peek): {peek()}\n")

# Remove elements from the queue
print("Removing elements from queue:")
dequeue()     # Remove 5
dequeue()     # Remove 6

print(f"\nAfter removing elements:")
show()
print(f"Front pointer: {front}, Back pointer: {back}")
print(f"Is empty: {is_empty()}, Is full: {is_full()}")
print(f"Front element (peek): {peek()}\n")

# Show the full array (including None values)
print("Full array representation (including None values):")
print(queue)
print("Note: None values represent empty positions")

