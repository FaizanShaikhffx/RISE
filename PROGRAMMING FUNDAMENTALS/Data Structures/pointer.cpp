#include <iostream>
using namespace std;

void swapPoin(int *a, int *b) {
    int temp = *a;  
    *a = *b;  
    *b = temp; 
}

int main() {
    int a = 5, b = 10;
    swapPoin(&a, &b);  
    cout << "a = " << a << ", b = " << b << endl;
    return 0;
}