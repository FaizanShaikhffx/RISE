# ============================================
# PRIORITY QUEUE IMPLEMENTATION
# ============================================
# A priority queue is a special type of queue where each element has a priority
# Elements with higher priority are dequeued before elements with lower priority
# In case of same priority, FIFO (First In First Out) order is maintained

# Import the PriorityQueue class from Python's queue module
from queue import PriorityQueue

# Create a new priority queue instance
pq = PriorityQueue()

def add_task(priority, task):
    """
    Function to add a task with a given priority to the priority queue
    Parameters: 
        priority - integer representing priority (lower number = higher priority)
        task - the task description or data to be stored
    """
    # Put the task into the priority queue as a tuple (priority, task)
    # The priority queue automatically orders by the first element of the tuple
    pq.put((priority, task))
    print(f"Added task '{task}' with priority {priority}")

def get_next_task():
    """
    Function to get the next highest priority task from the queue
    Returns: The next task or None if queue is empty
    """
    # Check if the priority queue is empty
    if pq.empty():
        print("Priority queue is empty - no tasks available")
        return None
    else:
        # Get the next task (highest priority, lowest number)
        # get() removes and returns the item
        task = pq.get()
        print(f"Processing task: {task}")
        return task

def peek_next_task():
    """
    Function to see the next task without removing it
    Note: This is a limitation of Python's PriorityQueue - it doesn't have peek
    Returns: Information about the next task or None if empty
    """
    if pq.empty():
        print("Priority queue is empty - no tasks to peek")
        return None
    else:
        # Since Python's PriorityQueue doesn't have peek, we'll show the size
        print(f"Next task will be processed from {pq.qsize()} available tasks")
        return pq.qsize()

def show_queue_status():
    """
    Function to display the current status of the priority queue
    """
    if pq.empty():
        print("Priority queue is empty")
    else:
        print(f"Priority queue contains {pq.qsize()} tasks")

# ============================================
# DEMONSTRATION OF PRIORITY QUEUE OPERATIONS
# ============================================

print("=== PRIORITY QUEUE DEMONSTRATION ===\n")

# Show initial state
print("Initial priority queue state:")
show_queue_status()
print()

# Add tasks with different priorities
print("Adding tasks with different priorities:")
print("(Lower number = Higher priority)\n")

# Add emergency tasks (high priority)
add_task(1, "Heart Attack")      # Priority 1 - Highest priority
add_task(1, "Severe Bleeding")   # Priority 1 - Same priority, FIFO order
add_task(2, "Fracture")          # Priority 2 - Medium priority

# Add regular tasks (lower priority)
add_task(5, "Regular Checkup")   # Priority 5 - Lower priority
add_task(3, "Fever")             # Priority 3 - Medium-low priority
add_task(4, "Minor Injury")      # Priority 4 - Low priority

print(f"\nAfter adding all tasks:")
show_queue_status()
print()

# Process tasks in priority order
print("Processing tasks in priority order:")
print("(Tasks will be processed from highest to lowest priority)\n")

# Process all tasks
while not pq.empty():
    task = get_next_task()
    if task:
        priority, task_name = task
        print(f"  → Completed: {task_name} (Priority: {priority})")
    print()

# Show final state
print("Final priority queue state:")
show_queue_status()

# ============================================
# CUSTOM PRIORITY QUEUE IMPLEMENTATION
# ============================================
# Let's also implement a custom priority queue using a list for better understanding

print("\n" + "="*60)
print("CUSTOM PRIORITY QUEUE IMPLEMENTATION")
print("="*60)

class CustomPriorityQueue:
    """
    Custom implementation of priority queue using a list
    This helps understand how priority queues work internally
    """
    
    def __init__(self):
        """Initialize an empty priority queue"""
        self.queue = []  # List to store (priority, item) tuples
    
    def enqueue(self, priority, item):
        """
        Add an item with priority to the queue
        Parameters: priority (int), item (any)
        """
        # Add the item as a tuple (priority, item)
        self.queue.append((priority, item))
        # Sort the queue by priority (lower number = higher priority)
        self.queue.sort(key=lambda x: x[0])
        print(f"Added '{item}' with priority {priority}")
    
    def dequeue(self):
        """
        Remove and return the highest priority item
        Returns: (priority, item) tuple or None if empty
        """
        if self.is_empty():
            print("Custom priority queue is empty")
            return None
        else:
            # Remove and return the first item (highest priority)
            item = self.queue.pop(0)
            print(f"Removed: {item}")
            return item
    
    def peek(self):
        """
        See the highest priority item without removing it
        Returns: (priority, item) tuple or None if empty
        """
        if self.is_empty():
            return None
        return self.queue[0]
    
    def is_empty(self):
        """Check if queue is empty"""
        return len(self.queue) == 0
    
    def size(self):
        """Get the number of items in the queue"""
        return len(self.queue)
    
    def show(self):
        """Display all items in the queue with their priorities"""
        if self.is_empty():
            print("Custom priority queue is empty")
        else:
            print("Custom priority queue contents:")
            for i, (priority, item) in enumerate(self.queue):
                print(f"  {i+1}. {item} (Priority: {priority})")

# Create and demonstrate custom priority queue
print("\nCreating custom priority queue...")
custom_pq = CustomPriorityQueue()

# Add some tasks
print("\nAdding tasks to custom priority queue:")
custom_pq.enqueue(3, "Task C")
custom_pq.enqueue(1, "Task A")
custom_pq.enqueue(2, "Task B")
custom_pq.enqueue(1, "Task A2")  # Same priority as Task A

# Show the queue
print(f"\nCustom priority queue status:")
custom_pq.show()
print(f"Size: {custom_pq.size()}")

# Process tasks
print(f"\nProcessing tasks from custom priority queue:")
while not custom_pq.is_empty():
    task = custom_pq.dequeue()
    if task:
        priority, task_name = task
        print(f"  → Completed: {task_name} (Priority: {priority})")

print(f"\nFinal custom priority queue size: {custom_pq.size()}")

# ============================================
# KEY CONCEPTS SUMMARY
# ============================================
print("\n" + "="*60)
print("KEY CONCEPTS SUMMARY")
print("="*60)
print("1. Priority Queue orders elements by priority (not insertion order)")
print("2. Lower priority numbers = Higher priority (1 > 2 > 3)")
print("3. Same priority elements follow FIFO order")
print("4. Python's PriorityQueue is thread-safe and efficient")
print("5. Custom implementation helps understand the sorting mechanism")
print("6. Common applications: Task scheduling, Dijkstra's algorithm, etc.")
