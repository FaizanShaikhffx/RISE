import { Component, OnInit } from '@angular/core';

interface Todo {
  title: string;
  completed: boolean;
}


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  todos: Todo[] = [];
  isLoading = true;

  constructor() { }

  ngOnInit(): void {
    // BUG #1: Something is supposed to happen here to load the initial data.
    this.fetchInitialTodos(); 
  }

  fetchInitialTodos() {
    // This function simulates fetching data from a server.
    setTimeout(() => {
      this.todos = [
        { title: 'Learn Angular components', completed: true },
        { title: 'Debug this assignment', completed: false },
      ];
      this.isLoading = false;
    }, 1500);
  }

  addTodo(event: Event) {
    // BUG #2: The $event object is being used incorrectly.
    const inputElement = event.target as HTMLInputElement;

    if (inputElement.value) {
      this.todos.push({ title: inputElement.value, completed: false });
      inputElement.value = '';
    }
    if (inputElement.value) {
      this.todos.push({ title: inputElement.value, completed: false });
      inputElement.value = '';
    }
  }

  completeLater(index: number) {

    setTimeout(()=>{
      this.todos[index].completed = true;
    }, 2000);
  }

}
