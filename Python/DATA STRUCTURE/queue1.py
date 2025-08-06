queue = []

# Enqueue फंक्शन: element को आखिरी में जोड़ता है
def enqueue(queue, item):
    queue.append(item)
    print(f"{item} enqueued")

# Dequeue फंक्शन: सबसे पहले element को हटाता है
def dequeue(queue):
    if len(queue) == 0:
        print("Queue is empty")
        return None
    item = queue.pop(0)
    print(f"{item} dequeued")
    return item

# Display फंक्शन: पूरा queue दिखाता है
def display(queue):
    print("Queue contents:", queue)

# Example usage
enqueue(queue, 5)
enqueue(queue, 10)
enqueue(queue, 15)
display(queue)
dequeue(queue)
display(queue)
