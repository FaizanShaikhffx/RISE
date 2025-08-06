size = 5
queue = [None] * 5
back = -1
front = 0

def enq(value):
  global front, back
  if back == size - 1:
    print("Queue is empty")
  else:
    back = back + 1
    queue[back] = value
    
enq(5)
enq(5)
enq(5)
enq(5)
enq(5)

def dq():
  global front, back
  if front > back:
    print("Queue is empty")
  else:
    queue[front] = None
    front = front + 1


dq()

print(queue)

def show():
  global front, back
  if front > back:
    print("Queue is empty")
  else:
    print("Queue contains : ", queue[front: back + 1])


show()
