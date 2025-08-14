#include<bits/stdc++.h>
using namespace std;

int main (){;
  
  int arr[] = {1, 40, 50, 4, 78}; 

  int size = sizeof(arr) / sizeof(arr[0]); 

  for(int i = 0; i<size-1; i++){
    for(int j = 0; j<size-1; j++){
      if(arr[j] > arr[j+1]){
        swap(arr[j], arr[j+1]);
      }
    }
  }

  for(int i = 0; i<size; i++){
    cout<<arr[i]<<" ";
  }

  return 0;
}