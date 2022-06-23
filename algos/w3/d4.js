class Node {
    constructor(value, next = null, previous = null) {
        this.data = value;
        this.next = next;
        this.previous = previous;
    }
}
// Doubly Linked Lists
class DLL {
    constructor() {
        this.head = null;
        this.tail = null;
        this.size = 0;
    }

    // Insert @ Front
    insertAtFront(value) {
        this.head = new Node (value, this.head);
        if (!this.tail){
            this.tail = this.head;
        } else {
            this.head.next.previous = this.head;
        }
        this.size++;
        return this;
    }
    // Insert @ Back
    insertAtBack(value) {
        if (!this.head){
            this.head = new Node (value, this.head);
            this.tail = this.head;
            this.size++;
            return this;
        } 
        let node = new Node(value);
        this.tail.next = node;
        node.previous = this.tail;
        this.tail = node;
        this.size++;

        return this;
    }
    // Remove Middle
    removeMiddle() {
        if (this.head == null){
            return this;
        }
        let runner = this.head;
        let count = 0;
        while (runner) {
            count++;
            runner = runner.next;
        }
        if (count === 1){
            this.head = null;
            this.tail = null;
            this.size--;
            return this;
        } else if (count === 2){
            this.head = this.tail;
            this.tail.previous = null;
            this.size--;
            return this;
        }
        let middle = Math.floor(count/2);
        runner = this.head;
        for (var i = 0; i < middle; i++){
            runner = runner.next;
        }
        runner.previous.next = runner.next;
        runner.next.previous = runner.previous;
        this.size--;
        return this;
    }

    print() {
        var arr = [];
        var runner = this.head;
        while(runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        console.log(arr);
    }
}

const dll = new DLL();
dll.insertAtFront(3).insertAtFront(2).insertAtFront(1);
// dll.insertAtBack(4).insertAtBack(3).insertAtBack(2).insertAtBack(1);
dll.print();
// dll.removeMiddle();
// console.log(dll.head.data, dll.tail.data);
// dll.print();
// dll.removeMiddle();
// console.log(dll.head.data, dll.tail.data);
// dll.print();
// dll.removeMiddle();
// console.log(dll.head.data, dll.tail.data);
// dll.print();