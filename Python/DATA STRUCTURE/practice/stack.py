# Stack ka maximum size define kar rahe hain
MAX = 100

# Stack ko ek list ke form mein initialize kar rahe hain
stack = []

# Push operation: stack mein value add karna
def push(value):
    if len(stack) >= MAX:
        print("Stack Overflow")  # Agar stack full ho gaya hai toh overflow message
    else:
        stack.append(value)  # Value ko stack ke end mein daal rahe hain
        print(f"{value} pushed to stack")  # Confirmation message

# Pop operation: stack se top value hataana
def pop():
    if len(stack) == 0:
        print("Stack Underflow")  # Agar stack empty hai toh underflow message
        return -1
    else:
        return stack.pop()  # Stack se top element hata ke return kar rahe hain

# Peek operation: stack ka top element dekhna bina hataaye
def peek():
    if len(stack) == 0:
        print("Stack is empty")  # Agar stack empty hai toh message
        return -1
    else:
        return stack[-1]  # Stack ka last element return kar rahe hain

# Check karna ki stack empty hai ya nahi
def isEmpty():
    return len(stack) == 0  # Agar length zero hai toh stack empty hai

# Main function jahan operations perform kar rahe hain
push(10)  # 10 ko stack mein daal rahe hain
push(20)  # 20 ko stack mein daal rahe hain
push(30)  # 30 ko stack mein daal rahe hain

print("Top element:", peek())  # Stack ka top element print kar rahe hain
print("Popped element:", pop())  # Top element ko hata ke print kar rahe hain
print("Is stack empty?", "Yes" if isEmpty() else "No")  # Stack empty hai ya nahi check kar rahe hain


