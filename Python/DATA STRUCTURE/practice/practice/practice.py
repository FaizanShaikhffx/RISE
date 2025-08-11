size = 5

queue = [None] * 5

front = -1
rear = -1

def enqueue(value):
  global front, rear
  if (rear+1) % size == front:
    print("QUEUE FULL HAI")
  else: 
    if front == -1:
      front = 0
    rear = (rear + 1) % size
    queue[rear] = value

enqueue(10)
enqueue(20)

print(queue)


def deque():
  global front, rear
  if front == -1:
    print("queue is empty")
  else: 
      queue[front] = None
  if front == rear:
    front = -1
    rear = -1
  else: 
    front = (front +1) % size    
    
deque()   
print(queue)