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

    // Insert After (val, existingVal) => insert the value after the given value
    // What do you do if you don't find the existingVal?
    insertAfter(valA, valB) {
        const node = new Node(valA);
        var runner = this.head;
        while (runner) {
            if (runner.data == valB) {
                if (runner == this.tail){
                    this.insertAtBack(valA);
                    return this;
                }
                node.next = runner.next;
                node.previous = runner;
                runner.next = node;
                runner.next.next.previous = node;
                this.size++;
                return this;
            } else {
                runner = runner.next;
            }
        }
        return this;
    }
    // Insert Before (val, existingVal) => inser the value before the provided value
    insertBefore(valA, valB) {
        const node = new Node(valA);
        var runner = this.head;
        while (runner) {
            if (runner.data == valB) {
                if (runner == this.head){
                    this.insertAtFront(valA);
                    return this;
                }
                node.previous = runner.previous;
                node.next = runner;
                runner.previous = node;
                runner.previous.previous.next = node;
                this.size++;
                return this;
            } else {
                runner = runner.next;
            }
        }
        return this;
    }
    // Reverse the DLL (bonus)
    reverse() {
        var runner = this.head;
        const newDLL = new DLL();

        while (runner) {
            newDLL.insertAtFront(runner.data);
            runner = runner.next;
        }
        this.head = newDLL.head;
        this.tail = newDLL.tail;
        return this;
    }
}

const dll = new DLL();
dll.insertAtFront(4).insertAtFront(3).insertAtFront(2).insertAtFront(1);
// dll.insertAtBack(4).insertAtBack(3).insertAtBack(2).insertAtBack(1);
dll.print();
// dll.insertAfter(3, 1);
// dll.print();
// dll.insertBefore(0, 1);
dll.reverse();
dll.print();
console.log(dll)
// dll.removeMiddle();
// console.log(dll.head.data, dll.tail.data);
// dll.print();
// dll.removeMiddle();
// console.log(dll.head.data, dll.tail.data);
// dll.print();
// dll.removeMiddle();
// console.log(dll.head.data, dll.tail.data);
// dll.print();