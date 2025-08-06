size = 5
queue = [None] * size
front = -1
rear = -1

def enqueue(value):
  global front, rear
  if (rear + 1 ) % size == front:
    print("bhai list toh full hai")
  else:
    if front == -1:
      front = 0
      rear = 0
    else:
      rear = (rear + 1) % size
      queue[rear] = value
      
      
      
      
enqueue(10)
enqueue(10)
enqueue(10)

print(queue)
    
