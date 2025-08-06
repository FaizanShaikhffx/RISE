# Set the maximum size of the queue
size = 5

# Create a list of 'None' values to represent an empty queue
queue = [None] * size

# Initialize front and rear pointers to -1 (means queue is empty)
front = -1
rear = -1

# Function to add an element to the queue
def enqueue(value):
    global rear, front
    # Check if the queue is full using circular logic
    if (rear + 1) % size == front:
        print("Queue is full")
    else:
        # If queue is empty, set front to 0
        if front == -1: 
            front = 0
        # Move rear to the next position (circularly)
        rear = (rear + 1) % size
        # Insert the value at the rear position
        queue[rear] = value

# Function to remove an element from the queue
def deque():
    global front, rear
    # Check if the queue is empty
    if front == -1:
        print("Queue is empty")
    else:
        # Store the value to be removed
        removed = queue[front]
        # Set that position to None (optional, for clarity)
        queue[front] = None
        # If only one element was in the queue, reset both pointers
        if front == rear:
            front = rear = -1
        else:
            # Move front to the next position (circularly)
            front = (front + 1) % size
        print("Removed:", removed)

# Function to display the queue contents
def show():
    global front, rear
    # If queue is empty
    if front == -1:
        print("Queue is empty")
    else:
        print("Queue contents:", end=" ")
        i = front
        # Loop through the queue from front to rear
        while True:
            print(queue[i], end=" ")
            if i == rear:
                break
            i = (i + 1) % size
        print()

# Add elements to the queue
enqueue(10)
enqueue(20)
enqueue(30)
enqueue(40)
enqueue(50)  # This will print "Queue is full" because the last spot is reserved in circular queue logic

# Show the queue after adding elements
print("Initial queue:", queue)

# Remove two elements from the front
deque()
deque()

# Show the queue after removing two elements
print("After dequeuing two elements:", queue)

# Display the current queue contents
show()
