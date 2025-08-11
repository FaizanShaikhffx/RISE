size = 5

queue = [None ] * 5

front = -1

rear = -1

def enque(value):
  global front, rear
  
  if (rear + 1) % size == front:
    print("Queue is full")
  else: 
    if front == -1:
      front = 0
    rear = (rear + 1) % size 
    queue[rear] = value



def deque():
  global front, rear
  if front == -1:
    print("Queue emplty hai")
  else:
    queue[front] = None
  if front == rear:
    front = -1
    rear = -1
  else:
    front = (front + 1) % size
    

    
    
enque(10)
enque(10)
enque(10)
print(queue)
deque()
deque()
print(queue)
