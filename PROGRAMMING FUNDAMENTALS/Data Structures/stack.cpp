#include <iostream>
#define MAX 100
using namespace std; 

int stack[MAX];
int top = -1;

// Push operation
void push(int value) {
    if (top >= MAX - 1) {
        std::cout << "Stack Overflow\n";
    } else {
        top = top + 1; 
        stack[top] = value;
        std::cout << value << " pushed to stack\n";
    }
}

// Pop operation
int pop() {
    if (top < 0) {
        std::cout << "Stack Underflow\n";
        return -1;
    } else {
        return stack[top--];
    }
}

// Peek operation
int peek() {
    if (top < 0) {
        std::cout << "Stack is empty\n";
        return -1;
    } else {
        return stack[top];
    }
}

// Check if empty
bool isEmpty() {
    return top == -1;
}

int main() {
    push(10);
    push(20);
    push(30);

    std::cout << "Top element: " << peek() << "\n";
    std::cout << "Popped element: " << pop() << "\n";
    std::cout << "Is stack empty? " << (isEmpty() ? "Yes" : "No") << "\n";

    return 0;
}
