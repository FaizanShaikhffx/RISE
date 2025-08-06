int x = 0, y = 0; 
  // x = (++y) + (y--);

  x = (++y) + (--y) + (++y);  
  cout<<x<<endl;
  cout<<y<<endl;