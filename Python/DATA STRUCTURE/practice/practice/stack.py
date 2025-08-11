max = 100

stack  = []

def push(value): 
  if len(stack) >= max:
    print("stack full hai")
  else:
    stack.append(value)
    print("Value added to stack")

def pop():
  if len(stack) == 0:
    print("stack khaali hai")
    return -1
  else: 
    return stack.pop()
  

push(1)
push(2)
push(3)

print(stack)
 
pop()
pop()
    
print(stack)