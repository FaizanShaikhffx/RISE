int arr[] = {12, 78, 45, 89, 52 ,12, 41, 35};
  int arr1[] = {72, 28, 45, 69, 22 ,22, 31, 45};
  int size = sizeof(arr) / sizeof(arr[0]); 
  int size1 = sizeof(arr1) / sizeof(arr1[0]); 

  int merge[size + size1];
  
  for(int i = 0; i<size; i++){
    merge[i] = arr[i]; 
  }
  for(int i = 0; i<size1; i++){
    merge[size + i ] = arr1[i]; 
  }

  for(int i = 0; i<(size+size1); i++){
    cout<<merge[i]<<" "; 
  }