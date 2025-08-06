size = 5
queue = [None] * size
rear = -1
front = 0  

def enqueue(value):
    global rear
    if rear == size - 1:
        print("Queue is full")
    else:
        rear = rear + 1
        queue[rear] = value

def deque():
    global front, rear
    if front > rear:
        print("Queue is empty")
    else:
        removed = queue[front]
        queue[front] = None
        front = front + 1
        print(f"Removed")
        
        
enqueue(10)
enqueue(20)
enqueue(30)
enqueue(40)
enqueue(50)
print(queue)

deque()
deque()
print(queue)


def show():
  global front, rear
  if front <= rear:
    print(queue)
  elif front == rear + 1:
    print("empty")
  
show()
