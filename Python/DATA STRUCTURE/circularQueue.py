size = 5
queue = [None] * size
rear = -1
front = 0

def enqueue(value):
    global rear, front
    if (rear + 1) % size  == front:
        print("Queue is full")
    else:
       if front == -1:
         front = 0
      rear = (rear + 1) % size
      queue[rear] = value

def deque():
    global front, rear
    if front > rear:
        print("Queue is empty")
    else:
        removed = queue[front]
        queue[front] = None
        if front == rear:
          front = rear - 1
        else: 
          front = (front + 1) % size
        print("removed")

def show():
    global front, rear
    if front > rear:
        print("Queue is empty")
    else:
        print("Queue contents:", queue[front:rear+1])


enqueue(10)
enqueue(20)
enqueue(30)
enqueue(40)
enqueue(50)
print("Initial queue:", queue)

deque()

print("After dequeuing two elements:", queue)

show()