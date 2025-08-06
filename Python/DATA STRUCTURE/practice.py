size = 5 
queue = [None] * size
back = -1
front = 0

def enqueue(value):
  global back
  if back == size - 1:
    print("Queue is full")
  else:
    back = back + 1
    queue[back] = value
    
    
enqueue(5)
enqueue(6)
enqueue(7)
enqueue(8)
enqueue(9)

def dequeue():
  global front, back
  if front > back:
    print("Queue is empty")
  else:
    queue[front] = None
    front = front + 1


dequeue()
dequeue()
# dequeue()
# dequeue()
# dequeue()

def show():
  global front, back
  if front > back:
    print("Queue is empty")
  else:
    print("Queue contains : ", queue[front: back + 1])


print(queue)
show()