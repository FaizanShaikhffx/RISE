size = 5
queue = [None] * size
rear = -1
front = -1

def enqueue(value):
    global front, rear
    if (rear == size - 1 and front == 0) or ((rear + 1) % size == front):
        print("Queue is full")
    else:
        if front == -1:   
            front = 0
            rear = 0
        else:
            rear = (rear + 1) % size 
        queue[rear] = value


enqueue(10)
enqueue(10)


# def deque():
#     global front, rear
#     if front == -1:
#         print("Queue is empty")
#     else:
#         queue[front] = None
#         if front == rear:
#           front = -1
#           rear = -1
#         else:
#           front = (front + 1 ) % size


# deque()
# deque()
# deque()

# enqueue(1)
# enqueue(2)
# enqueue(2)


print(queue)

def show():
    if front == -1:
        print("Queue is empty")
    else:
        i = front
        print("Queue contents:", end=" ")
        while True:
            print(queue[i], end=" ")
            if i == rear:
                break
            i = (i + 1) % size
        print()

show()