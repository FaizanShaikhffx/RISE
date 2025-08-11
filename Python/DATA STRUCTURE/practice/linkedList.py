# ============================================
# LINKED LIST IMPLEMENTATION
# ============================================
# A linked list is a linear data structure where elements are stored in nodes
# Each node contains data and a reference (link) to the next node
# Advantages: Dynamic size, easy insertion/deletion
# Disadvantages: No random access, extra memory for links

class Node:
    """
    Node class represents a single element in the linked list
    Each node has data and a reference to the next node
    """
    
    def __init__(self, data):
        """
        Initialize a new node with given data
        Parameters: data - the value to be stored in the node
        """
        self.data = data      # Store the actual data value
        self.next = None      # Reference to the next node (initially None)

class LinkedList:
    """
    LinkedList class manages the collection of nodes
    Provides methods to manipulate the linked list
    """
    
    def __init__(self):
        """
        Initialize an empty linked list
        Head pointer starts as None (no nodes exist yet)
        """
        self.head = None      # Pointer to the first node in the list
    
    def is_empty(self):
        """
        Check if the linked list is empty
        Returns: True if empty (head is None), False otherwise
        """
        return self.head is None
    
    def insert_at_beginning(self, data):
        """
        Insert a new node at the beginning of the linked list
        Parameters: data - the value to be inserted
        """
        # Create a new node with the given data
        new_node = Node(data)
        
        # Make the new node point to the current head
        new_node.next = self.head
        
        # Update head to point to the new node
        self.head = new_node
        
        print(f"Inserted {data} at the beginning")
    
    def insert_at_end(self, data):
        """
        Insert a new node at the end of the linked list
        Parameters: data - the value to be inserted
        """
        # Create a new node with the given data
        new_node = Node(data)
        
        # If list is empty, make the new node the head
        if self.is_empty():
            self.head = new_node
        else:
            # Find the last node by traversing from head
            current = self.head
            
            # Keep moving until we reach the last node (next is None)
            while current.next is not None:
                current = current.next
            
            # Make the last node point to the new node
            current.next = new_node
        
        print(f"Inserted {data} at the end")
    
    def insert_after_node(self, target_data, new_data):
        """
        Insert a new node after a specific node with given data
        Parameters: 
            target_data - data of the node after which to insert
            new_data - data to be inserted
        """
        # If list is empty, cannot insert after any node
        if self.is_empty():
            print("List is empty, cannot insert after node")
            return
        
        # Create a new node
        new_node = Node(new_data)
        
        # Find the target node
        current = self.head
        
        # Traverse the list to find the target node
        while current is not None and current.data != target_data:
            current = current.next
        
        # If target node not found
        if current is None:
            print(f"Node with data {target_data} not found")
            return
        
        # Insert the new node after the target node
        new_node.next = current.next    # New node points to what target was pointing to
        current.next = new_node         # Target node now points to new node
        
        print(f"Inserted {new_data} after node with data {target_data}")
    
    def delete_node(self, data):
        """
        Delete the first node with the given data
        Parameters: data - the data value to be deleted
        """
        # If list is empty, nothing to delete
        if self.is_empty():
            print("List is empty, nothing to delete")
            return
        
        # If head node contains the data to be deleted
        if self.head.data == data:
            # Make head point to the next node
            self.head = self.head.next
            print(f"Deleted node with data {data}")
            return
        
        # Find the node before the one to be deleted
        current = self.head
        
        # Traverse until we find the node before the target
        while current.next is not None and current.next.data != data:
            current = current.next
        
        # If target node not found
        if current.next is None:
            print(f"Node with data {data} not found")
            return
        
        # Delete the target node by updating the link
        current.next = current.next.next
        print(f"Deleted node with data {data}")
    
    def search(self, data):
        """
        Search for a node with the given data
        Parameters: data - the data value to search for
        Returns: True if found, False otherwise
        """
        # Start from the head
        current = self.head
        
        # Traverse the list
        while current is not None:
            # If current node contains the data, return True
            if current.data == data:
                return True
            # Move to next node
            current = current.next
        
        # If we reach here, data was not found
        return False
    
    def get_length(self):
        """
        Get the number of nodes in the linked list
        Returns: count of nodes
        """
        count = 0           # Initialize counter
        current = self.head # Start from head
        
        # Traverse the list and count nodes
        while current is not None:
            count += 1          # Increment counter
            current = current.next  # Move to next node
        
        return count
    
    def display(self):
        """
        Display all elements in the linked list
        Shows the data values and their connections
        """
        if self.is_empty():
            print("Linked list is empty")
            return
        
        print("Linked list contents:", end=" ")
        current = self.head  # Start from head
        
        # Traverse and print each node's data
        while current is not None:
            print(current.data, end="")
            
            # If there's a next node, show the arrow
            if current.next is not None:
                print(" → ", end="")
            
            current = current.next  # Move to next node
        
        print()  # New line at the end
    
    def reverse(self):
        """
        Reverse the linked list in place
        Changes the direction of all links
        """
        # If list is empty or has only one node, no need to reverse
        if self.is_empty() or self.head.next is None:
            print("List is empty or has only one node, no reversal needed")
            return
        
        # Initialize three pointers for reversal
        previous = None      # Points to the previous node
        current = self.head  # Points to the current node
        next_node = None     # Points to the next node
        
        # Traverse the list and reverse links
        while current is not None:
            # Store the next node before changing the link
            next_node = current.next
            
            # Reverse the link (current now points to previous)
            current.next = previous
            
            # Move previous and current one step forward
            previous = current
            current = next_node
        
        # Update head to point to the last node (now first)
        self.head = previous
        
        print("Linked list has been reversed")

# ============================================
# DEMONSTRATION OF LINKED LIST OPERATIONS
# ============================================

print("=== LINKED LIST DEMONSTRATION ===\n")

# Create a new linked list
print("Creating a new linked list...")
linked_list = LinkedList()

# Show initial state
print("Initial linked list state:")
linked_list.display()
print(f"Length: {linked_list.get_length()}")
print(f"Is empty: {linked_list.is_empty()}\n")

# Insert elements at the beginning
print("Inserting elements at the beginning:")
linked_list.insert_at_beginning(30)  # Insert 30
linked_list.insert_at_beginning(20)  # Insert 20
linked_list.insert_at_beginning(10)  # Insert 10

print(f"\nAfter inserting at beginning:")
linked_list.display()
print(f"Length: {linked_list.get_length()}\n")

# Insert elements at the end
print("Inserting elements at the end:")
linked_list.insert_at_end(40)        # Insert 40
linked_list.insert_at_end(50)        # Insert 50

print(f"\nAfter inserting at end:")
linked_list.display()
print(f"Length: {linked_list.get_length()}\n")

# Insert after a specific node
print("Inserting after specific nodes:")
linked_list.insert_after_node(20, 25)  # Insert 25 after 20
linked_list.insert_after_node(50, 60)  # Insert 60 after 50

print(f"\nAfter inserting after specific nodes:")
linked_list.display()
print(f"Length: {linked_list.get_length()}\n")

# Search for elements
print("Searching for elements:")
search_values = [10, 25, 60, 100]
for value in search_values:
    found = linked_list.search(value)
    print(f"Searching for {value}: {'Found' if found else 'Not found'}")

print()

# Delete nodes
print("Deleting nodes:")
linked_list.delete_node(25)  # Delete 25
linked_list.delete_node(10)  # Delete 10

print(f"\nAfter deleting nodes:")
linked_list.display()
print(f"Length: {linked_list.get_length()}\n")

# Reverse the linked list
print("Reversing the linked list:")
linked_list.reverse()

print(f"\nAfter reversing:")
linked_list.display()
print(f"Length: {linked_list.get_length()}\n")

# Show final state
print("Final linked list state:")
linked_list.display()
print(f"Length: {linked_list.get_length()}")
print(f"Is empty: {linked_list.is_empty()}")

# ============================================
# KEY CONCEPTS SUMMARY
# ============================================
print("\n" + "="*60)
print("KEY CONCEPTS SUMMARY")
print("="*60)
print("1. Linked List consists of nodes connected by references")
print("2. Each node contains data and a link to the next node")
print("3. Head pointer points to the first node")
print("4. Last node's next pointer is None")
print("5. Insertion/Deletion at beginning is O(1)")
print("6. Insertion/Deletion at end is O(n)")
print("7. Searching is O(n) - no random access")
print("8. Memory efficient for dynamic data")
print("9. Common applications: Stacks, Queues, Hash Tables")
