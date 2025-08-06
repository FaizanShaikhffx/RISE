// #include<bits/stdc++.h>
// using namespace std;

// int main (){;
//   int array[2][3] = {{1, 2, 5}, {7, 8, 9}};
//   for(int i = 0; i < 2; i++){
//     for(int j = 0; j < 3; j++){
//       cout<<(array[i][j] * 2 )<<" ";
//     }
//     cout<<endl;
//   }
//   return 0;
// }



//find wovel in char array

// #include<bits/stdc++.h>
// using namespace std;

// int main (){

//   char ch[50] = "abcdefghijklmnopqrstuvwxyz";
//   int vowel = 0; 
//   for(int i = 0; i<50; i++){
//     if(ch[i] == 'a' || ch[i] == 'e' || ch[i] == 'i' || ch[i] == 'o' || ch[i] == 'u' || ch[i] == 'A' || ch[i] == 'E' || ch[i] == 'I' || ch[i] == 'O' || ch[i] == 'U'){
//       vowel++; 
//     }else{
//       continue;
//     }
//   }
//   cout<<"Total vowel is : "<<vowel;

//   return 0;
// }



//reverse the string
// #include<bits/stdc++.h>
// using namespace std;

// int main (){;
//   char ch[] = "Hi there"; 
//   int size = strlen(ch);
//   for(int i = size; i>=0; i--){
//     cout<<ch[i]<<" ";
//   }

//   return 0;
// }


#include<bits/stdc++.h>
using namespace std;

int main (){
  int a = 0;
  int b = 1; 
  int n; 
  cout<<"Enter the Value of n : "; 
  cin>>n; 

  for(int i = 2; i<n; i++){
    int next = a + b; 
    cout<<next<<" "; 
    a = b;
    b = next; 
  }

  return 0;
}
