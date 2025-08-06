size = 5
queue = [None] * size
rear = -1
front = 0


def enqueue(value):
    global front, rear
    if rear == size -1:
        print("Queue is full")
    else:
        rear = rear + 1
        queue[rear] = value


enqueue(10)
enqueue(10)
enqueue(10)
enqueue(10)
enqueue(10)

def deque():
    global front, rear
    if front > rear:
        print("Queue is empty")
    else: 
        queue[front] = None
        front = front + 1



deque()
deque()
deque()
deque()
deque()
deque()
print(queue)