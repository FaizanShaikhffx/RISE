from queue import PriorityQueue

pq = PriorityQueue()

pq.put((3, "Fever"))
pq.put((1, "Heartattack"))
pq.put((2, "Fracture"))

while not pq.empty():
  item = pq.get()
  print(item)