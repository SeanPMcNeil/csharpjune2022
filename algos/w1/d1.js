// Singly Linked Lists (SLL)

// Node & SLL Classes

// We need a Node Class
class Node {
    // We pass in a value every time we create a node
    constructor(value) {
        // that value is passed into data
        this.data = value;
        // We can't assume this node has anything to point to, so it starts at null
        this.next = null;
    }
}

// Singly Linked List Class
class SLL {
    // this creates a list with nothing inside of it
    constructor() {
        this.head = null;
    }

    // We are going to be writing methods that make this class function
    // How do we identify that a singly linked list is empty?
    isEmpty() {
        // If the head is pointing at null, there is nothing in our SLL
        // if (this.head == null) {
        //     // yes, the SLL is empty
        //     return true;
        // } else {
        //     // no, the SLL is not empty
        //     return false;
        // }

        // a more efficient way of writing the question
        return this.head == null;
    }

    print() {
        // Print out all the values in our singly linked list
        // we want to push all the values into an array and print that array out
        var arr = [];
        var runner = this.head;
        // we need to use .push to push in the data of the node
        // we want to keep going until we hit null
        // we don't know how many times we're going to run, so a while loop is the optimal solution
        // if runner because null this loop syntax changes to false
        while (runner) {
            // we need to add the data to the array
            arr.push(runner.data);
            // We NEED to iterate
            runner = runner.next;
        }
        console.log(arr);
    }

    insertAtBack(val) {
        if (this.isEmpty()) {
            this.head = new Node(val);
        } else {
            var runner = this.head;
            // we need to get to the back
            while (runner.next) {
                runner = runner.next;
            }
            runner.next = new Node(val);
        }
    }

}

var sll = new SLL();
// var node1 = new Node(5);
// var node2 = new Node(7);
// var node3 = new Node(9);
// var node4 = new Node(1);
// console.log(sll.isEmpty());
// sll.head = node1;
console.log(sll.isEmpty());
// Remember, the head is a pointer
// The pointer is pointing at a node
// That node has a data and a next value
// So when we represent the node as head, we are able to grab its attributes
// sll.head.next = node2;
// sll.head.next.next = node3;
// sll.head.next.next.next = node4;

sll.insertAtBack(5);
sll.insertAtBack(7);
sll.insertAtBack(9);
sll.insertAtBack(1);

console.log(sll.isEmpty());

// console.log(sll);
sll.print();