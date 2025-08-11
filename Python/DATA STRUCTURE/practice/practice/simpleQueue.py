size = 5

queue = [None] * 5

front = 0

rear = -1

def enqueue(value):
  global rear
  if rear == size-1:
    print("queue toh full hai")
  else:
    rear = rear + 1
    queue[rear] = value
    
    
    
print(queue)
enqueue(5)
enqueue(5)
enqueue(5)
enqueue(5)
enqueue(5)

print(queue)

def deque():
  global front, rear
  if rear == -1:
    print("Are bhai queue empty hai")
  else: 
    queue[front] = None
    front = front + 1
    
deque()
deque()
deque()
deque()
deque()
print(queue)