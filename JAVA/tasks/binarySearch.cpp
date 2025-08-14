#include<bits/stdc++.h>
using namespace std;

int main (){;
  
  int arr[] = {1, 3, 5, 7, 8, 11}; 
  int size = sizeof(arr) / sizeof(arr[0]); 

  int start = 0; 
  int end = size - 1; 
  int target = 5; 

  while(start <= end){
    int mid = (start + end) /2; 
    if(arr[mid] == target){
      cout<<"Tu search kar raha tha : "<<arr[mid]<<endl; 
      break; 
    }else if(target > arr[mid]){
      start = mid + 1; 
    }else{
      end = mid - 1; 
    }
  }
  // in-order
  // left, root, right
  
  // pre-order
  //  root, left, right
  // 18, 15, 17, 19, 12

  // post order
  // left, right, root


  return 0;
}